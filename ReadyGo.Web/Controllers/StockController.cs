using AutoMapper;
using LINQtoCSV;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadyGo.Domain.Constants;
using ReadyGo.Domain.Entities;
using ReadyGo.Domain.Entities.ViewModels;
using ReadyGo.Domain.Enum;
using ReadyGo.Infrastructure.Extension;
using ReadyGo.Persistence.Seeds;
using ReadyGo.Service.Interfaces;
using ReadyGo.Service.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyGo.Web.Controllers
{
    [Authorize]
    public class StockController : BaseController
    {
        private readonly IGenericRepository<Category> _categoryRepo;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<AssignStock> _assignRepo;
        private readonly IGenericRepository<Vehicle> _vehicleRepo;
        private readonly IGenericRepository<TransferStock> _tranferStockRepo;
        private readonly IGenericRepository<Route> _routeRepo;
        private readonly IGenericRepository<Order> _orderRepo;
        private readonly IGenericRepository<OrderDetail> _ordDetRepo;
        private readonly IGenericRepository<WasteOrders> _wasteOrdRepo;
        private readonly IGenericRepository<ReturnOrder> _retOrderRepo;
        private readonly IGenericRepository<PriceHistory> _priceHistoryRepo;
        private readonly IValidationHelper _validationHelper;
        private readonly IMapper _mapper;

        public StockController(IGenericRepository<Category> categoryRepo,
            IGenericRepository<Product> productRepo, IGenericRepository<AssignStock> assignRepo,
            IGenericRepository<Vehicle> vehicleRepo,
            IGenericRepository<TransferStock> tranferStockRepo,
            IGenericRepository<Order> orderRepo,
            IGenericRepository<OrderDetail> ordDetRepo,
            IGenericRepository<WasteOrders> wasteOrdRepo,
            IGenericRepository<ReturnOrder> retOrderRepo,
            IValidationHelper validationHelper,
            IGenericRepository<Route> routeRepo,
            IGenericRepository<PriceHistory> priceHistoryRepo,
            IMapper mapper)
        {
            _assignRepo = assignRepo;
            _categoryRepo = categoryRepo;
            _productRepo = productRepo;
            _vehicleRepo = vehicleRepo;
            _tranferStockRepo = tranferStockRepo;
            _validationHelper = validationHelper;
            _routeRepo = routeRepo;
            _mapper = mapper;
            _orderRepo = orderRepo;
            _wasteOrdRepo = wasteOrdRepo;
            _retOrderRepo = retOrderRepo;
            _ordDetRepo = ordDetRepo;
            _priceHistoryRepo = priceHistoryRepo;
        }

        public IActionResult Index()
        {
            var categories = _categoryRepo.FindAll(x => x.DeletedAt == null).Include(x => x.Products).ThenInclude(x => x.Image);
            return View(categories.OrderBy(x => x.Position).ThenBy(x => x.Name));
        }

        public IActionResult ProductDetails(string id)
        {
            ProductDetailViewModel productDetails = new ProductDetailViewModel();

            var product = _productRepo.FindAll(x => x.Id.Equals(new Guid(id)))
                .Include(x => x.Variants).Include(x => x.Category).Include(x => x.Image).Include(x => x.Prices).FirstOrDefault();

            var orderIds = _orderRepo.FindAll(x => x.CreatedAt.Date.Equals(DateTime.Today) && !x.IsMarked && x.DeletedAt == null).Select(x => x.Id).ToList();

            var transferStocks = _assignRepo.FindAll(x => x.DeletedAt == null)
                .Include(x => x.TransferStock)
                .Where(x => x.TransferStock.CreatedAt.Date.Equals(DateTime.Today))
                .Select(x => new
                {
                    x.ProductId,
                    x.Quantity
                }).ToList();

            var priceHistory = _priceHistoryRepo.FindAll(x => x.DeletedAt == null);

            var orderDetails = _ordDetRepo.FindAll(x => orderIds.Contains(x.OrderId)).ToList();
            var retOrder = _retOrderRepo.FindAll(x => orderIds.Contains(x.OrderId)).ToList();
            var wasteOrder = _wasteOrdRepo.FindAll(x => orderIds.Contains(x.OrderId)).ToList();
            if (product.Variants.Count > 0)
            {
                foreach (var variant in product.Variants)
                {
                    productDetails.Variants.Add(new ProductVariant
                    {
                        VariantName = variant.Name,
                        TotalDelivered = Convert.ToInt32(orderDetails.Where(x => x.ProductId.Equals(variant.Id)).Sum(x => x.Quantity)),
                        TotalReturn = Convert.ToInt32(retOrder.Where(x => x.ProductId.Equals(variant.Id)).Sum(x => x.Quantity)),
                        TotalWaste = Convert.ToInt32(wasteOrder.Where(x => x.ProductId.Equals(variant.Id)).Sum(x => x.Quantity)),
                        TotalAssign = transferStocks.Where(x => x.ProductId.Equals(variant.Id)).Sum(x => x.Quantity),
                        CurrentPrice = priceHistory.OrderByDescending(x => x.From).FirstOrDefault(x => x.ProductId.Equals(variant.Id) && x.From.Date <= DateTime.Today)?.Price ?? 0,
                        AxCode = variant.AxCode
                    }); ;
                }
            }
            else
            {
                productDetails.Variants.Add(new ProductVariant
                {
                    VariantName = product.Name,
                    TotalDelivered = Convert.ToInt32(orderDetails.Where(x => x.ProductId.Equals(new Guid(id))).Sum(x => x.Quantity)),
                    TotalReturn = Convert.ToInt32(retOrder.Where(x => x.ProductId.Equals(new Guid(id))).Sum(x => x.Quantity)),
                    TotalWaste = Convert.ToInt32(wasteOrder.Where(x => x.ProductId.Equals(new Guid(id))).Sum(x => x.Quantity)),
                    TotalAssign = transferStocks.Where(x => x.ProductId.Equals(new Guid(id))).Sum(x => x.Quantity),
                    CurrentPrice = priceHistory.OrderByDescending(x => x.From).FirstOrDefault(x => x.ProductId.Equals(new Guid(id)) && x.From.Date <= DateTime.Today)?.Price ?? 0,
                    AxCode = product.AxCode
                });
            }
            productDetails.Product = product;
            return View(productDetails);
        }

        public IActionResult GetCategory()
        {
            try
            {
                var categories = _categoryRepo.FindAll(x => x.DeletedAt == null).OrderBy(x => x.Position);
                return PartialView("_EditCategory", categories);
            }
            catch (Exception ex)
            {
                LogException(ex);
                return BadRequest(new
                {
                    Message = ErrorMessageConstants.Error
                });
            }
        }

        public IActionResult Assignment()
        {
            return View();
        }

        public IActionResult AssignStock()
        {
            var assignedRoute = _tranferStockRepo.FindAll(x => x.CreatedAt == DateTime.Today).Select(x => x.RouteId).ToList();
            var routes = _routeRepo.FindAll(x => x.DeletedAt == null && x.IsActive).Select(x => new
            {
                x.Id,
                x.Name,
            });

            ViewBag.Routes = routes.Where(x => !assignedRoute.Contains(x.Id)).OrderBy(x => x.Name).AsEnumerable();
            ViewBag.Products = _productRepo.FindAll(x => x.DeletedAt == null && x.ProductId == null).Include(x => x.Category).Select(x => new
            {
                x.Id,
                Name = x.Category.Name + " - " + x.Name
            });
            ViewBag.Vehicles = _vehicleRepo.FindAll(x => x.DeletedAt == null);
            ViewBag.Title = "Assign Stock";
            return View();
        }

        public IActionResult GetProduct(string cat_Id)
        {
            object products;
            products = _productRepo.FindAll(x => x.ProductId == new Guid(cat_Id)).Select(x => new { x.Name, x.Id, Quantity = x.Quantity }).ToList();
            return Json(products);
        }

        [HttpPost]
        public async Task<IActionResult> AssignStocktoRouteAsync(AssignStockViewModel assignedStock)
        {
            try
            {
                var route = assignedStock.RouteId;
                var stock = _tranferStockRepo.FindAll(x => x.RouteId == new Guid(route) && x.CreatedAt == DateTime.Now.Date).FirstOrDefault();
                if (stock == null)
                {
                    var currentUser = await _userManager.GetUserAsync(User);
                    var routeId = assignedStock.RouteId;
                    var vehicleId = assignedStock.VehicleId;
                    var vehicle = _vehicleRepo.Get(new Guid(vehicleId));
                    //if (assignedStock.DriverName != null && assignedStock.DriverName != vehicle.DriverName)
                    //{
                    //    vehicle.DriverName = assignedStock.DriverName;
                    //    _vehicleRepo.Update(vehicle);
                    //}
                    TransferStock transferStock = new TransferStock();
                    transferStock = _mapper.Map<TransferStock>(assignedStock);
                    transferStock.CreatedById = currentUser.Id;
                    transferStock.CreatedAt = DateTime.Now.Date;
                    _tranferStockRepo.Insert(transferStock);
                    foreach (var product in assignedStock.Products)
                    {
                        var assignStock = new AssignStock
                        {
                            ProductId = product.Id,
                            Quantity = product.Quantity,
                            TransferId = transferStock.Id
                        };
                        _assignRepo.Insert(assignStock);
                    }
                    var routeName = _routeRepo.FindAll(x => x.Id == new Guid(assignedStock.RouteId)).FirstOrDefault();
                    await AddLogAsync(LogActions.StockAssigned.GetDescription(), routeName?.Name, LogsActionSrc.StockManagement.ToString());
                    return Ok(new
                    {
                        Message = string.Format(SuccessMessageConstants.AssignedSuccess, "Stock")
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        Message = ErrorMessageConstants.StockAssigned
                    });
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return BadRequest(new { ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> EditAssignStockAsync(AssignStockViewModel assignedStock)
        {
            try
            {
                var transferStock = _tranferStockRepo.FindAll(x => x.Id == assignedStock.Id).Include(x => x.Route).FirstOrDefault();

                if (transferStock != null)
                {
                    transferStock.RouteId = new Guid(assignedStock.RouteId);
                    transferStock.VehicleId = new Guid(assignedStock.VehicleId);

                    transferStock.DriverName = assignedStock.DriverName;
                    var vehicleId = assignedStock.VehicleId;
                    var vehicle = _vehicleRepo.Get(new Guid(assignedStock.VehicleId));

                    _tranferStockRepo.Update(transferStock);
                    var currentUser = await _userManager.GetUserAsync(User);
                    var stocks = _assignRepo.FindAll(x => x.TransferId == assignedStock.Id).ToList();
                    _assignRepo.DeleteRange(stocks);
                    foreach (var product in assignedStock.Products)
                    {
                        var assignStock = new AssignStock
                        {
                            ProductId = product.Id,
                            Quantity = product.Quantity,
                            TransferId = assignedStock.Id
                        };
                        _assignRepo.Insert(assignStock);
                    }
                    await AddLogAsync(LogActions.StockEdited.GetDescription(), transferStock.RouteId.ToString(), LogsActionSrc.StockManagement.ToString());
                    return Ok(new
                    {
                        Message = string.Format(SuccessMessageConstants.UpdateSuccess, "Stock")
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        Message = string.Format(ErrorMessageConstants.NotFound, "Stock")
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = ErrorMessageConstants.Error
                });
            }
        }

        [HttpPost]
        public void UpdatePosition([FromBody] IEnumerable<string> categoryIds)
        {
            var allCategories = _categoryRepo.GetAll().ToList();
            int count = 0;
            foreach (var categoryId in categoryIds)
            {
                var category = allCategories.FirstOrDefault(x => x.Id.Equals(new Guid(categoryId)));
                category.Position = count;
                count += 1;
            }
            _categoryRepo.UpdateRange(allCategories);
        }
        [HttpGet]
        public IActionResult EditStock(string id)
        {
            var routes = _routeRepo.FindAll(x => x.DeletedAt == null && x.IsActive).Select(x => new
            {
                x.Id,
                x.Name,
            });

            ViewBag.Products = _productRepo.FindAll(x => x.DeletedAt == null && x.ProductId == null).Include(x => x.Category).Select(x => new
            {
                x.Id,
                Name = x.Category.Name + " - " + x.Name
            });
            ViewBag.Vehicles = _vehicleRepo.FindAll(x => x.DeletedAt == null);
            ViewBag.Title = "Assign Stock";


            var transferStock = _tranferStockRepo.FindAll(x => x.Id.Equals(new Guid(id)))
                .Include(x => x.AssignStocks).ThenInclude(x => x.Product).ThenInclude(x => x.VariantOf)
                .Include(x => x.Route).ThenInclude(x => x.SalesPersons).ThenInclude(x => x.SalesPerson)
                .Include(x => x.Vehicle).FirstOrDefault();
            var assignedroute = _tranferStockRepo.FindAll(x => x.CreatedAt == DateTime.Today && x.RouteId != transferStock.RouteId).Select(x => x.RouteId).ToList();
            ViewBag.Routes = routes.Where(x => !assignedroute.Contains(x.Id)).OrderBy(x => x.Name).AsEnumerable();
            ViewBag.Title = "Edit Stock";
            var assignedRouteList = _assignedRouteRepo.FindAll(x => x.RouteId.Equals(transferStock.RouteId)).ToList();
            ViewBag.SalesPerson = RouteSp(assignedRouteList);
            return View(transferStock);
        }
        [HttpGet]
        public IActionResult GetSalesPerson(string id)
        {
            try
            {
                var route = _assignedRouteRepo.FindAll(x => x.RouteId == new Guid(id)).Include(x => x.SalesPerson).ToList();
                if (route.Count > 0)
                {
                    return Ok(new
                    {
                        spName = RouteSp(route)
                    });
                }
                else
                {
                    return Ok(new
                    {
                        spName = "Not Assigned"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = ErrorMessageConstants.Error
                });
            }
        }
        [HttpGet]
        public IActionResult GetDriver(string id)
        {
            try
            {
                var vehicle = _vehicleRepo.Get(new Guid(id));
                if (vehicle != null)
                {
                    return Ok(new
                    {
                        DriverName = vehicle.DriverName
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        Message = string.Format(ErrorMessageConstants.NotFound, "Vehicle")
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = ErrorMessageConstants.Error
                });
            }
        }

        [HttpPost]
        public IActionResult AssignedStock()
        {
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var date = Request.Form["columns[3][search][value]"].FirstOrDefault();
                var actStatus = Request.Form["activeStatus"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault()?.Trim().Trim() ?? Request.Form["search"].FirstOrDefault().Trim().Trim();
                var flag = Request.Form["flag"].FirstOrDefault();
                int pageSize = Convert.ToInt32(length ?? "0");
                int skip = Convert.ToInt32(start ?? "0");
                int recordsTotal = 0;
                var dateTime = date == "" ? DateTime.Today : Convert.ToDateTime(date);

                var transferredStock = _tranferStockRepo.FindAll(x => x.DeletedAt == null && x.CreatedAt.Equals(dateTime))
                    .Include(x => x.Route).ThenInclude(x => x.SalesPersons).ThenInclude(x => x.SalesPerson).Include(x => x.CreatedBy)
                    .Where(x => x.Route.DeletedAt == null && x.Route.IsActive).AsEnumerable();
                var stockTransferred = transferredStock.Select(x => new TransferStockViewModel
                {
                    SpName = RouteSpDetails(x.Route.SalesPersons.ToList()),
                    RouteName = x.Route?.Name,
                    AssignedBy = x.CreatedBy.FirstName + " " + x.CreatedBy.LastName,
                    CreatedAt = x.CreatedAt.ToString(),
                    Id = x.Id,
                    Status = x.Status
                });
                if (actStatus != "All")
                {
                    stockTransferred = actStatus.Equals("Active") ? stockTransferred.Where(x => x.Status).ToList() : stockTransferred.Where(x => !x.Status).ToList();
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    stockTransferred = stockTransferred.Where(m => (m.SpName != null && m.SpName.ToLower().Contains(searchValue.ToLower()))
                                        || m.RouteName.ToLower().Contains(searchValue.ToLower()));
                }
                recordsTotal = stockTransferred.Count();
                var data = stockTransferred.Skip(skip).Take(pageSize).ToList();

                return Json(new { draw, recordsFiltered = recordsTotal, recordsTotal, data });
            }
            catch (Exception ex)
            {
                LogException(ex);
                return null;
            }
        }
        [HttpPost]
        public IActionResult DeleteStock(string id, string transferId)
        {
            try
            {
                var stock = _assignRepo.FindAll(x => x.ProductId.Equals(new Guid(id)) &&
                    x.TransferId.Equals(new Guid(transferId))).FirstOrDefault();
                var product = _productRepo.FindAll(x => x.Id.Equals(new Guid(id))).FirstOrDefault();
                if (stock != null && product != null)
                {
                    _assignRepo.Delete(stock);
                    return Ok(new
                    {
                        Message = SuccessMessageConstants.DefaultSuccess
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        Message = string.Format(ErrorMessageConstants.NotFound, "Stock")
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = ErrorMessageConstants.Error
                });
            }

        }
        [HttpGet]
        public IActionResult StockDetail(string id)
        {
            if (id != null)
            {
                var model = _tranferStockRepo.FindAll(x => x.Id == new Guid(id))
                    .Include(x => x.Vehicle)
                    .Include(x => x.Route).ThenInclude(x => x.SalesPersons).ThenInclude(x => x.SalesPerson)
                    .Include(x => x.Route).ThenInclude(x => x.Customers.Where(x => x.DeletedAt == null && x.IsActive))
                    .Include(x => x.AssignStocks).ThenInclude(x => x.Product).ThenInclude(x => x.Category)
                    .Include(x => x.AssignStocks).ThenInclude(x => x.Product).ThenInclude(x => x.Prices)
                    .Include(x => x.AssignStocks).ThenInclude(x => x.Product).ThenInclude(x => x.VariantOf).FirstOrDefault();
                ViewBag.SalesPerson = RouteSp(model.Route.SalesPersons.ToList());
                return View(model);
            }
            else
            {
                return RedirectToAction("Assignment");
            }
        }
        [HttpPost]
        public IActionResult ChangeStatus(string id)
        {
            try
            {
                var model = _tranferStockRepo.Get(new Guid(id));
                model.Status = !model.Status;
                _tranferStockRepo.Update(model);
                return Ok(new
                {
                    Message = string.Format(SuccessMessageConstants.UpdateSuccess, "Assigned stock status")
                });
            }
            catch (Exception ex)
            {
                LogException(ex);
                return BadRequest(new
                {
                    Message = ErrorMessageConstants.Error
                });
            }
        }

        public async Task<IActionResult> BulkImportAsync()
        {
            try
            {
                var currUser = await _userManager.GetUserAsync(User);
                int validRecords = 0, invalidRecord = 0, deletedRecord = 0;
                IFormFile File = Request.Form.Files[0];
                int flag = int.Parse(Request.Form["flag"]);
                CsvFileDescription csvFileDescription = new CsvFileDescription
                {
                    SeparatorChar = ',',
                    FirstLineHasColumnNames = true
                };
                CsvContext csvContext = new CsvContext();
                JsonResult jsonResult = null;
                using var reader = new StreamReader(File.OpenReadStream());
                IEnumerable<ImportStockViewModel> list = csvContext.Read<ImportStockViewModel>(reader, csvFileDescription);

                var productSkuList = list.Select(x => x.ProductSkuCode).ToList();
                var products = _productRepo.FindAll(x => productSkuList.Contains(x.AxCode) && x.DeletedAt == null).ToList();

                var routesList = list.Select(x => x.RouteName).Distinct().ToList();
                var routes = _routeRepo.FindAll(x => x.DeletedAt == null).Where(x => routesList.Contains(x.Name)).ToList();

                var vehicleList = list.Select(x => x.VehicleNumber).Distinct().ToList();
                var vehicles = _vehicleRepo.FindAll(x => x.DeletedAt == null).Where(x => vehicleList.Contains(x.VehicleNumber)).ToList();

                list = CheckforErrors(list, products, routes, vehicles);
                if (list != null)
                {
                    if (list.Count() > 0)
                    {
                        if (list.ToArray().Length <= 1000)
                        {
                            if (flag == 1)
                            {
                                foreach (var stock in list)
                                {
                                    if (stock.ErrorStatus == "")
                                        validRecords++;
                                    else if (stock.ErrorStatus == "Deleted")
                                        deletedRecord++;
                                    else
                                        invalidRecord++;
                                }
                                jsonResult = Json(list.OrderBy(x => x.ErrorStatus));
                                return Ok(new
                                {
                                    Message = "Success",
                                    data = jsonResult.Value,
                                    validUsers = validRecords,
                                    invaliduser = invalidRecord,
                                    deletedUser = deletedRecord
                                });
                            }
                            else
                            {
                                var group = list.Where(x => string.IsNullOrEmpty(x.ErrorStatus)).GroupBy(x => x.RouteName).ToList();
                                if (list.Count(x => string.IsNullOrEmpty(x.ErrorStatus)) > 0)
                                {

                                    int i = 0;
                                    var transferStocksList = new List<TransferStock>();
                                    var assignStocksList = new List<AssignStock>();

                                    foreach (var route in group)
                                    {
                                        var header = route.Select(x => new { x.RouteName, x.VehicleNumber, x.DriverName }).FirstOrDefault();
                                        var stockRoute = routes.Where(x => x.Name.ToLower().Equals(header.RouteName.ToLower())).FirstOrDefault();
                                        var vehicle = vehicles.FindAll(x => x.VehicleNumber == header.VehicleNumber).FirstOrDefault();

                                        var row = new TransferStock
                                        {
                                            CreatedAt = DateTime.Now.Date,
                                            CreatedById = currUser.Id,
                                            RouteId = stockRoute.Id,
                                            VehicleId = vehicle.Id,
                                            DriverName = header.DriverName
                                        };
                                        transferStocksList.Add(row);
                                    }
                                    _tranferStockRepo.InsertRange(transferStocksList);

                                    foreach (var route in routes)
                                    {
                                        var transferId = transferStocksList.Where(x => x.RouteId == route.Id).Select(x => x.Id).FirstOrDefault();
                                        foreach (var stock in list.Where(x => x.RouteName.Equals(route.Name)))
                                        {
                                            var productId = products.Where(x => x.AxCode == stock.ProductSkuCode).Select(x => x.Id).FirstOrDefault();
                                            if (stock.ErrorStatus == "")
                                            {
                                                i++;
                                                var stockRow = new AssignStock();
                                                stockRow.ProductId = productId;
                                                stockRow.Quantity = Convert.ToInt32(stock.Quantity);
                                                stockRow.TransferId = transferId;
                                                assignStocksList.Add(stockRow);
                                            }
                                        }
                                    }
                                    _assignRepo.InsertRange(assignStocksList);


                                    if (i == 0)
                                        return BadRequest(new { Message = ErrorMessageConstants.AllCsvRecordsInvalid });
                                    else
                                    {
                                        foreach (var route in group)
                                        {
                                            await AddLogAsync(LogActions.StockAssigned.GetDescription(), route.First().RouteName, LogsActionSrc.StockManagement.ToString());
                                        }
                                        return Ok(new { Message = "Submitted", flag = i < list.ToArray().Length });
                                    }
                                }
                                else
                                    return BadRequest(new { Message = ErrorMessageConstants.AllCsvRecordsInvalid });
                            }
                        }
                        else
                        {
                            return BadRequest(new
                            {
                                Message = ErrorMessageConstants.MoreThanthousandRecords
                            });
                        }
                    }
                    else
                    {
                        return BadRequest(new
                        {
                            Message = ErrorMessageConstants.EmptyCsv
                        });
                    }
                }
                else
                {
                    return BadRequest(new
                    {
                        Message = ValidationErrorConstants.InvalidCsvError
                    });
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                return BadRequest(new
                {
                    Message = ValidationErrorConstants.InvalidCsvError
                });
            }
        }

        [NonAction]
        public List<ImportStockViewModel> CheckforErrors(IEnumerable<ImportStockViewModel> list, List<Product> products,List<Route> routes,List<Vehicle> vehicles)
        {
            try
            {
                List<ImportStockViewModel> listToRet = new List<ImportStockViewModel>();
                list = list.Select(u => new ImportStockViewModel()
                {
                    RouteName = u.RouteName.CheckString(),
                    ProductSkuCode = u.ProductSkuCode.CheckString(),
                    Quantity = u.Quantity.CheckString(),
                    VehicleNumber = u.VehicleNumber.CheckString(),
                    DriverName = u.DriverName.CheckString()
                });
                listToRet = list.ToList();
                var duplicate = listToRet.GroupBy(x => x.ProductSkuCode).Where(x => x.Count() > 1).SelectMany(x => x).Select(x => new { x.ProductSkuCode, x.RouteName }).ToList();

                var productSkuList = list.Where(x => string.IsNullOrEmpty(x.ErrorStatus)).Select(x => x.ProductSkuCode).ToList();
                products = products.FindAll(x => productSkuList.Contains(x.AxCode) && x.DeletedAt == null).ToList();

                var routesList = list.Where(x => string.IsNullOrEmpty(x.ErrorStatus)).Select(x => x.RouteName).Distinct().ToList();
                routes = routes.FindAll(x => x.DeletedAt == null).Where(x => routesList.Contains(x.Name)).ToList();

                var vehicleList = list.Where(x => string.IsNullOrEmpty(x.ErrorStatus)).Select(x => x.VehicleNumber).Distinct().ToList();
                vehicles = vehicles.FindAll(x => x.DeletedAt == null).Where(x => vehicleList.Contains(x.VehicleNumber)).ToList();

                var transferStocks = _tranferStockRepo.FindAll(x=>x.CreatedAt == DateTime.Today).ToList();

                foreach (var stock in listToRet)
                {
                    var ErrorList = new List<string>();
                    if (TryValidateModel(stock))
                    {
                        if (!stock.ProductSkuCode.Equals(""))
                        {
                            var prod = products.Where(x => x.AxCode == stock.ProductSkuCode).FirstOrDefault();
                            if (prod == null)
                                ErrorList.Add(string.Format(ErrorMessageConstants.NotFound, "Product"));
                            if (duplicate.Count(x => x.RouteName == stock.RouteName && x.ProductSkuCode == stock.ProductSkuCode) > 1)
                                ErrorList.Add("Duplicate Record.");
                        }
                        if (!stock.VehicleNumber.Equals(""))
                        {
                            var vehicle = vehicles.Where(x=>x.VehicleNumber.Equals(stock.VehicleNumber)).FirstOrDefault();
                            if (vehicle == null)
                            {
                                ErrorList.Add(string.Format(ErrorMessageConstants.NotFound, "Vehicle"));
                            }
                        }
                        if (!stock.RouteName.Equals(""))
                        {
                            var route = routes.FindAll(x=>x.Name.ToLower().Equals(stock.RouteName.ToLower())).FirstOrDefault();
                            if (route == null)
                            {
                                ErrorList.Add(string.Format(ErrorMessageConstants.NotFound, "Route"));
                            }
                            else
                            {
                                var alreadyAssigned = transferStocks.FindAll(x => x.RouteId == route.Id).FirstOrDefault();
                                if (alreadyAssigned != null)
                                    ErrorList.Add(ErrorMessageConstants.StockAssigned);
                                if (!route.IsActive)
                                    ErrorList.Add(string.Format(ErrorMessageConstants.InActive, "Route"));
                            }
                        }
                        if (_validationHelper.IsDigitsOnly(stock.Quantity))
                        {
                            if (Int32.Parse(stock.Quantity) > 9999)
                            {
                                ErrorList.Add("The Quantity should be less than 10000.");
                            }
                            if (Int32.Parse(stock.Quantity) <= 0)
                            {
                                ErrorList.Add("The Quantity should be a positive number gerater than 0.");
                            }
                        }
                        else
                        {
                            ErrorList.Add("The Quantity should be a positive number gerater than 0.");
                        }
                    }
                    else
                    {
                        foreach (var err in ModelState.Values)
                            ErrorList.Add(err.Errors.FirstOrDefault().ErrorMessage);
                        ModelState.Clear();
                    }

                    stock.ErrorStatus = ErrorList.Count > 0 ? String.Join(",", ErrorList) : string.Empty;
                }
                return listToRet;
            }
            catch (Exception ex)
            {
                LogException(ex);
                return null;
            }
        }
        [NonAction]
        private string RouteSpDetails(List<AssignedRoute> SalesPersons)
        {
            if (SalesPersons != null && SalesPersons.Count > 0)
            {
                var tempSp = SalesPersons.FirstOrDefault(x => x.TemporaryAssignedTill.HasValue && x.TemporaryAssignedTill.Value.Date >= DateTime.Today);
                if (tempSp != null)
                {
                    var time = tempSp.TemporaryAssignedTill.Value.Date - DateTime.Today;
                    var msg = "";
                    if (time.Days == 0)
                        msg = "today";
                    else if (time.Days == 1)
                        msg = $"{time.Days} day";
                    else
                        msg = $"{time.Days} days";
                    return tempSp.SalesPerson.FirstName + " " + tempSp.SalesPerson.LastName + $" (Temp. assigned for {msg})";
                }
                else
                {
                    var sp = SalesPersons.FirstOrDefault(x => !x.TemporaryAssignedTill.HasValue);
                    if (sp != null)
                    {
                        return sp.SalesPerson.FirstName + " " + sp.SalesPerson.LastName;
                    }
                }
            }
            return "Not Assigned";
        }
    }
}