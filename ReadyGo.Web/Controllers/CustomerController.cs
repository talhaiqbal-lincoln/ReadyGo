using AutoMapper;
using LINQtoCSV;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadyGo.Domain.Constants;
using ReadyGo.Domain.Entities;
using ReadyGo.Domain.Entities.Identity;
using ReadyGo.Domain.Entities.ViewModels;
using ReadyGo.Domain.Enum;
using ReadyGo.Infrastructure.Extension;
using ReadyGo.Infrastructure.Filters;
using ReadyGo.Service.Interfaces;
using ReadyGo.Service.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReadyGo.Persistence.Seeds;
using System.Globalization;

namespace ReadyGo.Web.Controllers
{
    [Authorize]
    [TypeFilter(typeof(AuthorizationFilter))]
    public class CustomerController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Customer> _customerRepo;
        private readonly IValidationHelper _validationHelper;
        private readonly IGenericRepository<ApplicationRole> _rolesRepo;
        private readonly IGenericRepository<Route> _routesRepo;
        private readonly INotificationService _notificationService;
        private readonly IGenericRepository<Order> _orderRepo;
        private readonly IGenericRepository<Payment> _paymentRepo;

        public CustomerController(IValidationHelper validationHelper, IMapper mapper,
            IGenericRepository<Route> routesRepo, IGenericRepository<Customer> custRepo,
            IGenericRepository<ApplicationRole> rolesRepo, IGenericRepository<Order> orderRepo,
            INotificationService notificationService, IGenericRepository<Payment> paymentRepo)
        {
            _orderRepo = orderRepo;
            _paymentRepo = paymentRepo;
            _routesRepo = routesRepo;
            _validationHelper = validationHelper;
            _customerRepo = custRepo;
            _rolesRepo = rolesRepo;
            _mapper = mapper;
            _notificationService = notificationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AllCustomers()
        {
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var status = Request.Form["status"].FirstOrDefault();
                var activeStatus = Request.Form["activeStatus"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["order[0][column]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault()?.Trim().Trim() ?? "";
                var flag = Request.Form["flag"].FirstOrDefault();
                int pageSize = Convert.ToInt32(length ?? "0");
                int skip = Convert.ToInt32(start ?? "0");
                int recordsTotal = 0;

                var customers = _customerRepo.FindAll(x => x.DeletedAt == null).
                    Include(x => x.ProfilePicture).ToList();
                var assignedRoutes = _assignedRouteRepo.FindAll(x => x.TemporaryAssignedTill == null ||
                    x.TemporaryAssignedTill.Value.Date >= DateTime.Now.Date).Include(x => x.SalesPerson).Include(x => x.Route).ToList();
                var routes = _routesRepo.GetAll().ToList();

                if (status == "Synced")
                    customers = customers.Where(x => x.SyncedAt != null).ToList();
                else if (status == "UnSynced")
                    customers = customers.Where(x => x.SyncedAt == null).ToList();
                if (activeStatus == "Active")
                    customers = customers.Where(x => x.IsActive).ToList();
                else if (activeStatus == "InActive")
                    customers = customers.Where(x => !x.IsActive).ToList();

                var customerData = customers.Select(x => new CustomerTableViewModel
                {
                    AxCode = x.AxCode,
                    ProfileImage = x.ProfilePicture != null ? "data:image;base64," +
                        Convert.ToBase64String(x.ProfilePicture.File) : "/resource_files/default_user.jpg",
                    Id = x.Id,
                    Email = string.IsNullOrEmpty(x.Email) ? "---" : x.Email,
                    Name = x.FirstName + " " + x.LastName,
                    BusinessName = x.BusinessName,
                    AssignedSP = x.RouteId != null ? RouteSp(assignedRoutes.Where(y => y.RouteId.Equals(x.RouteId)).ToList()) : "Not Assigned",
                    SyncStatus = x.SyncedAt != null ? "Synced" : "UnSynced",
                    IsActive = x.IsActive,
                    RouteName = x.RouteId != null ? routes.Where(y => y.Id.Equals(x.RouteId)).Select(z => z.Name).First() : string.Empty
                });

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    int column = Int32.Parse(sortColumn);
                    switch (column)
                    {
                        case 1:
                            customerData = (sortColumnDirection == "asc" ? customerData.OrderBy(c => c.AxCode) :
                              customerData.OrderByDescending(c => c.AxCode));
                            break;
                        case 2:
                            customerData = (sortColumnDirection == "asc" ? customerData.OrderBy(c => c.BusinessName) :
                                customerData.OrderByDescending(c => c.BusinessName));
                            break;

                        case 3:
                            customerData = sortColumnDirection == "asc" ? customerData.OrderBy(c => c.Name) :
                                customerData.OrderByDescending(c => c.Name);
                            break;

                        case 4:
                            customerData = sortColumnDirection == "asc" ? customerData.OrderBy(c => c.Email) :
                                customerData.OrderByDescending(c => c.Email);
                            break;
                    }
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.Name.Contains(searchValue, StringComparison.OrdinalIgnoreCase)
                                        || (!string.IsNullOrEmpty(m.BusinessName) && m.BusinessName.Contains(searchValue, StringComparison.OrdinalIgnoreCase))
                                        || (!string.IsNullOrEmpty(m.Email) && m.Email.Contains(searchValue, StringComparison.OrdinalIgnoreCase))
                                        || (!string.IsNullOrEmpty(m.AssignedSP) && m.AssignedSP.Contains(searchValue, StringComparison.OrdinalIgnoreCase))
                                        || !string.IsNullOrEmpty(m.AxCode) && m.AxCode.Contains(searchValue, StringComparison.OrdinalIgnoreCase)
                                        || !string.IsNullOrEmpty(m.RouteName) && m.RouteName.Contains(searchValue, StringComparison.OrdinalIgnoreCase));
                }
                recordsTotal = customerData.Count();
                var data = customerData.Skip(skip).Take(pageSize).ToList();

                return Json(new { draw, recordsFiltered = recordsTotal, recordsTotal, data });
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw;
            }
        }

