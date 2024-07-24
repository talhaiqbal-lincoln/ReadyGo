using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadyGo.Domain.Constants;
using ReadyGo.Domain.Entities;
using ReadyGo.Domain.Entities.ApiModels;
using ReadyGo.Domain.Entities.Identity;
using ReadyGo.Domain.Enum;
using ReadyGo.Persistence.Seeds;
using ReadyGo.Service.Interfaces;
using ReadyGo.Service.Repositories.Interfaces;
using ReadyGo.Service.Stored_Procedures.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReadyGo.Web.Controllers.API
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "mobile")]
    [Route("api/v{version:apiVersion}/Payment/")]
    public class PaymentApiController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Payment> _paymentRepo;
        private readonly IGenericRepository<Customer> _customerRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly INotificationService _notificationService;
        private readonly IGenericRepository<Order> _orderRepo;
        private readonly IProcedures _sp;

        public PaymentApiController(
            IMapper mapper, IGenericRepository<Order> orderRepo,
            IGenericRepository<Payment> paymentRepo,
            UserManager<ApplicationUser> userManager,
            INotificationService notificationService,
            IGenericRepository<Customer> customerRepo,
            IProcedures sp)
        {
            _sp = sp;
            _orderRepo = orderRepo;
            _customerRepo = customerRepo;
            _mapper = mapper;
            _paymentRepo = paymentRepo;
            _userManager = userManager;
            _notificationService = notificationService;
        }

        /// <summary>
        /// Api to get all payments for a against a sales person
        /// </summary>
        /// <returns>Return a list of all availble payments </returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        [Route("GetAllPayments")]
        public IActionResult GetPayment()
        {
            try
            {
                var email = DecodeJwt();
                var user = _userManager.Users.Include(x => x.Payments.Where(x => x.DeletedAt == null && x.ReceivedAt.Date.Equals(DateTime.Today.Date))).
                                             ThenInclude(x => x.Customer).FirstOrDefault(x => x.Email.Equals(email));

                if (!user.IsActive)
                {
                    return Forbid();
                }

                var paymentViewModelList = _mapper.Map<List<Payment>, List<PaymentApiViewModel>>(user.Payments.ToList());
                var responseData = new
                {
                    Payments = paymentViewModelList
                };
                return Ok(new ApiResponseModel(responseData));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseModel(ApiStatus.Error, ApiErrors.DefaultError.GetDescription(), ApiErrors.DefaultError));
            }
        }

        /// <summary>
        /// Post method for create payment
        /// </summary>
        /// <param name="paymentApiViewModel">Order Detail to be added</param>
        /// <returns></returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [Route("CreatePayment")]
        public IActionResult CreatePayment(PaymentApiViewModel paymentApiViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponseModel(ApiStatus.Error, ApiErrors.ModelState.GetDescription(), ApiErrors.ModelState));
                }
                Object responseData = null;

                //Get Email of current login sales person
                var email = DecodeJwt();

                //Get Details of sale person who requested to add customer
                ApplicationUser curUser = _userManager.Users.Include(x => x.Role).FirstOrDefault(x => x.Email.Equals(email));

                if (!curUser.IsActive)
                {
                    return Forbid();
                }

                //Chech If payment is already created
                var existingPayment = _paymentRepo.FindBy(x => x.SalesPersonId.Equals(curUser.Id) &&
                                                         x.PaymentCode.Equals(paymentApiViewModel.PaymentCode) && 
                                                         (x.ReceivedAt.Equals(paymentApiViewModel.LastModified)|| x.IsMarked));

                if (existingPayment != null)
                {
                    responseData = new
                    {
                        existingPayment.Id
                    };
                    return Ok(new ApiResponseModel(responseData));
                }


                if (paymentApiViewModel.IsMarked)
                {
                    if (paymentApiViewModel.Id != null)
                    {
                        existingPayment = _paymentRepo.FindBy(x => x.Id.Equals(paymentApiViewModel.Id));
                    }
                    else
                    {
                        //if payment is created at backend but due to conectivity issue id is not at frontend side
                        existingPayment = _paymentRepo.FindBy(x => x.SalesPersonId.Equals(curUser.Id)
                                                             && x.PaymentCode.Equals(paymentApiViewModel.PaymentCode) 
                                                             && x.ReceivedAt.Equals(paymentApiViewModel.ReceivedAt));


                        //If did'nt find mean payment is not created and new payment with mark is created at front end
                        if (existingPayment == null)
                        {
                            //Insert New Payment
                            var _paymentEntity = InsertPayment(paymentApiViewModel, curUser);

                            responseData = new
                            {
                                _paymentEntity.Id
                            };

                            SendNotification(_paymentEntity, curUser);
                            _sp.UpdateCustomerBalance(paymentApiViewModel.CustomerId);
                            return Ok(new ApiResponseModel(responseData));
                        }

                    }

                    if (existingPayment != null)
                    {
                        var _paymentEntity = MarkPayment(existingPayment, paymentApiViewModel);

                        SendNotification(_paymentEntity, curUser);

                        responseData = new
                        {
                            _paymentEntity.Id
                        };
                        _sp.UpdateCustomerBalance(paymentApiViewModel.CustomerId);
                        return Ok(new ApiResponseModel(responseData));
                    }
                    else
                    {
                        return BadRequest((new ApiResponseModel(ApiStatus.Error, "Payment " + ApiErrors.NotFound.GetDescription(), ApiErrors.NotFound)));
                    }
                }
                else 
                {
                    //Insert New Payment
                    var _paymentEntity = InsertPayment(paymentApiViewModel, curUser);

                    responseData = new
                    {
                        _paymentEntity.Id
                    };

                    _sp.UpdateCustomerBalance(paymentApiViewModel.CustomerId);
                    return Ok(new ApiResponseModel(responseData));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseModel(ApiStatus.Error, ApiErrors.DefaultError.GetDescription(), ApiErrors.DefaultError));
            }
        }

        #region Helper Methods

        [NonAction]
        public Payment InsertPayment(PaymentApiViewModel apiViewModel,ApplicationUser currentUser)
        {
            try
            {
                var paymentEntityModel = _mapper.Map<Payment>(apiViewModel);
                paymentEntityModel.SalesPersonId = currentUser.Id;

                //Update Customer Balance
                var customer = _customerRepo.FindAll(x => x.Id.Equals(paymentEntityModel.CustomerId)).
                   Include(x => x.Orders).Include(x => x.Payments).FirstOrDefault();

                paymentEntityModel.CurrentBalance = CustomerCredit(customer.Id, null);
                paymentEntityModel.NewBalance = paymentEntityModel.CurrentBalance - paymentEntityModel.PaymentReceived;

                //Insert Payment
                if (!_paymentRepo.Insert(paymentEntityModel))
                {
                    throw new Exception();
                }
                return paymentEntityModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
         
        }

        [NonAction]
        private Payment MarkPayment(Payment paymentEntity,PaymentApiViewModel apiViewModel)
        {
            try
            {
                paymentEntity.IsMarked = apiViewModel.IsMarked;

                if (!_paymentRepo.Update(paymentEntity))
                {
                    throw new Exception();
                }

                return paymentEntity;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [NonAction]
        private void SendNotification(Payment payment, ApplicationUser curUser)
        {
            try
            {
                _notificationService.PushNotification(
                         string.Format(NotificationConstants.MarkedPayment, payment.PaymentCode, curUser.Email, curUser.Role.Name),
                         curUser.Id,
                         Url.Action("PaymentDetails", "Payment", new { id = payment.Id,flag="readonly" }),
                         null,
                         $"{Roles.Admin.GetDescription()}",
                         null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [NonAction]
        private double CustomerCredit(Guid customerId, Guid? paymentId)
        {
            var ordersTotal = _orderRepo.FindAll(x => x.CustomerId.Equals(customerId) && x.DeletedAt == null && !x.IsMarked)
                .Sum(x => x.Total);
            var paymentsTotal = 0.0;
            if (paymentId != null)
            {
                paymentsTotal = _paymentRepo.FindAll(x => x.DeletedAt == null && !x.IsMarked && x.CustomerId.Equals(customerId) &&
                !x.Id.Equals(paymentId)).Sum(x => x.PaymentReceived);
            }
            else
            {
                paymentsTotal = _paymentRepo.FindAll(x => x.DeletedAt == null && !x.IsMarked && x.CustomerId.Equals(customerId)
                ).Sum(x => x.PaymentReceived);
            }
            var total = ordersTotal - paymentsTotal;

            return total;
        }
        #endregion

       

    }
}