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
    [Route("api/v{version:apiVersion}/SalesOrder/")]
    [SwaggerTag("Get All Sale Orders")]
    public class SalesOrderApiController : BaseApiController
    {
        private readonly IGenericRepository<Order> _orderRepo;

        public SalesOrderApiController(IGenericRepository<Order> orderRepo)
        {
            _orderRepo = orderRepo;
        }

        /// <summary>
        /// Get all the sales orders based on created Date
        /// </summary>
        /// <param name="createdDate" Example="12/15/2020">Date Format (Month/Day/Year)</param>
        [HttpGet]
        [Route("GetSaleOrders")]
        public IActionResult GetAll(DateTime? createdDate = null)
        {
            try
            {
                var orders = _orderRepo.FindAll(x => x.DeletedAt == null);

                if (createdDate != null)
                    orders = orders.Where(x => x.CreatedAt.Date == createdDate.Value.Date);


                return Ok(new { Status = ApiStatus.Success.ToString(), Message = SuccessMessageConstants.DefaultSuccess, SalesOrders = orders });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        /// Update Sales Orders AxCodes
        /// </summary>
        /// <param name="orderViewModel"></param>
        [HttpPut]
        [Route("UpdateOrderAxCodes")]
        public IActionResult UpdateOrderAxCode(List<UpdateViewModel> orderViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception();

                List<object> responseMessages = new List<object>();
                var count = 0;
                foreach (var order in orderViewModel)
                {
                    count++;

                    var existingOrder = _orderRepo.FindBy(x => x.Id == order.Id && x.DeletedAt == null);
                    if (existingOrder == null)
                    {
                        responseMessages.Add(new { RecordNumber = count, Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, $"Order Id {order.Id}") });
                        continue;
                    }

                    var existingAxCode = _orderRepo.FindBy(x => x.Id != order.Id && x.AXCode == order.AxCode && x.DeletedAt == null);
                    if (existingAxCode != null)
                    {
                        responseMessages.Add(new { RecordNumber = count, Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.AlreadyExists, "Order AxCode") });
                        continue;
                    }

                    existingOrder.AXCode = order.AxCode;

                    if (_orderRepo.Update(existingOrder))
                    {
                        responseMessages.Add(new { RecordNumber = count, Status = ApiStatus.Success, Message = string.Format(SuccessMessageConstants.UpdateSuccess, order.Id + " AxCode has been") });
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