        /// <summary>
        /// Get method for adding user
        /// Same page is used for editing the user therefore the action of the form is specified in ViewBag
        /// </summary>
        /// <returns>Specifies addition to the form that the action will be to add the user</returns>
        public IActionResult AddCustomer()
        {
            var routes = _routesRepo.GetAll().Include(x => x.SalesPersons).ThenInclude(x => x.SalesPerson).ToList();
            var routesView = routes.Select(x => new
            {
                x.Name,
                x.Id,
                SPName = RouteSp(x.SalesPersons.ToList())
            });
            ViewBag.Routes = routesView.OrderBy(x => x.Name);
            CustomerViewModel customer = new CustomerViewModel();
            ViewData["Title"] = "Add Customer";
            ViewBag.flag = "Add";
            return View(customer);
        }

        /// <summary>
        /// Post method for user addition
        /// </summary>
        /// <param name="customerModel">User to be added</param>
        /// <param name="file">User's profile picture</param>
        /// <returns></returns>
        [HttpPost]
        [ModelValidationFilter]
        public async Task<IActionResult> AddCustomers(CustomerViewModel customerModel, IFormFile file)
        {
            var claims = User.Claims.ToArray();
            var currUser = _userManager.Users.Include(x => x.Role).First(x => x.Id.Equals(claims[0].Value));
            try
            {
                //customerModel.PhoneNumber = customerModel.PhoneNumber;
                var customer = _mapper.Map<Customer>(customerModel);
                customer.CreatedById = currUser.Id;
                _customerRepo.Insert(customer);
                if (file != null)
                {
                    if (file.Length > 0 && file.ContentType.Contains("image"))
                    {
                        ResourceFile resultImage = _imageHelper.SaveReshape(file, customer.Id.ToString());
                        if (resultImage != null)
                        {
                            _imgRepo.Insert(resultImage);
                            customer.ProfilePicture = resultImage;
                            _customerRepo.Update(customer);
                        }
                    }
                }
                await AddLogAsync(LogActions.Add.GetDescription(), customer.BusinessName, LogsActionSrc.CustomerManagement.ToString());
                _notificationService.PushNotification(
                    string.Format(NotificationConstants.CustomerAdded, customer.BusinessName, currUser.Email, currUser.Role.Name),
                    currUser.Id,
                    Url.Action("ViewCustomer", "Customer", new { cust_id = customer.Id }),
                    NotficationEnums.CustomerAdded.ToString(),
                    $"{Roles.Admin.GetDescription()},{Roles.SalesManager.GetDescription()},{Roles.MarketingManager.GetDescription()}",
                    null);
                return Ok(new
                {
                    Message = string.Format(SuccessMessageConstants.CreateSuccess, "Customer")
                });
            }
            catch (Exception ex)
            {
                LogException(ex);
                return BadRequest(new
                {
                    Message = string.Format(ErrorMessageConstants.CreateFail, "Customer")
                });
            }
        }

