using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadyGo.Domain.Constants;
using ReadyGo.Domain.Entities;
using ReadyGo.Domain.Entities.ApiModels;
using ReadyGo.Domain.Entities.Identity;
using ReadyGo.Domain.Enum;
using ReadyGo.Persistence.Seeds;
using ReadyGo.Service.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyGo.Web.Controllers.API
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "mobile")]
    [Route("api/v{version:apiVersion}/Report/")]
    public class ReportApiController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<DeliveryReport> _reportRepo;
        private readonly IGenericRepository<Order> _orderRepo;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReportApiController(IMapper mapper, UserManager<ApplicationUser> userManager, IGenericRepository<DeliveryReport> reportRepo,
            IGenericRepository<Order> orderRepo)
        {
            _mapper = mapper;
            _reportRepo = reportRepo;
            _orderRepo = orderRepo;
            _userManager = userManager;
        }

        /// <summary>
        /// Post method for create Delivery Report
        /// </summary>
        /// <param name="deliveryReportApiViewModel">Report Detail to be added</param>
        /// <returns></returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [Route("CreateDailyReport")]
        public IActionResult CreateDailyReport(DeliveryReportApiViewModel deliveryReportApiViewModel)
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
                ApplicationUser curUser = _userManager.Users.FirstOrDefault(x => x.Email.Equals(email));

                if (!curUser.IsActive)
                {
                    return Forbid();
                }

                var duplicatedReport = _reportRepo.FindAll(x => x.SalesPersonId.Equals(curUser.Id) &&
                                                            x.CreatedAt.Date.Equals(deliveryReportApiViewModel.CreatedAt.Date))
                                                            .Include(x=> x.Vehicle).Include(x => x.Route).FirstOrDefault();
                if(duplicatedReport != null)
                {
                    responseData = new
                    {
                        Id = duplicatedReport.Id,
                        LastDeliveryReportData = duplicatedReport.CreatedAt,
                        DriverName = duplicatedReport.DriverName,
                        VehicleNo = duplicatedReport.Vehicle?.VehicleNumber,
                        DeliveryReportRouteName = duplicatedReport.Route?.Name
                    };
                    return Ok(new ApiResponseModel(responseData));
                }

                var reportEntity = _mapper.Map<DeliveryReport>(deliveryReportApiViewModel);
                reportEntity.SalesPersonId = curUser.Id;

                if (!_reportRepo.Insert(reportEntity))
                {
                    throw new Exception();
                }

                var newcreatedReport = _reportRepo.FindAll(x => x.Id.Equals(reportEntity.Id))
                                                         .Include(x => x.Vehicle).Include(x => x.Route).FirstOrDefault();
                responseData = new
                {
                    Id = newcreatedReport.Id,
                    LastDeliveryReportData = newcreatedReport.CreatedAt,
                    DriverName = newcreatedReport.DriverName,
                    VehicleNo = newcreatedReport.Vehicle?.VehicleNumber,
                    DeliveryReportRouteName = newcreatedReport.Route?.Name
                };
                return Ok(new ApiResponseModel(responseData));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseModel(ApiStatus.Error, ApiErrors.DefaultError.GetDescription(), ApiErrors.DefaultError));
            }
        }

        /// <summary>
        ///   Get monthly report.
        /// </summary>
        /// <returns>List of order deatils between spcified ranbge</returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        [Route("GetMonthlyReport")]
        public IActionResult MonthlyReport(DateTime fromDate , DateTime toDate )
        {
            try
            {
                List<MonthlyReportApiViewModel> reportModelList = new List<MonthlyReportApiViewModel>();

                //Get Email of current login sales person
                var email = DecodeJwt();

                //Get Details of sale person who requested to add customer
                ApplicationUser curUser = _userManager.Users.FirstOrDefault(x => x.Email.Equals(email));

                if (!curUser.IsActive)
                {
                    return Forbid();
                }

                List<IGrouping<DateTime,Order>> orderEnityList = _orderRepo.FindAll(x => x.SalesPersonId.Equals(curUser.Id) && x.DeletedAt == null && !x.IsMarked
                                                        && x.CreatedAt.Date >= fromDate.Date && x.CreatedAt.Date <= toDate.Date)
                                                .Include(x => x.ReturnOrders).Include(x => x.WasteOrders).ToList().GroupBy(x => x.CreatedAt.Date).ToList();

                var reportDates = AllDatesBetween(fromDate, toDate).ToList();

                foreach (var reportDate in reportDates)
                {
                    MonthlyReportApiViewModel reportModel = new MonthlyReportApiViewModel();
                    reportModel.Day = reportDate.Date;
                    var res = orderEnityList.FirstOrDefault(x => x.Key.Date.Equals(reportDate.Date));

                    if(res != null)
                    { 
                        reportModel.SaleTotal = res.Sum(x => x.Total);
                        reportModel.WasteTotal = res.Sum(x => x.WasteOrders.Sum(x => (x.Price - x.Discount) * x.Quantity));
                        reportModel.ReturnTotal = res.Sum(x => x.ReturnOrders.Sum(x => (x.Price - x.Discount) * x.Quantity));
                    }

                    reportModelList.Add(reportModel);
                }

                var responseData = new
                {
                    MonthlyReportList = reportModelList
                };

                return Ok(new ApiResponseModel(responseData));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseModel(ApiStatus.Error, ApiErrors.DefaultError.GetDescription(), ApiErrors.DefaultError));
            }
        }

        [NonAction]

        IEnumerable<DateTime> AllDatesBetween(DateTime start, DateTime end)
        {
            for (var day = start.Date; day <= end; day = day.AddDays(1))
                yield return day;
        }

    }
}
