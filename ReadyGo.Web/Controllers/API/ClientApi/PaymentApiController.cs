using Microsoft.AspNetCore.Mvc;
using ReadyGo.Domain.Constants;
using ReadyGo.Domain.Entities;
using ReadyGo.Domain.Entities.ViewModels;
using ReadyGo.Domain.Enum;
using ReadyGo.Service.Repositories.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReadyGo.Web.Controllers.API.ClientApi
{
    [ApiController]
    [ApiVersion("2.0")]
    [ApiExplorerSettings(GroupName = "client")]
    [Route("api/v{version:apiVersion}/Payment/")]
    [SwaggerTag("Get all payments")]
    public class PaymentApiController : BaseApiController
    {
        private readonly IGenericRepository<Payment> _paymentRepo;

        public PaymentApiController(IGenericRepository<Payment> paymentRepo)
        {
            _paymentRepo = paymentRepo;
        }

        /// <summary>
        /// Get all payments
        /// </summary>
        /// <param name="recieveDate" Example="12/15/2020">Payment Date Format (Month/Day/Year)</param>
        [HttpGet]
        [Route("GetPayments")]
        public IActionResult GetAll(DateTime? recieveDate = null)
        {
            try
            {
                var payments = _paymentRepo.FindAll(x => x.DeletedAt == null);

                if (recieveDate != null)
                    payments = payments.Where(x => x.ReceivedAt.Date == recieveDate.Value.Date);

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = SuccessMessageConstants.DefaultSuccess, Payments = payments });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }


        /// <summary>
        /// Update payment AxCodes based on Payment Id
        /// </summary>
        /// <param name="paymentViewModel"></param>
        [HttpPut]
        [Route("UpdatePaymentAxCodes")]
        public IActionResult UpdatePaymentAxCode(List<UpdateViewModel> paymentViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception();

                List<object> responseMessages = new List<object>();
                var count = 0;
                foreach (var payment in paymentViewModel)
                {
                    count++;

                    var existingPayment = _paymentRepo.FindBy(x => x.Id == payment.Id && x.DeletedAt == null);
                    if (existingPayment == null) 
                    {
                        responseMessages.Add(new { RecordNumber = count, Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, $"Payment Id {payment.Id}" ) });
                        continue;
                    }

                    var existingAxCode = _paymentRepo.FindBy(x => x.Id != payment.Id && x.AXCode == payment.AxCode && x.DeletedAt == null);
                    if (existingAxCode != null)
                    {
                        responseMessages.Add(new { RecordNumber = count, Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.AlreadyExists, "Payment AxCode") });
                        continue;
                    }

                    existingPayment.AXCode = payment.AxCode;

                    if (_paymentRepo.Update(existingPayment))
                    {
                        responseMessages.Add(new { RecordNumber = count, Status = ApiStatus.Success, Message = string.Format(SuccessMessageConstants.UpdateSuccess, payment.Id + " AxCode has been") });
                        continue;
                    }
                    else
                    {
                        responseMessages.Add(new { RecordNumber = count, Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
                        continue;
                    }
                }
                return Ok(responseMessages);
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }
    }
}
