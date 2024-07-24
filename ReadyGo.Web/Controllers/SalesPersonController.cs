using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadyGo.Domain.Constants;
using ReadyGo.Domain.Entities;
using ReadyGo.Domain.Entities.Identity;
using ReadyGo.Domain.Entities.ViewModels;
using ReadyGo.Domain.Enum;
using ReadyGo.Infrastructure.Filters;
using ReadyGo.Persistence.Seeds;
using ReadyGo.Service.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReadyGo.Infrastructure.Extension;
using ReadyGo.Service.Interfaces;
using ReadyGo.Service.Stored_Procedures.Interface;

namespace ReadyGo.Web.Controllers
{
    [Authorize]
    [TypeFilter(typeof(AuthorizationFilter))]
    public class SalesPersonController : BaseController
    {
        private readonly IGenericRepository<Route> _routesRepo;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Order> _ordersRepo;
        private readonly IGenericRepository<OrderDetail> _orderDetailRepo;
        private readonly IGenericRepository<ReturnOrder> _retOrderRepo;
        private readonly IGenericRepository<WasteOrders> _wasteOrderRepo;
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<Customer> _customerRepo;
        private readonly IGenericRepository<Promotion> _promotionRepo;
        private readonly IGenericRepository<Payment> _paymentRepo;
        private readonly IGenericRepository<Discount> _discountRepo;
        private readonly IGenericRepository<Configuration> _configRepo;
        private readonly IGenericRepository<DeliveryReport> _deliveryReportRepo;
        private readonly INotificationService _notificationService;
        private readonly IInvoiceService _invoiceService;
        private readonly IGenericRepository<TransferStock> _transferStockRepo;
        private readonly IProcedures _sp;

