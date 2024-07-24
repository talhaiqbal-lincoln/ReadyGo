using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadyGo.Domain.Constants;
using ReadyGo.Domain.Entities;
using ReadyGo.Domain.Entities.ApiModels;
using ReadyGo.Domain.Entities.Identity;
using ReadyGo.Domain.Entities.ViewModels;
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
    [Route("api/v{version:apiVersion}/Stock/")]
    public class StockApiController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Category> _category;
        private readonly IGenericRepository<TransferStock> _transferStockRepo;
        private readonly IGenericRepository<Product> _prodcut;
        private readonly IGenericRepository<Route> _routeRepo;
        private readonly IGenericRepository<AssignedRoute> _assignRouteRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _hostingEnviroment;

        public StockApiController(
            UserManager<ApplicationUser> userManager, IMapper mapper, IWebHostEnvironment hostingEnviroment,
            IGenericRepository<Category> category, IGenericRepository<Product> prodcut,
            IGenericRepository<Route> routeRepo,
            IGenericRepository<AssignedRoute> assignRouteRepo,
            IGenericRepository<TransferStock> transferStockRepo)
        {
            _userManager = userManager;
            _mapper = mapper;
            _hostingEnviroment = hostingEnviroment;
            _category = category;
            _prodcut = prodcut;
            _transferStockRepo = transferStockRepo;
            _routeRepo = routeRepo;
            _assignRouteRepo = assignRouteRepo;
        }

        /// <summary>
        /// Api to get Stock Assigned to a sales-person
        /// </summary>
        /// <returns>Return a list of stock assigned to a sales person</returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        [Route("GetSpStock")]
        public async Task<IActionResult> GetSpStock()
        {
            List<StockResponseModel> stockList = new List<StockResponseModel>();
            //List<StockResponseModel> stockList = new List<StockResponseModel>();
            try
            {
                var email = DecodeJwt();

                var user = _userManager.Users.Include(x => x.Routes.Where(x => x.DeletedAt == null)).ThenInclude(x => x.Route).Where(x => x.Email.Equals(email)).FirstOrDefault();

                if (!user.IsActive)
                {
                    return Forbid();
                }

                var permanentRouteId = user.Routes.FirstOrDefault(x => !x.TemporaryAssignedTill.HasValue && x.Route.DeletedAt == null && x.Route.IsActive)?.RouteId;

                var temporaryRouteId = user.Routes.FirstOrDefault(x => x.TemporaryAssignedTill.HasValue && x.TemporaryAssignedTill.Value.Date >= DateTime.Today.Date
                && x.Route.DeletedAt == null && x.Route.IsActive)?.RouteId;

                if (permanentRouteId == null)
                {
                    // TODO
                    var responseData = new
                    {
                        Message = "Stock " + ApiErrors.NotFound.GetDescription(),
                        Vehicle = new VehicleResponseModel(),
                        Stock = stockList
                    };
                    return Ok(new ApiResponseModel(responseData));
                }
                else
                {
                    var routeAssignToAnotherSp = _assignRouteRepo.FindBy(x => x.RouteId.Equals(permanentRouteId) && x.TemporaryAssignedTill.HasValue && x.TemporaryAssignedTill.Value.Date >= DateTime.Today.Date && x.DeletedAt == null);
                    if(routeAssignToAnotherSp != null)
                    {
                        var responseData = new
                        {
                            Message = "Stock " + ApiErrors.NotFound.GetDescription(),
                            Vehicle = new VehicleResponseModel(),
                            Stock = stockList
                        };
                        return Ok(new ApiResponseModel(responseData));
                    }
                }

                TransferStock stockforPermanentRoute = _transferStockRepo
                    .FindAll(x => x.RouteId.Equals(permanentRouteId) && x.CreatedAt.Date.Equals(DateTime.Today.Date) && x.DeletedAt == null && x.Status)
                    .Include(a => a.AssignStocks).ThenInclude(a => a.Product).Include(x => x.Vehicle).FirstOrDefault();

                List<AssignStock> assignStocks = stockforPermanentRoute?.AssignStocks.ToList();

                if (temporaryRouteId != null && assignStocks != null)
                {
                    TransferStock stockforTemporaryRoute = _transferStockRepo.FindAll(x => x.RouteId.Equals(temporaryRouteId) && x.CreatedAt.Date.Equals(DateTime.Today.Date) && x.DeletedAt == null && x.Status)
                        .Include(a => a.AssignStocks).ThenInclude(a => a.Product).Include(x => x.Vehicle).FirstOrDefault();
                    var tempAssignStocksList = stockforTemporaryRoute?.AssignStocks.ToList();
                    List<AssignStock> newTempStocks = new List<AssignStock>();
                    if(tempAssignStocksList != null)
                    {
                        tempAssignStocksList.ForEach(x =>
                        {
                            var tempFound = assignStocks.FirstOrDefault(p => p.ProductId == x.ProductId);
                            if (tempFound != null)
                            {
                                tempFound.Quantity += x.Quantity;
                            }
                            else
                            {
                                newTempStocks.Add(x);
                            }
                        });
                        assignStocks.AddRange(newTempStocks);
                    }
                }

                if (assignStocks != null)
                {
                    var _stockList = _mapper.Map<List<AssignStock>, List<StockResponseModel>>(assignStocks.ToList());
                    stockList.AddRange(_stockList);

                    stockforPermanentRoute.Vehicle.DriverName = stockforPermanentRoute.DriverName;

                    var vehicleData = _mapper.Map<VehicleResponseModel>(stockforPermanentRoute.Vehicle);

                    var responseData = new
                    {
                        CreatedAt = stockforPermanentRoute.CreatedAt,
                        Vehicle = stockforPermanentRoute.Vehicle,
                        Stock = stockList
                    };
                    return Ok(new ApiResponseModel(responseData));
                }
                else
                {
                    var responseData = new
                    {
                        Message = "Stock " + ApiErrors.NotFound.GetDescription(),
                        Vehicle = new VehicleResponseModel(),
                        Stock = stockList
                    };
                    return Ok(new ApiResponseModel(responseData));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseModel(ApiStatus.Error, ApiErrors.DefaultError.GetDescription(), ApiErrors.DefaultError));
            }
        }

        /// <summary>
        /// Api to get all Stock
        /// </summary>
        /// <returns>Return a list of all availble stock </returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        [Route("GetAllProdcuts")]
        public IActionResult GetAllStock()
        {
            try
            {
                List<Category> categoriesWithPrices = new List<Category>();
                //Api Model to send respone data
                List<CategoryResponseModel> categoryResponseModels = new List<CategoryResponseModel>();

                List<Category> categories = _category.FindAll(x => x.DeletedAt == null).Include(x => x.Products.Where(x => x.DeletedAt == null)).ThenInclude(p => p.Image)
                    .Include(x => x.Products).ThenInclude(x => x.Prices.Where(x => x.DeletedAt == null)).
                    Include(x => x.Products).ThenInclude(x => x.Discounts.Where(x => x.DeletedAt == null && x.IsActive)).AsNoTracking().ToList();

                if (categories != null && categories.Count > 0)
                {
                    foreach (var cat in categories)
                    {
                        cat.Products.ToList().ForEach(x =>
                        {
                            var toRemove = x.Prices.Where(y => y.From <= DateTime.Today).OrderByDescending(x => x.From).Skip(1).ToList();
                            toRemove.ForEach(y => x.Prices.Remove(y));
                        });

                    }
                    categoryResponseModels = _mapper.Map<List<Category>, List<CategoryResponseModel>>(categories);
                    var responseData = new
                    {
                        Stock = categoryResponseModels
                    };
                    return Ok(new ApiResponseModel(responseData));
                }
                else
                {
                    var responseData = new
                    {
                        Message = "Categories " + ApiErrors.NotFound.GetDescription(),
                        Stock = categoryResponseModels
                    };
                    return Ok(new ApiResponseModel(responseData));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseModel(ApiStatus.Error, ApiErrors.DefaultError.GetDescription(), ApiErrors.DefaultError));
            }
        }
    }
}
