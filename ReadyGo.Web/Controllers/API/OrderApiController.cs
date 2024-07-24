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
    [Route("api/v{version:apiVersion}/Order/")]
    public class OrderApiController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Order> _orderRepo;
        private readonly IGenericRepository<OrderDetail> _orderDetailRepo;
        private readonly IGenericRepository<ReturnOrder> _returnOrderRepo;
        private readonly IGenericRepository<WasteOrders> _wasteOrderRepo;
        private readonly IGenericRepository<Payment> _paymentRepo;
        private readonly IGenericRepository<Configuration> _configRepo;
        private readonly IGenericRepository<Customer> _custRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly INotificationService _notificationService;
        private readonly IProcedures _sp;
        public OrderApiController(IMapper mapper, IGenericRepository<Order> order,
            IGenericRepository<OrderDetail> orderDetailRepo, IGenericRepository<ReturnOrder> returnOrderRepo,
            IGenericRepository<WasteOrders> wasteOrderRepo,
            IGenericRepository<Payment> paymentRepo,
            IGenericRepository<Configuration> configRepo,
            IGenericRepository<Customer> custRepo,
            UserManager<ApplicationUser> userManager,
            INotificationService notificationService, IProcedures sp)
        {
            _sp = sp;
            _mapper = mapper;
            _userManager = userManager;
            _orderRepo = order;
            _orderDetailRepo = orderDetailRepo;
            _returnOrderRepo = returnOrderRepo;
            _wasteOrderRepo = wasteOrderRepo;
            _paymentRepo = paymentRepo;
            _configRepo = configRepo;
            _notificationService = notificationService;
            _custRepo = custRepo;
        }

        /// <summary>
        /// Api to get all orders against a sales person
        /// </summary>
        /// <returns>Return a list of all availble orders </returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        [Route("GetAllOrders")]
        public IActionResult GetOrders()
        {
            try
            {
                var email = DecodeJwt();
                var user = _userManager.Users.Include(x => x.Orders.Where(x => x.DeletedAt == null && x.CreatedAt.Date.Equals(DateTime.Today.Date))).
                                             ThenInclude(x => x.Customer).Include(x => x.Orders).ThenInclude(x => x.Orders).
                                             Include(x => x.Orders).ThenInclude(x => x.ReturnOrders).
                                             Include(x => x.Orders).ThenInclude(x => x.WasteOrders).
                                             Include(x => x.Orders).ThenInclude(x => x.Payment).FirstOrDefault(x => x.Email.Equals(email));
                if (!user.IsActive)
                {
                    return Forbid();
                }

                var orderViewModelList = _mapper.Map<List<Order>, List<OrderDataModel>>(user.Orders.ToList());
                var responseData = new
                {
                    Orders = orderViewModelList
                };
                return Ok(new ApiResponseModel(responseData));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseModel(ApiStatus.Error, ApiErrors.DefaultError.GetDescription(), ApiErrors.DefaultError));
            }
        }

        /// <summary>
        /// Post method for create orders
        /// </summary>
        /// <param name="orderApiViewModel">Order Detail to be added</param>
        /// <returns></returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [Route("CreateOrder")]
        public IActionResult CreateOrder(OrderDataModel orderApiViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponseModel(ApiStatus.Error, ApiErrors.ModelState.GetDescription(), ApiErrors.ModelState));
                }
                Object responseData = null;

                if (!string.IsNullOrEmpty(orderApiViewModel.Payment?.PaymentCode) && orderApiViewModel.Payment?.CustomerId == null)
                {
                    orderApiViewModel.Payment.CustomerId = orderApiViewModel.CustomerId;
                }

                //Get Email of current login sales person
                var email = DecodeJwt();

                //Get Details of sale person who requested to add customer
                ApplicationUser curUser = _userManager.Users.Include(x => x.Role).FirstOrDefault(x => x.Email.Equals(email));

                if (!curUser.IsActive)
                {
                    return Forbid();
                }


                //Checing if order is already created (Created or marked)
                var existingOrder = _orderRepo.FindBy(x => x.SalesPersonId.Equals(curUser.Id) &&
                                                    x.OrderCode.Equals(orderApiViewModel.OrderCode) &&
                                                    (x.CreatedAt.Equals(orderApiViewModel.LastModified) || x.IsMarked));

                if (existingOrder != null)
                {
                    responseData = new
                    {
                        Id = existingOrder.Id
                    };
                    return Ok(new ApiResponseModel(responseData));
                }

                //Case-1: For Updation of MarkOrder
                if (orderApiViewModel.IsMarked)
                {

                    if (orderApiViewModel.Id != null)
                    {
                        existingOrder = _orderRepo.FindBy(x => x.Id.Equals(orderApiViewModel.Id));
                    }
                    else
                    {
                        //if order is created at backend but due to conectivity issue id is not at frontend side
                        existingOrder = _orderRepo.FindBy(x => x.SalesPersonId.Equals(curUser.Id) &&
                                                    x.OrderCode.Equals(orderApiViewModel.OrderCode) 
                                                    && x.CreatedAt.Equals(orderApiViewModel.CreatedAt));

                        //If did'nt find mean order is not created and new order with mark is created at front end
                        if (existingOrder == null)
                        {
                            var _orderEntity = CreateOrder(orderApiViewModel, curUser);

                            SendNotification(_orderEntity, curUser, null, null, true);

                            if (_orderEntity.PaymentId != null)
                            {
                                responseData = new
                                {
                                    Id = _orderEntity.Id,
                                    PaymentId = _orderEntity.PaymentId
                                };
                            }
                            else
                            {
                                responseData = new
                                {
                                    Id = _orderEntity.Id
                                };
                            }

                            _sp.UpdateCustomerBalance(_orderEntity.CustomerId);

                            return Ok(new ApiResponseModel(responseData));
                        }
                    }

                    if (existingOrder != null)
                    {

                        var orderEntity = MarkOrder(existingOrder, orderApiViewModel);
                        SendNotification(orderEntity, curUser, null, null, true);


                        responseData = new
                        {
                            Id = orderEntity.Id
                        };

                        _sp.UpdateCustomerBalance(orderEntity.CustomerId);
                        return Ok(new ApiResponseModel(responseData));
                    }
                    else
                    {
                        return BadRequest((new ApiResponseModel(ApiStatus.Error, "Order " + ApiErrors.NotFound.GetDescription(), ApiErrors.NotFound)));
                    }
                }
                else //Case-2: To Create New Order
                {
                    Order createdOrder = CreateOrder(orderApiViewModel, curUser);
                    if(createdOrder.PaymentId != null)
                    {
                        responseData = new
                        {
                            Id = createdOrder.Id,
                            PaymentId = createdOrder.PaymentId
                        };  
                    }
                    else
                    {
                        responseData = new
                        {
                            Id = createdOrder.Id
                        };
                    }
                    _sp.UpdateCustomerBalance(createdOrder.CustomerId);
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
        private Order CreateOrder(OrderDataModel orderApiViewModel, ApplicationUser curUser)
        {
            try
            {
                //Populate EF entity from view-model
                Order order = _mapper.Map<Order>(orderApiViewModel);

                //Populating data into ef Order model to insert
                order.SalesPersonId = curUser.Id;

                //Check if order is an empty order
                if (orderApiViewModel.Reason != null)
                {
                    //Insert Order Data in Database
                    //_orderRepo.Insert(order);

                    if (!_orderRepo.Insert(order))
                    {
                        throw new Exception();
                    }


                    return order;
                }
                else
                {
                    var percentage = 0.0;
                    var thrashHold = _configRepo.FindAll(x => x.ConfigKey == "SalesManager_DiscountThrashHold" || x.ConfigKey == "MarketingManager_DiscountThrashHold").ToList();
                    var MmDiscount = thrashHold.Where(x => x.ConfigKey == "MarketingManager_DiscountThrashHold").Select(x => x.Value).FirstOrDefault();
                    var SmDiscount = thrashHold.Where(x => x.ConfigKey == "SalesManager_DiscountThrashHold").Select(x => x.Value).FirstOrDefault();
                    if (order.Discount > 0)
                    {
                        if (order.Total > 0)
                        {
                            percentage = Math.Round((Convert.ToDouble(order.Discount) / (order.Discount + order.Total)) * 100, 2);
                        }
                        else if (order.Total < 0)
                        {
                            percentage = Math.Round((Convert.ToDouble(order.Discount) / Math.Abs(order.Total - order.Discount)) * 100, 2);
                        }
                    }
                    if (percentage < Convert.ToDouble(SmDiscount))
                    {
                        order.Status = ApprovalStatus.Approved;
                        order.ApprovalFor = ApprovalFor.NotRequired;
                        //_orderRepo.Insert(order);
                        if (!_orderRepo.Insert(order))
                        {
                            throw new Exception();
                        }

                        //await AddLogAsync(LogActions.DiscountApprovedAuto.GetDescription(), $"order no: {order.OrderCode}", LogsActionSrc.DiscountManagement.ToString());
                    }
                    else if (percentage >= Convert.ToDouble(SmDiscount) && percentage < Convert.ToDouble(MmDiscount))
                    {
                        order.Status = ApprovalStatus.Pending;
                        order.ApprovalFor = ApprovalFor.SalesManager;
                        //_orderRepo.Insert(order);

                        if (!_orderRepo.Insert(order))
                        {
                            throw new Exception();
                        }

                        SendNotification(order, curUser, Roles.Admin.GetDescription(), Roles.SalesManager.GetDescription());

                    }
                    else
                    {
                        order.Status = ApprovalStatus.Pending;
                        order.ApprovalFor = ApprovalFor.MarketingManager;
                        //_orderRepo.Insert(order);
                        if (!_orderRepo.Insert(order))
                        {
                            throw new Exception();
                        }
                        SendNotification(order, curUser, Roles.Admin.GetDescription(), Roles.MarketingManager.GetDescription());
                    }

                    List<OrderDetail> orders = new List<OrderDetail>();
                    if (orderApiViewModel.OrderDetails != null && orderApiViewModel.OrderDetails.Count > 0)
                    {
                        foreach (var item in orderApiViewModel.OrderDetails)
                        {
                            OrderDetail orderDetail = new OrderDetail
                            {
                                OrderId = order.Id,
                                Quantity = item.Quantity,
                                ProductId = item.ProductId,
                                PromotionId = item.PromotionId,
                                Price = item.Price,
                                Discount = item.Discount
                            };

                            orders.Add(orderDetail);
                        }
                        _orderDetailRepo.InsertRange(orders);
                    }

                    List<ReturnOrder> retOrders = new List<ReturnOrder>();
                    if (orderApiViewModel.ReturnOrders != null && orderApiViewModel.ReturnOrders.Count > 0)
                    {
                        foreach (var item in orderApiViewModel.ReturnOrders)
                        {
                            ReturnOrder returnOrder = new ReturnOrder
                            {
                                OrderId = order.Id,
                                Quantity = item.Quantity,
                                ProductId = item.ProductId,
                                Price = item.Price,
                                Reason = item.Reason,
                                ReturnReason = item.ReturnReason,
                                Discount = item.Discount
                            };
                            retOrders.Add(returnOrder);
                        }
                        _returnOrderRepo.InsertRange(retOrders);
                    }

                    List<WasteOrders> wasteOrders = new List<WasteOrders>();
                    if (orderApiViewModel.WasteOrders != null && orderApiViewModel.WasteOrders.Count > 0)
                    {
                        foreach (var item in orderApiViewModel.WasteOrders)
                        {
                            WasteOrders wasteOrder = new WasteOrders
                            {
                                OrderId = order.Id,
                                Quantity = item.Quantity,
                                ProductId = item.ProductId,
                                Price = item.Price,
                                Reason = item.Reason,
                                WasteReason = item.WasteReason,
                                Discount = item.Discount
                            };
                            wasteOrders.Add(wasteOrder);
                        }
                        _wasteOrderRepo.InsertRange(wasteOrders);
                    }

                    //Code To populate Payment Table if payment is made while placing order

                    if (orderApiViewModel.Payment != null)
                    {
                        var paymentEntityModel = _mapper.Map<Payment>(orderApiViewModel.Payment);
                        paymentEntityModel.SalesPersonId = curUser.Id;
                        var custId = orderApiViewModel.CustomerId;
                        var balance = _custRepo.FindAll(x => x.Id == custId)?.FirstOrDefault().Balance ?? 0.0;
                        paymentEntityModel.CurrentBalance = Math.Round(balance + orderApiViewModel.Total);
                        paymentEntityModel.NewBalance = paymentEntityModel.CurrentBalance - paymentEntityModel.PaymentReceived;
                        _paymentRepo.Insert(paymentEntityModel);

                        var orderEntityModel = _orderRepo.Get(order.Id);
                        orderEntityModel.PaymentId = paymentEntityModel.Id;
                        _orderRepo.Update(orderEntityModel);

                        return orderEntityModel;
                    }


                    return order;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [NonAction]
        private Order MarkOrder(Order orderEntity , OrderDataModel apiViewModel)
        {
            try
            {
                orderEntity.IsMarked = apiViewModel.IsMarked;
                //_orderRepo.Update(orderEntity);

                if(orderEntity.PaymentId != null)
                {
                    var payment = _paymentRepo.FindBy(x => x.Id.Equals(orderEntity.PaymentId));
                    payment.IsMarked = orderEntity.IsMarked;
                    _paymentRepo.Update(payment);
                }

                if (!_orderRepo.Update(orderEntity))
                {
                    throw new Exception();
                }

                return orderEntity;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [NonAction]
        private void SendNotification(Order order, ApplicationUser curUser, string module= null, string role = null,bool isMarkOrder = false)
        {
            try
            {
                if(isMarkOrder)
                {
                    _notificationService.PushNotification(
                         string.Format(NotificationConstants.MarkedOrder, order.OrderCode, curUser.Email, curUser.Role.Name),
                         curUser.Id,
                         Url.Action("OrderDetails", "Order", new { id = order.Id }),
                         null,
                         $"{Roles.Admin.GetDescription()}",
                         null);
                }
                else
                {
                    _notificationService.PushNotification(
                                           string.Format(NotificationConstants.DiscountApproval, order.OrderCode),
                                           curUser.Id,
                                           Url.Action("OrderDetails", "Discount", new { id = order.Id }),
                                           NotficationEnums.DiscountedOrder.ToString(),
                                            $"{module},{role}",
                                           null);
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Helper Methods
    }
}