        public SalesPersonController(IGenericRepository<Route> routeRepo, IMapper mapper, IGenericRepository<Order> orderRepo,
            IGenericRepository<Product> productsRepo,
            IGenericRepository<OrderDetail> orderDetailRepo, IGenericRepository<ReturnOrder> retOrderRepo,
             IGenericRepository<Customer> customerRepo, IGenericRepository<Promotion> promotionRepo,
             IGenericRepository<Payment> paymentRepo, IGenericRepository<WasteOrders> wasteOrderRepo,
             IGenericRepository<Discount> discountRepo, IGenericRepository<TransferStock> transferStockRepo,
             IGenericRepository<Configuration> configRepo,
             INotificationService notificationService,
             IGenericRepository<DeliveryReport> paymentDetailRepo,
             IInvoiceService invoiceService, IProcedures sp)
        {
            _sp = sp;
            _transferStockRepo = transferStockRepo;
            _deliveryReportRepo = paymentDetailRepo;
            _discountRepo = discountRepo;
            _wasteOrderRepo = wasteOrderRepo;
            _promotionRepo = promotionRepo;
            _ordersRepo = orderRepo;
            _mapper = mapper;
            _routesRepo = routeRepo;
            _productsRepo = productsRepo;
            _retOrderRepo = retOrderRepo;
            _orderDetailRepo = orderDetailRepo;
            _customerRepo = customerRepo;
            _paymentRepo = paymentRepo;
            _configRepo = configRepo;
            _notificationService = notificationService;
            _invoiceService = invoiceService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SalesPersons()
        {
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var status = Request.Form["status"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["order[0][column]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault()?.Trim().Trim() ?? "";
                var flag = Request.Form["flag"].FirstOrDefault();
                int pageSize = Convert.ToInt32(length ?? "0");
                int skip = Convert.ToInt32(start ?? "0");
                int recordsTotal = 0;
                var routes = _routesRepo.GetAll().ToList();

                var salesPersonData = _userManager.Users.Include(x => x.ProfileImage).Include(x => x.Role)
                    .Include(x => x.Routes).ThenInclude(x => x.Route).ThenInclude(x => x.Customers)
                    .Where(x => x.Role.Name == Roles.SalesPerson.GetDescription() && x.DeletedAt == null && x.EmailConfirmed)
                    .ToList();
                switch (status)
                {
                    case "Active":
                        salesPersonData = salesPersonData.Where(x => x.IsActive).ToList();
                        break;

                    case "Not Active":
                        salesPersonData = salesPersonData.Where(x => !x.IsActive).ToList();
                        break;

                    default:
                        break;
                }
                List<AssignedTableViewModel> salesPersons = new List<AssignedTableViewModel>();
                foreach (var sp in salesPersonData)
                {
                    salesPersons.Add(GetSpRouteDetails(sp));
                }

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    int column = int.Parse(sortColumn);
                    switch (column)
                    {
                        case 1:
                            salesPersons = (sortColumnDirection == "asc" ? salesPersons.OrderBy(c => c.SalesPersonName) :
                                salesPersons.OrderByDescending(c => c.SalesPersonName)).ToList();
                            break;

                        case 2:
                            salesPersons = (sortColumnDirection == "asc" ? salesPersons.OrderBy(c => c.EmployeeCode) :
                                salesPersons.OrderByDescending(c => c.EmployeeCode)).ToList();
                            break;
                        case 3:
                            salesPersons = (sortColumnDirection == "asc" ? salesPersons.OrderBy(c => c.Email) :
                                salesPersons.OrderByDescending(c => c.Email)).ToList();
                            break;
                        case 4:
                            salesPersons = (sortColumnDirection == "asc" ? salesPersons.OrderBy(c => c.RouteName) :
                                salesPersons.OrderByDescending(c => c.RouteName)).ToList();
                            break;

                        case 5:
                            salesPersons = (sortColumnDirection == "asc" ? salesPersons.OrderBy(c => c.TempRouteName) :
                                salesPersons.OrderByDescending(c => c.TempRouteName)).ToList();
                            break;
                    }
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    salesPersons = salesPersons.Where(m => m.SalesPersonName.Contains(searchValue, StringComparison.OrdinalIgnoreCase)
                                        || m.Email.Contains(searchValue, StringComparison.OrdinalIgnoreCase)
                                        || (!string.IsNullOrEmpty(m.EmployeeCode)
                                        && m.EmployeeCode.Contains(searchValue, StringComparison.OrdinalIgnoreCase))
                                        || (!string.IsNullOrEmpty(m.RouteName)
                                        && m.RouteName.Contains(searchValue, StringComparison.OrdinalIgnoreCase))
                                        ).ToList();
                }
                recordsTotal = salesPersons.Count();
                var data = salesPersons.Skip(skip).Take(pageSize).ToList();

                return Json(new { draw, recordsFiltered = recordsTotal, recordsTotal, data });
            }
            catch (Exception ex)
            {
                LogException(ex);
                return null;
            }
        }

        public IActionResult Routes()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SPRoutes()
        {
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["order[0][column]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault()?.Trim().Trim() ?? "";
                var flag = Request.Form["flag"].FirstOrDefault();
                int pageSize = Convert.ToInt32(length ?? "0");
                int skip = Convert.ToInt32(start ?? "0");
                int recordsTotal = 0;

                var salesPersonData = _userManager.Users.
                    Include(x => x.Routes).ThenInclude(x => x.Route).ThenInclude(x => x.Customers).
                    Include(x => x.Role).
                    Where(x => x.Role.Name == Roles.SalesPerson.GetDescription() &&
                    x.DeletedAt == null && x.EmailConfirmed && x.IsActive).ToList();

                List<AssignedTableViewModel> tableData = new List<AssignedTableViewModel>();
                foreach (var salesperson in salesPersonData)
                {
                    tableData.Add(GetSpRouteDetails(salesperson));
                }
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    int column = int.Parse(sortColumn);
                    switch (column)
                    {
                        case 0:
                            tableData = (sortColumnDirection == "asc" ? tableData.OrderBy(c => c.SalesPersonName) :
                                tableData.OrderByDescending(c => c.SalesPersonName)).ToList();
                            break;

                        case 1:
                            tableData = ((sortColumnDirection == "asc" ? tableData.OrderBy(c => c.CustomersCount) :
                                tableData.OrderByDescending(c => c.CustomersCount))).ToList();
                            break;

                        case 2:
                            tableData = ((sortColumnDirection == "asc" ? tableData.OrderBy(c => c.RouteName) :
                                tableData.OrderByDescending(c => c.RouteName))).ToList();
                            break;

                        case 3:
                            tableData = ((sortColumnDirection == "asc" ? tableData.OrderBy(c => c.TempRouteName) :
                                tableData.OrderByDescending(c => c.TempRouteName))).ToList();
                            break;
                    }
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    tableData = tableData.Where(m => m.SalesPersonName.Contains(searchValue, StringComparison.OrdinalIgnoreCase)
                                        || (m.RouteName != null && m.RouteName.Contains(searchValue, StringComparison.OrdinalIgnoreCase))
                                        || (m.TempRouteName != null && m.TempRouteName.Contains(searchValue, StringComparison.OrdinalIgnoreCase))).ToList();
                }
                recordsTotal = tableData.Count();
                var data = tableData.Skip(skip).Take(pageSize).ToList();

                return Json(new { draw, recordsFiltered = recordsTotal, recordsTotal, data });
            }
            catch (Exception ex)
            {
                LogException(ex);
                return null;
            }
        }
        [NonAction]
        public AssignedTableViewModel GetSpRouteDetails(ApplicationUser salesperson)
        {
            AssignedTableViewModel details = new AssignedTableViewModel()
            {
                SalesPersonId = salesperson.Id,
                SalesPersonName = salesperson.FirstName + " " + salesperson.LastName,
                IsActive = salesperson.IsActive,
                Email = salesperson.Email,
                EmployeeCode = string.IsNullOrEmpty(salesperson.AxCode) ? "---" : salesperson.AxCode,
                Image = salesperson.ProfileImage != null ? "data:image;base64," + Convert.ToBase64String(salesperson.ProfileImage.File) : "/resource_files/default_user.jpg",
            };
            try
            {
                var assignedRoutes = salesperson.Routes;
                if (assignedRoutes != null && assignedRoutes.Count > 0)
                {
                    var route = assignedRoutes.FirstOrDefault(x => !x.TemporaryAssignedTill.HasValue);
                    if (route != null)
                    {
                        var custCount = route.Route.Customers.Where(x => x.IsActive && x.DeletedAt == null).ToList().Count;
                        details.CustomersCount += custCount;
                        details.RouteName = route.Route.Name;
                        details.IsActiveRoute = route.Route.IsActive;
                        var tempRoute1 = _assignedRouteRepo.FindBy(x => x.TemporaryAssignedTill.HasValue &&
                         x.TemporaryAssignedTill.Value.Date >= DateTime.Today && x.RouteId.Equals(route.RouteId));
                        if (tempRoute1 != null)
                        {
                            details.RouteTempSp = tempRoute1.SalesPerson.FirstName + " " +
                                tempRoute1.SalesPerson.LastName;
                        }
                    }
                    var tempRoute = assignedRoutes.FirstOrDefault(x => x.TemporaryAssignedTill.HasValue &&
                        x.TemporaryAssignedTill.Value.Date >= DateTime.Today);
                    if (tempRoute != null)
                    {
                        var custCount = tempRoute.Route.Customers.Where(x => x.IsActive && x.DeletedAt == null).ToList().Count;
                        details.CustomersCount += custCount;
                        details.TempRouteName = tempRoute.Route.Name;
                        details.TempRouteTime = tempRoute.TemporaryAssignedTill;
                        details.IsActiveRoute = tempRoute.Route.IsActive;
                    }
                }

                return details;
            }
            catch (Exception ex)
            {
                LogException(ex);
                return details;
            }
        }