        [HttpGet]
        public IActionResult ViewCustomer(string cust_id)
        {
            ViewData["Title"] = "Customer Management";
            ViewData["PageTitle"] = "Customer Details";

            var customer = _customerRepo.FindAll(x => x.Id.Equals(new Guid(cust_id))).
                Include(x => x.ProfilePicture).Include(x => x.Route).
                ThenInclude(x => x.SalesPersons).ThenInclude(x => x.SalesPerson).Include(x => x.CreatedBy).
                First();

            ViewBag.Sp = customer.Route != null ? RouteSp(customer.Route.SalesPersons.ToList()) : "Not Assigned";
            if (customer.DeletedAt == null)
                return View(customer);
            else
            {
                TempData["Message"] = "Customer";
                return RedirectToAction("RecordDeleted", "Home");
            }
        }

        [HttpGet]
        public IActionResult EditCustomer(string id)
        {
            ViewData["Title"] = "Customer Management";
            ViewData["PageTitle"] = "Edit Customer";
            ViewBag.Action = "EditCustomer";
            ViewBag.flag = "Edit";
            Guid cust_id = new Guid(id);
            var customer = _customerRepo.FindAll(x => x.Id.Equals(cust_id))
                .Include(x => x.ProfilePicture)
                .Include(x => x.Route)
                .ThenInclude(x => x.SalesPersons)
                .ThenInclude(x => x.SalesPerson).
                First();
            var model = _mapper.Map<CustomerViewModel>(customer);
            var routes = _routesRepo.GetAll().Include(x => x.SalesPersons).ThenInclude(x => x.SalesPerson).ToList();
            var routesData = routes.Select(x => new
            {
                x.Name,
                x.Id,
                SPName = RouteSp(x.SalesPersons.ToList())
            }).ToList();
            ViewBag.Routes = routesData.OrderBy(x => x.Name);
            var spName = customer.Route != null ? RouteSp(customer.Route.SalesPersons.ToList()) : "Not Assigned";
            ViewBag.SPName = spName == " " ? "---" : spName;
            ViewData["Title"] = "Edit Customer";
            return View("AddCustomer", model);
        }

        /// <summary>
        /// Method for editing customer
        /// </summary>
        /// <param name="customerModel">Customer with updated properties</param>
        /// <param name="file">User's new profile picture</param>
        /// <returns>Back to customer's home page</returns>
        [HttpPost]
        [ModelValidationFilter]
        public async Task<IActionResult> EditCustomerAsync(CustomerViewModel customerModel, IFormFile file)
        {
            try
            {
                if (!string.IsNullOrEmpty(customerModel.Email))
                {
                    customerModel.Email = customerModel.Email.Trim().ToLower();
                }
                var customer = _customerRepo.FindAll(x => x.Id.Equals(customerModel.Id)).
                    Include(x => x.ProfilePicture).First();
                _mapper.Map<CustomerViewModel, Customer>(customerModel, customer);
                if (file != null)
                {
                    if (file.Length > 0 && file.ContentType.Contains("image"))
                    {
                        ResourceFile resultImage = _imageHelper.SaveReshape(file, customer.Id.ToString());
                        if (resultImage != null)
                        {
                            if (customer.ProfilePicture == null)
                            {
                                _imgRepo.Insert(resultImage);
                                customer.PictureId = resultImage.Id;
                            }
                            else
                            {
                                customer.ProfilePicture.File = resultImage.File;
                                _imgRepo.Update(customer.ProfilePicture);
                            }
                        }
                    }
                }
                customer.Route = null;
                _customerRepo.Update(customer);
                await AddLogAsync(LogActions.Update.GetDescription(), customer.BusinessName, LogsActionSrc.CustomerManagement.ToString());
                return Ok(new
                {
                    Message = string.Format(SuccessMessageConstants.UpdateSuccess, "Customer")
                });
            }
            catch (Exception ex)
            {
                LogException(ex);

                return BadRequest(new
                {
                    Message = string.Format(ErrorMessageConstants.UpdateFail, "Customer")
                });
            }
        }