        public IActionResult EditSpRoute(string id)
        {
            ViewData["Title"] = "Salesperson Management";
            ViewData["PageTitle"] = "Edit SP Route";
            try
            {
                var assignedRoutes = _assignedRouteRepo.FindAll
                    (x => x.TemporaryAssignedTill == null || x.TemporaryAssignedTill.Value.Date >= DateTime.Today)
                    .ToList();

                var routes = _routesRepo.GetAll().ToList();

                var permanentAssignedRoutes = assignedRoutes.
                    Where(x => !x.SalesPersonId.Equals(id) && x.TemporaryAssignedTill == null).Select(x => x.RouteId);

                var tempAssignedRoutes = assignedRoutes.
                    Where(x => !x.SalesPersonId.Equals(id) && x.TemporaryAssignedTill.HasValue && x.TemporaryAssignedTill.Value.Date >= DateTime.Today).Select(x => x.RouteId);

                ViewBag.Routes = routes.Where(x => !permanentAssignedRoutes.Contains(x.Id)).Select(z => new
                {
                    z.Name,
                    z.Id
                }).OrderBy(x => x.Name);

                ViewBag.TempRoutes = routes.Where(x => !tempAssignedRoutes.Contains(x.Id)
                && permanentAssignedRoutes.Contains(x.Id)).Select(z => new
                {
                    z.Name,
                    z.Id
                }).OrderBy(x => x.Name);

                ApplicationUser user = _userManager.Users.Include(x => x.Routes).ThenInclude(x => x.Route).
                    First(x => x.Id.Equals(id));
                var route = PermanentRoute(user.Routes.ToList());
                var tempRoute = TempRoute(user.Routes.ToList());

                AssignRouteViewModel assignVm = new AssignRouteViewModel()
                {
                    SPName = user.FirstName + " " + user.LastName,
                    SalesPersonId = user.Id,
                    RouteId = route != null ? route.Route.Id : Guid.Empty,
                    TempRouteId = tempRoute != null ? tempRoute.Route.Id : Guid.Empty
                };
                if (!assignVm.TempRouteId.Equals(Guid.Empty))
                {
                    assignVm.TemporaryAssignedTill = tempRoute.TemporaryAssignedTill;
                }


                return PartialView("_EditRoute", assignVm);
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

        //[ModelValidationFilter]
        [HttpPost]
        public async Task<IActionResult> EditSpRouteAsync(AssignRouteViewModel SpRouteDetails)
        {
            try
            {
                var claims = User.Claims.ToArray();
                var currUser = _userManager.Users.Include(x => x.Role).First(x => x.Id.Equals(claims[0].Value));
                var assignedRoutes = _assignedRouteRepo.GetAll().ToList();
                if (SpRouteDetails.RouteId != null)
                {
                    var assignedRoute = assignedRoutes.FirstOrDefault(x =>
                        x.SalesPersonId.Equals(SpRouteDetails.SalesPersonId)
                    && x.TemporaryAssignedTill == null);
                    if (assignedRoute != null)
                    {
                        assignedRoute.RouteId = (Guid)SpRouteDetails.RouteId;
                        _assignedRouteRepo.Update(assignedRoute);
                    }
                    else
                    {
                        var newRouteAssigned = new AssignedRoute()
                        {
                            SalesPersonId = SpRouteDetails.SalesPersonId,
                            RouteId = (Guid)SpRouteDetails.RouteId,
                        };
                        _assignedRouteRepo.Insert(newRouteAssigned);
                    }
                }
                else
                {
                    var assignedRoute = assignedRoutes.FirstOrDefault(x =>
                        x.SalesPersonId.Equals(SpRouteDetails.SalesPersonId)
                       && x.TemporaryAssignedTill == null);
                    if (assignedRoute != null)
                    {
                        _assignedRouteRepo.Delete(assignedRoute);
                    }
                }
                if (SpRouteDetails.TempRouteId != null)
                {
                    var tempRoute = _routesRepo.FindAll(x => x.Id.Equals((Guid)SpRouteDetails.TempRouteId)).Include(x => x.SalesPersons)
                        .ThenInclude(x => x.SalesPerson).FirstOrDefault();
                    var permanentSp = tempRoute.SalesPersons.Where(x => x.TemporaryAssignedTill == null).Select(x => x.SalesPerson).FirstOrDefault();
                    var tempSp = _userManager.Users.FirstOrDefault(x => x.Id.Equals(SpRouteDetails.SalesPersonId)).Email;

                    var assignedRoute = assignedRoutes.FirstOrDefault(x =>
                        x.SalesPersonId.Equals(SpRouteDetails.SalesPersonId)
                        && x.TemporaryAssignedTill.HasValue &&
                        x.TemporaryAssignedTill.Value.Date >= DateTime.Now.Date);
                    if (assignedRoute != null)
                    {
                        assignedRoute.RouteId = (Guid)SpRouteDetails.TempRouteId;
                        assignedRoute.TemporaryAssignedTill = SpRouteDetails.TemporaryAssignedTill.Value;
                        _assignedRouteRepo.Update(assignedRoute);
                    }
                    else
                    {
                        var newRouteAssigned = new AssignedRoute()
                        {
                            SalesPersonId = SpRouteDetails.SalesPersonId,
                            RouteId = (Guid)SpRouteDetails.TempRouteId,
                            TemporaryAssignedTill = SpRouteDetails.TemporaryAssignedTill.Value,
                        };
                        _assignedRouteRepo.Insert(newRouteAssigned);
                    }
                    var span = (SpRouteDetails.TemporaryAssignedTill.Value.Date - DateTime.Now.Date).Days;
                    var msg = span == 0 ? "for today." : span == 1 ? "for 1 day." : $"for {span} days";
                    _notificationService.PushNotification(
                            string.Format(NotificationConstants.TempRouteAssigned, tempRoute.Name, msg),
                            currUser.Id,
                            Url.Action("Routes", "SalesPerson"),
                            null,
                            null,
                            $"{tempSp}"
                        );

                    if (permanentSp != null)
                    {
                        _notificationService.PushNotification(
                            string.Format(NotificationConstants.RouteAssigned, msg),
                            currUser.Id,
                            Url.Action("Routes", "SalesPerson"),
                            null,
                            null,
                            $"{permanentSp.Email}"
                            );
                    }
                }
                else
                {
                    var assignedRoute = assignedRoutes.FirstOrDefault(x =>
                        x.SalesPersonId.Equals(SpRouteDetails.SalesPersonId)
                        && x.TemporaryAssignedTill.HasValue &&
                        x.TemporaryAssignedTill.Value.Date >= DateTime.Now.Date);
                    if (assignedRoute != null)
                    {
                        _assignedRouteRepo.Delete(assignedRoute);
                    }
                }
                await AddLogAsync(LogActions.Update.GetDescription(), SpRouteDetails.SPName + " Route", LogsActionSrc.SPManagement.ToString());

                return Ok(new
                {
                    Message = string.Format(SuccessMessageConstants.UpdateSuccess, "Salesperson Route")
                });
            }
            catch (Exception ex)
            {
                LogException(ex);
                return BadRequest(new
                {
                    Message = string.Format(ErrorMessageConstants.UpdateFail, "Salesperson Route")
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatusAsync(string id)
        {
            try
            {
                bool check = false; ;
                var user = _userManager.Users.Include(x => x.Routes).ThenInclude(x => x.Route).First(x => x.Id.Equals(id));
                var tempAssignedRoute = TempRoute(user.Routes.ToList());
                if (tempAssignedRoute != null)
                {
                    var route = tempAssignedRoute.Route;
                    route.IsActive = route.IsActive ? false : true;
                    check = route.IsActive;
                    _routesRepo.Update(route);
                }
                var assignedRoute = PermanentRoute(user.Routes.ToList());
                if (assignedRoute != null)
                {
                    var route = assignedRoute.Route;
                    if (tempAssignedRoute != null)
                    {
                        if (!route.IsActive.Equals(check))
                        {
                            route.IsActive = check;
                            _routesRepo.Update(route);
                        }
                    }
                    else
                    {
                        route.IsActive = route.IsActive ? false : true;
                        check = route.IsActive;
                        _routesRepo.Update(route);
                    }

                }
                if (assignedRoute == null && tempAssignedRoute == null)
                {
                    return BadRequest(new
                    {
                        Message = "No route is assigned to salesperson."
                    });
                }
                var Message = string.Empty;
                if ((bool)check)
                {
                    Message = string.Format(SuccessMessageConstants.ActiveSuccess, "Route");
                }
                else
                {
                    Message = string.Format(SuccessMessageConstants.InactiveSuccess, "Route");
                }
                await AddLogAsync(LogActions.ChangeStatus.GetDescription(), user.Email + " Route", LogsActionSrc.SPManagement.ToString());

                return Ok(new { Message });
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

        [HttpPost]
        public JsonResult CheckDate(Guid TempRouteId, DateTime? TemporaryAssignedTill)
        {
            if (!TempRouteId.Equals(Guid.Empty))
            {
                if (!TemporaryAssignedTill.HasValue)
                {
                    return Json(false);
                }
                return Json(true);
            }
            return Json(false);
        }

        [HttpPost]
        public JsonResult CorrectDate(DateTime? TemporaryAssignedTill)
        {
            if (TemporaryAssignedTill.HasValue)
            {
                if (TemporaryAssignedTill.Value.Date < DateTime.Today)
                {
                    return Json(false);
                }
                return Json(true);
            }
            return Json(false);
        }


        public IActionResult Details(string id)
        {
            var user = _userManager.Users.Include(x => x.Orders).ThenInclude(x => x.Customer)
                .Include(x => x.Routes).ThenInclude(x => x.Route).ThenInclude(x => x.Customers.
                Where(y => y.DeletedAt == null && y.IsActive)).First(x => x.Id.Equals(id));

            SpDetailsPageModel model = new SpDetailsPageModel()
            {
                Id = id,
                FullName = user.FirstName + " " + user.LastName
            };
            //ViewBag.Id = id;
            //ViewBag.Name = user.FirstName + " " + user.LastName;
            var customers = user.Routes != null && user.Routes.Count > 0 ?
                    SpRouteCustomers(user.Routes.ToList()) : new List<Customer>();
            var customersWithRoutes = customers.Where(x => (x.Latitude != null && x.Latitude != "0") &&
                (x.Longitude != null && x.Longitude != "0"));
            model.Customers = customers.Where(x => (!string.IsNullOrEmpty(x.Latitude) && x.Latitude != "0") &&
                (!string.IsNullOrEmpty(x.Longitude) && x.Longitude != "0") && (x.Longitude.IsFloatOrInt() && x.Latitude.IsFloatOrInt())).OrderBy(x => x.Latitude).ThenBy(x => x.Longitude).Select(x => new CustomerInfo
                {
                    Address1 = x.Address1,
                    FullName = x.BusinessName,
                    Longitude = x.Longitude,
                    Latitude = x.Latitude,
                }).ToList();

            model.Orders = user.Orders.Where(x => !string.IsNullOrEmpty(x.Latitude) && !string.IsNullOrEmpty(x.Longitude)
            && x.Longitude != "0" && x.Latitude != "0" && x.DeletedAt == null && !x.IsMarked && x.CreatedAt.Date.Equals(DateTime.Today.Date)
            && (x.Longitude.IsFloatOrInt() && x.Latitude.IsFloatOrInt()))
                .Select(x => new OrderInfo
                {
                    Address1 = x.Customer.Address1,
                    FullName = x.Customer.BusinessName,
                    Longitude = x.Longitude,
                    Latitude = x.Latitude,
                }).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult SpRouteOrders()
        {
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["order[0][column]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault()?.Trim().Trim() ?? Request.Form["search"].FirstOrDefault().Trim().Trim();
                var id = Request.Form["id"].FirstOrDefault();
                int pageSize = Convert.ToInt32(length ?? "0");
                int skip = Convert.ToInt32(start ?? "0");
                int recordsTotal = 0;

                var sp = _userManager.Users.Include(x => x.Routes).Where(x => x.Id.Equals(id)).First();
                var spRoutes = GetAllSpRoutes(sp.Routes.ToList()).Select(x => x.RouteId).ToList();
                if (spRoutes.Count > 0)
                {
                    var customers = _customerRepo.FindAll(x => x.DeletedAt == null
                    && x.IsActive && x.Orders.Count > 0 && x.Orders.Any(y => !y.IsMarked && y.CreatedAt.Date.Equals(DateTime.Today.Date)
                      && y.DeletedAt == null)).Include(x => x.Payments).
                    Include(x => x.Orders).ThenInclude(x => x.Orders).
                    Include(x => x.Orders).ThenInclude(x => x.ReturnOrders).ToList();

                    var customerData = customers.Where(x => spRoutes.Contains(x.RouteId.ToGuid())).Select(x => new SpCustomers
                    {
                        Name = x.BusinessName,
                        CustomerLatitude = x.Latitude,
                        CustomerLongitude = x.Longitude,
                        Orders = GetTodaysOrders(x),
                        OrderLongitude = x.Orders.Where(y => !y.IsMarked && y.DeletedAt == null &&
                        y.CreatedAt.Date.Equals(DateTime.Now.Date) && !string.IsNullOrEmpty(y.Latitude) &&
                        !y.Latitude.Equals("0")).FirstOrDefault() != null ? x.Orders.Where(y => !y.IsMarked && y.DeletedAt == null
                        && y.CreatedAt.Date.Equals(DateTime.Now.Date) && !string.IsNullOrEmpty(y.Latitude)
                        && !y.Latitude.Equals("0")).FirstOrDefault().Longitude : "0",
                        OrderLatitude = x.Orders.Where(y => !y.IsMarked && y.DeletedAt == null &&
                        y.CreatedAt.Date.Equals(DateTime.Now.Date) && !string.IsNullOrEmpty(y.Latitude) &&
                        !y.Latitude.Equals("0")).FirstOrDefault() != null ? x.Orders.Where(y => !y.IsMarked && y.DeletedAt == null
                        && y.CreatedAt.Date.Equals(DateTime.Now.Date) && !string.IsNullOrEmpty(y.Latitude)
                        && !y.Latitude.Equals("0")).FirstOrDefault().Latitude : "0",
                        Time = x.Orders.FirstOrDefault().CreatedAt,
                    }).OrderBy(x => x.Time);

                    if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                    {
                        int column = int.Parse(sortColumn);
                        switch (column)
                        {

                            case 1:
                                customerData = ((sortColumnDirection == "asc" ? customerData.OrderBy(c => c.Name)
                                    : customerData.OrderByDescending(c => c.Name)));
                                break;
                        }
                    }
                    if (!string.IsNullOrEmpty(searchValue))
                    {
                        customerData = customerData.Where(m => m.Name.Contains(searchValue, StringComparison.OrdinalIgnoreCase)
                                            || (string.IsNullOrEmpty(m.Orders)
                                            && m.Orders.Contains(searchValue, StringComparison.OrdinalIgnoreCase))).
                                            OrderBy(x => x.Time);
                    }

                    recordsTotal = customerData.Count();
                    var data = customerData.Skip(skip).Take(pageSize).ToList();
                    return Json(new { draw, recordsFiltered = recordsTotal, recordsTotal, data });
                }
                recordsTotal = 0;


                return Json(new { draw, recordsFiltered = recordsTotal, recordsTotal, data = new List<SpCustomers>() });

            }
            catch (Exception ex)
            {
                LogException(ex);
                return null;
            }
        }
        [NonAction]
        public string GetTodaysOrders(Customer customer)
        {
            List<string> spOrders = new List<string>();
            var orders = customer.Orders.Where(x => x.CreatedAt.Date.Equals(DateTime.Today.Date) && !x.IsMarked && x.DeletedAt == null).ToList();
            if (orders.Any(x => x.Orders.Count > 0))
            {
                spOrders.Add("Sales");
            }
            else if (orders.Any(x => x.ReturnOrders.Count == 0))
            {
                spOrders.Add("Empty");
            }
            if (customer.Payments != null && customer.Payments.Any(x => x.DeletedAt == null && !x.IsMarked &&
               x.ReceivedAt.Date.Equals(DateTime.Today.Date)))
            {
                spOrders.Add("Payment");
            }
            if (spOrders.Count > 0)
            {
                return string.Join(", ", spOrders);
            }
            return "";
        }

        [HttpGet]
        [TypeFilter(typeof(AdminAccessFilter))]
        public IActionResult SettlementSheet()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Deliveries()
        {
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["order[0][column]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault()?.Trim().Trim() ?? Request.Form["search"].FirstOrDefault().Trim().Trim();
                int pageSize = Convert.ToInt32(length ?? "0");
                int skip = Convert.ToInt32(start ?? "0");
                int recordsTotal = 0;
                var date = Request.Form["columns[3][search][value]"].FirstOrDefault();
                var dateTime = date == "" ? DateTime.Today : Convert.ToDateTime(date);

                var deliveries = _deliveryReportRepo.FindAll(x => x.DeletedAt == null && x.CreatedAt.Date.Equals(dateTime.Date)).OrderBy(x => x.CreatedAt)
                    .Include(x => x.Route)
                    .Include(x => x.SalesPerson).Select(x => new
                    {
                        x.Id,
                        Route = x.Route.Name,
                        CreatedAt = x.CreatedAt.ToString("dd/MM/yyy HH:mm:ss"),
                        SalesPersonName = x.SalesPerson.FirstName + " " + x.SalesPerson.LastName,
                        x.SalesPerson.Email
                    }).AsNoTracking().ToList();
                if (deliveries.Count > 0)
                {
                    if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                    {
                        int column = int.Parse(sortColumn);
                        switch (column)
                        {
                            case 0:
                                deliveries = (sortColumnDirection == "asc" ? deliveries.OrderBy(c => c.SalesPersonName)
                                    : deliveries.OrderByDescending(c => c.SalesPersonName)).ToList();
                                break;

                            case 1:
                                deliveries = ((sortColumnDirection == "asc" ? deliveries.OrderBy(c => c.Email)
                                    : deliveries.OrderByDescending(c => c.Email))).ToList();
                                break;

                            case 2:
                                deliveries = ((sortColumnDirection == "asc" ? deliveries.OrderBy(c => c.Route)
                                    : deliveries.OrderByDescending(c => c.Route))).ToList();
                                break;

                            case 3:
                                deliveries = ((sortColumnDirection == "asc" ? deliveries.OrderBy(c => c.CreatedAt)
                                    : deliveries.OrderByDescending(c => c.CreatedAt))).ToList();
                                break;
                        }
                    }
                    if (!string.IsNullOrEmpty(searchValue))
                    {
                        deliveries = deliveries.Where(m => m.SalesPersonName.Contains(searchValue, StringComparison.OrdinalIgnoreCase)
                                            || (m.Email.Contains(searchValue, StringComparison.OrdinalIgnoreCase))
                                            || (m.Route.Contains(searchValue, StringComparison.OrdinalIgnoreCase))).ToList();
                    }

                    recordsTotal = deliveries.Count();
                    var data = deliveries.Skip(skip).Take(pageSize).ToList();
                    return Json(new { draw, recordsFiltered = recordsTotal, recordsTotal, data });
                }
                return Json(new { draw = 0, recordsFiltered = 0, recordsTotal = 0, data = deliveries });

            }

            catch (Exception ex)
            {
                LogException(ex);
                return null;
            }
        }

        public IActionResult SettlementSheetDetails(string id)
        {
            var model = GetReport(id);
            return View(model);
        }
        [NonAction]
        public DeliveryReportViewModel DeliveryReportCalculations(List<Order> orders, Guid routeId, DateTime time, string spId)
        {
            double price = 0;
            double gross = 0;
            double returnAmount = 0;
            DeliveryReportViewModel detail = new DeliveryReportViewModel
            {
                OrderProducts = new List<OrderProducts>(),
                Orders = new List<Orders>(),
            };
            Orders singleOrder = new Orders();
            OrderProducts productDetails = new OrderProducts();
            var productName = string.Empty;
            var discount = 0.0;
            var productsDiscount = 0.0;

            foreach (var order in orders)
            {
                singleOrder = new Orders
                {
                    Id = order.Id,
                    Code = !string.IsNullOrEmpty(order.OrderCode) ? order.OrderCode : "---"
                };
                gross = 0;
                returnAmount = 0;
                price = 0;
                productName = string.Empty;
                discount = 0.0;
                productsDiscount = 0.0;
                if (order.Orders.Count > 0)
                {
                    foreach (var orderDetail in order.Orders)
                    {
                        discount = orderDetail.Discount;
                        productsDiscount += (discount * orderDetail.Quantity);
                        price = orderDetail.Price;
                        gross = price * orderDetail.Quantity;
                        singleOrder.Gross += gross;
                        singleOrder.Total += gross;
                        var prevProductDetails = detail.OrderProducts.FirstOrDefault(x => x.ProductId.Equals(orderDetail.ProductId));
                        if (prevProductDetails != null)
                        {
                            prevProductDetails.Quantity += orderDetail.Quantity;
                            prevProductDetails.Gross += gross;
                            prevProductDetails.Price = prevProductDetails.Price == 0 ? orderDetail.Price : prevProductDetails.Price;
                        }
                        else
                        {
                            if (orderDetail.Product.ProductId != null)
                            {
                                productName = orderDetail.Product.VariantOf.Name + " - " + orderDetail.Product.Name;
                            }
                            else
                            {
                                productName = orderDetail.Product.Name;
                            }
                            productDetails = new OrderProducts()
                            {
                                ProductName = productName,
                                Gross = gross,
                                Price = price,
                                Quantity = orderDetail.Quantity,
                                ProductId = orderDetail.ProductId,
                                ProductCode = orderDetail.Product.AxCode
                            };
                            detail.OrderProducts.Add(productDetails);
                        }
                    }
                }
                if (order.ReturnOrders.Count > 0)
                {
                    foreach (var orderDetail in order.ReturnOrders)
                    {
                        discount = orderDetail.Discount;
                        price = (float)orderDetail.Price;
                        returnAmount = (price - discount) * orderDetail.Quantity;
                        singleOrder.Total -= returnAmount;
                        singleOrder.Return -= returnAmount;
                        var prevProductDetails = detail.OrderProducts.FirstOrDefault(x => x.ProductId.Equals(orderDetail.ProductId));
                        if (prevProductDetails != null)
                        {
                            prevProductDetails.ReturnQuantity += orderDetail.Quantity;
                        }
                        else
                        {
                            if (orderDetail.Product.ProductId != null)
                            {
                                productName = orderDetail.Product.VariantOf.Name + " - " + orderDetail.Product.Name;
                            }
                            else
                            {
                                productName = orderDetail.Product.Name;
                            }
                            productDetails = new OrderProducts()
                            {
                                ProductName = productName,
                                Price = price,
                                ProductId = orderDetail.ProductId,
                                ReturnQuantity = orderDetail.Quantity,
                                ProductCode = orderDetail.Product.AxCode
                            };
                            detail.OrderProducts.Add(productDetails);
                        }
                    }
                }
                if (order.WasteOrders.Count > 0)
                {
                    foreach (var orderDetail in order.WasteOrders)
                    {
                        discount = orderDetail.Discount;
                        price = (float)orderDetail.Price;
                        returnAmount = (price - discount) * orderDetail.Quantity;
                        singleOrder.Total -= returnAmount;
                        singleOrder.Return -= returnAmount;
                        var prevProductDetails = detail.OrderProducts.FirstOrDefault(x => x.ProductId.Equals(orderDetail.ProductId));
                        if (prevProductDetails != null)
                        {
                            prevProductDetails.WasteQuantity += orderDetail.Quantity;
                        }
                        else
                        {
                            if (orderDetail.Product.ProductId != null)
                            {
                                productName = orderDetail.Product.VariantOf.Name + " - " + orderDetail.Product.Name;
                            }
                            else
                            {
                                productName = orderDetail.Product.Name;
                            }
                            productDetails = new OrderProducts()
                            {
                                ProductName = productName,
                                Price = price,
                                ProductId = orderDetail.ProductId,
                                WasteQuantity = orderDetail.Quantity,
                                ProductCode = orderDetail.Product.AxCode
                            };
                            detail.OrderProducts.Add(productDetails);
                        }
                    }
                }
                discount = order.Discount;
                singleOrder.Discount += discount;
                singleOrder.Total = singleOrder.Total - productsDiscount < 0 ? singleOrder.Total - productsDiscount + singleOrder.Discount : singleOrder.Total - productsDiscount - singleOrder.Discount;
                singleOrder.Discount += productsDiscount;
                singleOrder.BusinessName = order.Customer.BusinessName;
                singleOrder.CustomerCode = string.IsNullOrEmpty(order.Customer.AxCode) ? "---" : order.Customer.AxCode;
                detail.Total += singleOrder.Total;
                detail.TotalReturn += singleOrder.Return;
                detail.TotalGross += singleOrder.Gross;
                detail.TotalDiscount += singleOrder.Discount;
                detail.Orders.Add(singleOrder);
                //if (order.PaymentId != null && !order.Payment.IsMarked && order.Payment.DeletedAt==null)
                //{
                //    detail.TotalCash += order.Payment.PaymentReceived;
                //    detail.TotalBalance += singleOrder.Total - order.Payment.PaymentReceived;
                //}
            }
            var prices = _priceRepo.FindAll(x => x.From.Date <= time.Date).ToList();
            detail.Dispatch = 0;
            detail.Unsold = 0;
            if (routeId != null)
            {
                var stocksTransferred = _transferStockRepo.FindAll(x => x.CreatedAt.Date.Equals(time.Date) && x.RouteId.Equals(routeId))
                    .Include(x => x.AssignStocks).FirstOrDefault();
                if (stocksTransferred != null && stocksTransferred.AssignStocks.Count > 0)
                {
                    foreach (var stock in stocksTransferred.AssignStocks)
                    {
                        var prodPrice = prices.OrderByDescending(x => x.From).FirstOrDefault(x => x.ProductId.Equals(stock.ProductId))?.Price ?? 0;
                        detail.Dispatch += prodPrice * stock.Quantity;
                    }
                    detail.Unsold = detail.Dispatch - detail.TotalGross;
                    detail.Unsold = detail.Unsold < 0 ? 0 : detail.Unsold;
                }
            }
            var payments = _paymentRepo.FindAll(x => !x.IsMarked && x.DeletedAt == null &&
                x.ReceivedAt.Date.Equals(time.Date) && x.SalesPersonId.Equals(spId)).Include(x => x.Customer);
            detail.Payments = new List<Payments>();
            foreach (var payment in payments)
            {
                detail.TotalCash += payment.PaymentReceived;
                detail.Payments.Add(new Payments
                {
                    PaymentId = payment.Id,
                    BusinessName = payment.Customer.BusinessName,
                    Payment = payment.PaymentReceived,
                    PaymentCode = payment.PaymentCode,
                    CustomerCode = string.IsNullOrEmpty(payment.Customer.AxCode) ? "---" : payment.Customer.AxCode,
                });
            }

            var assignedStocks = _transferStockRepo.FindAll(x => x.RouteId.Equals(routeId) && x.DeletedAt == null
            && x.Status && x.CreatedAt.Date.Equals(time.Date)).Include(x => x.AssignStocks).ThenInclude(x => x.Product)
            .ThenInclude(x => x.Category).Include(x => x.AssignStocks).ThenInclude(x => x.Product).ThenInclude(x => x.VariantOf)
            .FirstOrDefault()?.AssignStocks;

            if (assignedStocks != null)
            {
                foreach (var product in assignedStocks)
                {
                    var assignedProduct = detail.OrderProducts.Where(x => x.ProductCode.Equals(product.Product.AxCode)).FirstOrDefault();
                    if (assignedProduct != null)
                    {
                        assignedProduct.Assigned = product.Quantity;
                    }
                    else
                    {
                        detail.OrderProducts.Add(new OrderProducts()
                        {
                            Assigned = product.Quantity,
                            ProductCode = product.Product.AxCode,
                            ProductId = product.ProductId,
                            Gross = 0,
                            ReturnQuantity = 0,
                            WasteQuantity = 0,
                            ProductName = product.Product.ProductId != null ? product.Product.Category.Name
                            + "-" + product.Product.VariantOf.Name + "-" + product.Product.Name :
                             product.Product.Category.Name + "-" + product.Product.Name,
                            Quantity = 0,
                            Price = _priceRepo.FindAll(x => x.ProductId.Equals(product.ProductId) && x.From.Date <= time.Date).OrderByDescending(x => x.From).FirstOrDefault()?.Price ?? 0
                        });
                    }
                }
            }

            return detail;
        }

        public IActionResult SettlementSheetInvoice(string id)
        {
            try
            {
                var model = GetReport(id);
                var terms = _configRepo.Get(AppConstants.TermsConditions);
                var file = _invoiceService.DeliveryReportyInvoice(model, terms.Value);
                if (file != null)
                {
                    return File(fileStream: file, contentType: "application/pdf", fileDownloadName: "SettlementSheet-" + id + ".pdf");
                }
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ex
                });
            }
        }

        public IActionResult SettlementSheetWHInvoice(string id)
        {
            try
            {
                var model = GetReport(id);
                var terms = _configRepo.Get(AppConstants.TermsConditions);
                var file = _invoiceService.SettlementSheetInvoice(model, terms.Value);
                if (file != null)
                {
                    return File(fileStream: file, contentType: "application/pdf", fileDownloadName: "SettlementSheet-" + id + ".pdf");
                }
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ex
                });
            }
        }
        [NonAction]
        public DeliveryReportViewModel GetReport(string id)
        {
            var report = _deliveryReportRepo.FindAll(x => x.Id.Equals(new Guid(id)))
             .Include(x => x.SalesPerson).ThenInclude(x => x.ProfileImage)
             .Include(x => x.SalesPerson).ThenInclude(x => x.Orders).ThenInclude(x => x.Customer)
             .Include(x => x.SalesPerson).ThenInclude(x => x.Orders).ThenInclude(x => x.ReturnOrders)
             .ThenInclude(x => x.Product).ThenInclude(x => x.VariantOf)
             .Include(x => x.SalesPerson).ThenInclude(x => x.Orders).ThenInclude(x => x.ReturnOrders)
             .ThenInclude(x => x.Product).ThenInclude(x => x.Category)
             .Include(x => x.SalesPerson).ThenInclude(x => x.Orders).ThenInclude(x => x.Orders)
             .ThenInclude(x => x.Product).ThenInclude(x => x.VariantOf)
             .Include(x => x.SalesPerson).ThenInclude(x => x.Orders).ThenInclude(x => x.Payment)
             .Include(x => x.SalesPerson).ThenInclude(x => x.Orders).ThenInclude(x => x.Orders)
             .ThenInclude(x => x.Product).ThenInclude(x => x.Category)
             .Include(x => x.SalesPerson).ThenInclude(x => x.Orders).ThenInclude(x => x.WasteOrders)
             .ThenInclude(x => x.Product).ThenInclude(x => x.VariantOf)
             .Include(x => x.SalesPerson).ThenInclude(x => x.Orders).ThenInclude(x => x.WasteOrders)
             .ThenInclude(x => x.Product).ThenInclude(x => x.Category)
             .Include(x => x.Route)
             .Include(x => x.Vehicle).AsNoTracking().FirstOrDefault();

            var orders = report.SalesPerson.Orders.Where(x => x.DeletedAt == null && !x.IsMarked &&
                x.CreatedAt.Date.Equals(report.CreatedAt.Date)).ToList();
            DeliveryReportViewModel model = DeliveryReportCalculations(orders, (Guid)report.RouteId, report.CreatedAt, report.SalesPersonId);
            model.Id = report.Id;
            model.IsMarked = report.IsMarked;
            model.RouteName = report.RouteId != null ? report.Route.Name : "---";
            model.SalesPersonName = report.SalesPerson.FirstName + " " + report.SalesPerson.LastName;
            model.ProfilePicture = report.SalesPerson.ProfileImage;
            model.VehicleNumber = report.VehicleId != null ? report.Vehicle.VehicleNumber : "---";
            model.DriverName = report.DriverName ?? "---";
            model.CreatedAt = report.CreatedAt;
            model.CashShort = report.CashShort;
            return model;
        }

        public IActionResult ChangeReportStatus(Guid id)
        {
            try
            {
                var report = _deliveryReportRepo.Get(id);
                report.IsMarked = !report.IsMarked;
                _deliveryReportRepo.Update(report);
                var status = "approved";
                if (!report.IsMarked)
                {
                    status = "disapproved";
                }
                return Ok(new
                {
                    Message = "Report " + status + " successfully"
                });
            }
            catch (Exception ex)
            {
                LogException(ex);
                return BadRequest(new
                {
                    Message = "Failed to mark report"
                });
            }

        }
        public IActionResult EditCashShort(string id, double amount)
        {
            ViewData["Title"] = "Settlement Sheet";
            ViewData["PageTitle"] = "Short Cash Submission";
            try
            {
                var report = _deliveryReportRepo.FindBy(x => x.Id.Equals(new Guid(id)));
                CashShortViewModel model = new CashShortViewModel()
                {
                    ReportId = report.Id,
                    CashShort = report.CashShort,
                    Recievable = amount
                };
                return PartialView("_CashShort", model);
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
        [HttpPost]
        [ModelValidationFilter]
        public IActionResult UpdateShortCash(string id, double amount)
        {
            ViewData["Title"] = "Settlement Sheet";
            ViewData["PageTitle"] = "Short Cash Submission";
            try
            {
                var report = _deliveryReportRepo.FindBy(x => x.Id.Equals(new Guid(id)));
                report.CashShort = amount;
                _deliveryReportRepo.Update(report);
                return Ok(new
                {
                    Message = string.Format(SuccessMessageConstants.UpdateSuccess, "Cash Short")
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
    }
}