        /// <summary>
        /// Method to delete customer
        /// </summary>
        /// <param name="id">id of the customer to be deleted</param>
        /// <returns>Status codes based on success/failure</returns>
        /// <response code="200">Returns success message</response>
        /// <response code="500">Returns exception in message</response>
        [HttpGet]
        // Delete
        public async Task<IActionResult> DeleteCustomerAsync(string id)
        {
            try
            {
                Guid cust_id = new Guid(id);
                Customer customer = _customerRepo.Get(cust_id);
                customer.DeletedAt = DateTime.Now;
                _customerRepo.Update(customer);
                ViewBag.Message = "Success";
                await AddLogAsync(LogActions.Delete.GetDescription(), customer.Email, LogsActionSrc.CustomerManagement.ToString());
                return Ok(new

                {
                    Message = string.Format(SuccessMessageConstants.DeleteSuccess, "Customer")
                });
            }
            catch (Exception ex)
            {
                LogException(ex);
                return BadRequest(
                   new
                   {
                       Message = string.Format(ErrorMessageConstants.DeleteFail, "Customer")
                   });
            }
        }

        /// <summary>
        /// Method to read csv file and add errors on individual records before adding in db
        /// </summary>
        /// <returns>List with valid invalid status appended in each row to display to the user</returns>
        public async Task<IActionResult> SeedCustomersAsync()
        {
            try
            {
                var curUserId = User.Claims.First().Value;
                int validRecords = 0, invalidRecord = 0, deletedRecord = 0;
                IFormFile File = Request.Form.Files[0];
                int flag = Int32.Parse(Request.Form["flag"]);
                CsvFileDescription csvFileDescription = new CsvFileDescription
                {
                    SeparatorChar = ',',
                    FirstLineHasColumnNames = true
                };
                CsvContext csvContext = new CsvContext();
                JsonResult jsonResult = null;
                using var reader = new StreamReader(File.OpenReadStream());
                IEnumerable<CustomerViewModel> list = csvContext.Read<CustomerViewModel>(reader, csvFileDescription);
                list = CheckforErrors(list);
                if (list != null)
                {
                    if (list.Count() > 0)
                    {
                        if (list.Count() <= 1000)
                        {
                            if (flag == 1)
                            {
                                foreach (var user in list)
                                {
                                    if (user.ErrorStatus.Equals(string.Empty))
                                        validRecords++;
                                    else if (user.ErrorStatus == "Deleted")
                                        deletedRecord++;
                                    else
                                        invalidRecord++;
                                }
                                jsonResult = Json(list);
                                return Ok(new
                                {
                                    Message = "Success",
                                    data = jsonResult.Value,
                                    validUsers = validRecords,
                                    invaliduser = invalidRecord,
                                    deletedCustomer = deletedRecord
                                });
                            }
                            else
                            {
                                int i = 0;
                                if (list.Count() > 0)
                                {
                                    var validCustomer = _mapper.Map<List<Customer>>(list.Where(x => string.IsNullOrEmpty(x.ErrorStatus)).ToList());
                                    var deletedPhone = list.Where(x => x.ErrorStatus.Equals("Deleted")).Select(x => x.PhoneNumber).ToList();
                                    var deletedCustomer = _customerRepo.FindAll(x => deletedPhone.Contains(x.PhoneNumber)).ToList();
                                    validCustomer.ForEach(x => x.CreatedById = curUserId);
                                    validCustomer.ForEach(x => x.Route = null);
                                    validCustomer.ForEach(x => x.Email?.ToLower().Trim());
                                    deletedCustomer.ForEach(x => x.DeletedAt = null);
                                    i += validCustomer.Count;
                                    i += deletedCustomer.Count;
                                    _customerRepo.InsertRange(validCustomer);
                                    _customerRepo.UpdateRange(deletedCustomer);

                                }
                                if (i == 0)
                                    return BadRequest(new { Message = ErrorMessageConstants.AllCsvRecordsInvalid });
                                else
                                {
                                    await AddLogAsync(LogActions.Import.GetDescription(), "Customers", LogsActionSrc.CustomerManagement.ToString());
                                    return Ok(new { Message = "Submitted", flag = i < list.ToArray().Length });
                                }
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

        /// <summary>
        /// Method to check errors in the uploaded csv file
        /// </summary>
        /// <param name="list">List of customers in the file</param>
        /// <returns>Same list with appended column specifying if the record is valid or invalid to add</returns>
        [NonAction]
        public List<CustomerViewModel> CheckforErrors(IEnumerable<CustomerViewModel> list)
        {
            try
            {
                var allCustomers = _customerRepo.GetAll().Select(x => new
                {
                    x.Email,
                    x.DeletedAt,
                    x.PhoneNumber,
                    x.AxCode
                }).ToList();

                var routes = _routesRepo.GetAll().Select(x => new { x.Name, x.Id }).ToList();
                var routeNames = routes.Select(x => x.Name).ToList();
                List<CustomerViewModel> listToRet = new List<CustomerViewModel>();
                var emailList = list.Select(x => x.Email?.ToLower().Trim()).ToList();
                var existingNumber = allCustomers.Where(x => x.DeletedAt == null).Select(x => x.PhoneNumber).ToList();
                var existingAxCode = allCustomers.Where(x => x.DeletedAt == null).Select(x => x.AxCode).ToList();
                var deletedPhone = allCustomers.Where(x => x.DeletedAt != null).Select(x => x.PhoneNumber?.ToLower().Trim()).ToList();
                var duplicate = list.GroupBy(x => x.PhoneNumber).Where(x => x.Count() > 1).SelectMany(x => x).Select(x => x.PhoneNumber).ToList();
                var duplicateAx = list.GroupBy(x => x.AxCode).Where(x => x.Count() > 1).SelectMany(x => x).Select(x => x.AxCode).ToList();
                list = list.Select(u => new CustomerViewModel()
                {
                    AxCode = u.AxCode,
                    Email = u.Email?.CheckString().ToLower().Trim() ?? null,
                    FirstName = u.FirstName.CheckString().Trim(),
                    LastName = u.LastName?.CheckString().Trim() ?? null,
                    BusinessName = u.BusinessName.CheckString().Trim(),
                    CNIC = u.CNIC.CheckString().Trim(),
                    PhoneNumber = $"+{u.PhoneNumber.CheckString().Trim()}",
                    City = u.City.CheckString().Trim(),
                    Province = u.Province.CheckString().Trim(),
                    Address1 = u.Address1.CheckString(),
                    Address2 = u.Address2?.CheckString().Trim() ?? null,
                    Longitude = u.Longitude.CheckString(),
                    Latitude = u.Latitude.CheckString(),
                    RouteName = u.RouteName.CheckString().Trim(),
                    RouteId = u.RouteName != null ? routes.Where(x => x.Name?.ToLower() == u.RouteName.ToLower()).Select(x => x.Id).FirstOrDefault() : Guid.Empty
                });
                listToRet = list.ToList();
                foreach (var customer in listToRet)
                {
                    List<string> Errors = new List<string>();
                    customer.PhoneNumber = customer.PhoneNumber == "+" ? "" : customer.PhoneNumber;
                    if (TryValidateModel(customer))
                    {
                        customer.PhoneNumber = customer.PhoneNumber.Contains('+') ? customer.PhoneNumber : $"+{customer.PhoneNumber}";
                        customer.ErrorStatus = _validationHelper.GetErrorStatusCustomer(existingNumber, deletedPhone, duplicate, existingAxCode, duplicateAx, customer.PhoneNumber, customer.AxCode, customer.RouteName, routeNames);
                    }
                    else
                    {
                        customer.PhoneNumber = customer.PhoneNumber.Contains('+') ? customer.PhoneNumber : $"+{customer.PhoneNumber}";
                        var customErr = _validationHelper.GetErrorStatusCustomer(existingNumber, deletedPhone, duplicate, existingAxCode, duplicateAx, customer.PhoneNumber, customer.AxCode, customer.RouteName, routeNames);
                        foreach (var err in ModelState.Values)
                            Errors.Add(err.Errors.FirstOrDefault().ErrorMessage);
                        customer.ErrorStatus = string.IsNullOrEmpty(customErr) ? String.Join(",", Errors) : $"{String.Join(",", Errors)},{customErr}";
                    }
                    ModelState.Clear();
                }
                return listToRet;
            }
            catch (Exception ex)
            {
                LogException(ex);
                return null;
            }
        }

        /// <summary>
        /// Checks if the email being entered while adding or editing in the form is valid or duplicated
        /// </summary>
        /// <returns>Status codes with message</returns>
        /// <response code="200">Returns success message</response>
        /// <response code="409">Returns user duplication message if the user is already deleted</response>
        /// <response code="500">Returns either the user is already added or the email is invalid in message</response>
        public JsonResult CheckDupEmail(string email, string? Id = null)
        {
            var customer = _customerRepo.FindBy(x => x.Email.Trim().ToLower().Equals(email.Trim().ToLower()));
            if (string.IsNullOrEmpty(Id) && customer != null)
            {
                return Json(false);
            }
            else if (!string.IsNullOrEmpty(Id) && customer != null)
            {
                Guid guidId = new Guid(Id)
;
                if (customer.Id.Equals(guidId))
                {
                    return Json(true);
                }
                return Json(false);
            }
            return Json(true);
        }

        public IActionResult CheckDupNumber(string phoneNumber, string Id)
        {
            if (phoneNumber.Contains('_'))
            {
                return Json("Please enter mobile number in valid format (+923XXXXXXXXX).");
            }
            else
            {
                var customer = _customerRepo.FindBy(x => x.PhoneNumber.Equals(phoneNumber));
                if (string.IsNullOrEmpty(Id) && customer != null)
                {
                    return Json("The Mobile Number already exist.");
                }
                else if (!string.IsNullOrEmpty(Id) && customer != null)
                {
                    Guid guidId = new Guid(Id)
    ;
                    if (customer.Id.Equals(guidId))
                    {
                        return Json(true);
                    }
                    return Json("The Mobile Number already exist.");
                }
            }
            return Json(true);
        }

        public IActionResult CheckCNIC(string cnic)
        {
            if (cnic.Contains('_'))
            {
                return Json(false);
            }
            return Json(true);
        }
        public async Task<IActionResult> UndoDeleteAsync(string id)
        {
            try
            {
                Guid cust_id = new Guid(id);
                var customer = _customerRepo.Get(cust_id);
                customer.DeletedAt = null;
                _customerRepo.Update(customer);
                await AddLogAsync(LogActions.ReActivate.GetDescription(), customer.Email, LogsActionSrc.CustomerManagement.ToString());
                return Ok(new
                {
                    Message = string.Format(SuccessMessageConstants.ReAddSuccess, "Customer")
                });
            }
            catch (Exception ex)
            {
                LogException(ex);
                return BadRequest(new
                {
                    ex.Message
                });
            }
        }

        /// <summary>
        /// Method to deactivate or activate user
        /// </summary>
        /// <param name="id">Id of the user to be activated/deactivated</param>
        /// <returns>Status codes based on success/failure</returns>
        /// <response code="200">Returns success message</response>
        /// <response code="500">Returns exception in message</response>
        [HttpGet]
        public async Task<IActionResult> ChangeStatusAsync(string id)
        {
            try
            {
                Guid custId = new Guid(id);
                var customer = _customerRepo.Get(custId);
                customer.IsActive = !customer.IsActive;
                _customerRepo.Update(customer);
                var Message = string.Empty;
                if ((bool)customer.IsActive)
                {
                    Message = string.Format(SuccessMessageConstants.ActiveSuccess, "Customer");
                }
                else
                {
                    Message = string.Format(SuccessMessageConstants.InactiveSuccess, "Customer");
                }
                await AddLogAsync(LogActions.ChangeStatus.GetDescription(), customer.Email, LogsActionSrc.CustomerManagement.ToString());
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

        [HttpGet]
        public IActionResult SalesPersonName(string routeId)
        {
            try
            {
                var route = _routesRepo.FindAll(x => x.Id.Equals(new Guid(routeId))).Include(x => x.SalesPersons).ThenInclude(x => x.SalesPerson).First();
                var spName = RouteSp(route.SalesPersons.ToList());

                return Ok(new
                {
                    Message = "Success",
                    SpName = spName ?? "---"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = ErrorMessageConstants.Error,
                    ex
                });
            }
        }
        public IActionResult CustomerInfo(string id)
        {
            try
            {
                var customer = _customerRepo.FindAll(x => x.Id.Equals(new Guid(id))).Include(x => x.ProfilePicture)
                    .Include(x => x.Route).FirstOrDefault();
                CustomerInfoViewModel model = _mapper.Map<CustomerInfoViewModel>(customer);
                return PartialView("_CustomerDetails", model);
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

        public IActionResult CheckDupAxCode(string axCode, string Id)
        {
            var customer = _customerRepo.FindBy(x => x.AxCode.Equals(axCode));
            if (string.IsNullOrEmpty(Id) && customer != null)
            {
                return Json("The AxCode already exist.");
            }
            else if (!string.IsNullOrEmpty(Id) && customer != null)
            {
                Guid guidId = new Guid(Id)
;
                if (customer.Id.Equals(guidId))
                {
                    return Json(true);
                }
                return Json("The AxCode already exist.");
            }
            return Json(true);
        }
    }
}