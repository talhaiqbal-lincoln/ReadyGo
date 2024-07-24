using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReadyGo.Domain.Constants;
using ReadyGo.Domain.Entities;
using ReadyGo.Domain.Entities.ApiModels;
using ReadyGo.Domain.Entities.Identity;
using ReadyGo.Domain.Enum;
using ReadyGo.Persistence;
using ReadyGo.Persistence.Seeds;
using ReadyGo.Service.Interfaces;
using ReadyGo.Service.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace ReadyGo.Web.Controllers.API
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "mobile")]
    [Route("api/v{version:apiVersion}/Customer/")]
    public class CustomerApiController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;
        private readonly IGenericRepository<Customer> _customerRepo;
        private readonly IGenericRepository<ResourceFile> _filesRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IGenericRepository<LogInformation> _logsRepo;
        private readonly IGenericRepository<AssignedRoute> _assignRouteRepo;
        private readonly IGenericRepository<Payment> _paymentRepo;
        private readonly IGenericRepository<Order> _orderRepo;
        private readonly IFileService _imageHelper;
        private readonly INotificationService _notificationService;

        public CustomerApiController(IMapper mapper, IGenericRepository<LogInformation> logsRepo,
            IGenericRepository<Customer> custRepo, UserManager<ApplicationUser> userManager,
            ApplicationDbContext dbContext, IFileService imgHelper, IGenericRepository<ResourceFile> filesRepo,
            IGenericRepository<AssignedRoute> assignRouteRepo,
            INotificationService notificationService,
            IGenericRepository<Order> orderRepo,
            IGenericRepository<Payment> paymentRepo)
        {
            _orderRepo = orderRepo;
            _paymentRepo = paymentRepo;
            _filesRepo = filesRepo;
            _imageHelper = imgHelper;
            _logsRepo = logsRepo;
            _userManager = userManager;
            _customerRepo = custRepo;
            _mapper = mapper;
            _dbContext = dbContext;
            _notificationService = notificationService;
            _assignRouteRepo = assignRouteRepo;
        }

        /// <summary>
        /// Post method for user addition
        /// </summary>
        /// <param name="customerModel">User to be added</param>
        /// <returns></returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [Route("AddCustomer")]
        public IActionResult AddCustomer(CustomerApiViewModel customerModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponseModel(ApiStatus.Error, ApiErrors.ModelState.GetDescription(), ApiErrors.ModelState));
                }

                var email = DecodeJwt();

                //Get Details of sale person who requested to add customer
                var curUser = _userManager.Users.Include(x => x.Routes).Include(x => x.Role).First(x => x.Email.Equals(email));

                if (!curUser.IsActive)
                {
                    return Forbid();
                }

                //check if customer is already created
                var duplicatedCustomer = _customerRepo.FindBy(x => x.CreatedById.Equals(curUser.Id) &&
                                                                          x.BusinessName.Equals(customerModel.BusinessName)
                                                                          && x.CreatedAt.Equals(customerModel.LastModified));
                if (duplicatedCustomer != null)
                {
                    var responseDataId = new
                    {
                        Id = duplicatedCustomer.Id
                    };
                    return Ok(new ApiResponseModel(responseDataId));
                }


                #region Case: Might be record is created but did'nt syncd on mobile and on mobile that customer data is updated
                if (customerModel.Id == null)
                {
                    var _existingCustomer = _customerRepo.FindBy(x => x.CreatedById.Equals(curUser.Id) &&
                                                                x.BusinessName.Equals(customerModel.BusinessName) &&
                                                               x.PhoneNumber.Equals(customerModel.PhoneNumber));
                    if (_existingCustomer != null)
                    {
                        customerModel.Id = _existingCustomer.Id;
                    }
                }
                #endregion

                if (customerModel.Id != null) //Update data
                {
                    var customerEntity = UpdateCustomer(customerModel);
                    var responseDataUpdate = new
                    {
                        Id = customerEntity.Id
                    };
                    return Ok(new ApiResponseModel(responseDataUpdate));
                }

                //Convert customer email to lower case
                customerModel.Email = customerModel.Email?.Trim()?.ToLower();

                //Populate EF entity from view-model
                var customer = _mapper.Map<Customer>(customerModel);

                var spRoute = curUser.Routes.FirstOrDefault(x => x.TemporaryAssignedTill == null);

                if (spRoute != null)
                {
                    customer.RouteId = spRoute.RouteId;
                }

                customer.CreatedById = curUser.Id;

                _customerRepo.Insert(customer);

                if (!string.IsNullOrWhiteSpace(customerModel.Image) && IsBase64String(customerModel.Image))
                {
                    var image = Convert.FromBase64String(customerModel.Image);
                    ResourceFile customerImage = new ResourceFile()
                    {
                        File = image,
                        Name = "pp_" + customer.Id.ToString() + GetFileExtension(customerModel.Image),
                        MimeType = "Image"
                    };
                    _filesRepo.Insert(customerImage);
                    customer.PictureId = customerImage.Id;
                    _customerRepo.Update(customer);
                }


                //Check if already there's an customer with the same email in the databases
                var existingCustomer = _customerRepo.FindBy(x => x.PhoneNumber.ToLower().Equals(customerModel.PhoneNumber.ToLower()) && x.Id != customer.Id);
                if (existingCustomer != null)
                {
                    _notificationService.PushNotification(
                        string.Format(NotificationConstants.MultipleCustomers, existingCustomer.PhoneNumber),
                        curUser.Id,
                        Url.Action("ViewCustomer", "Customer",new { cust_id = customer.Id }),
                        null,
                        $"{Roles.Admin.GetDescription()}",
                        null);
                }
                else
                {
                    _notificationService.PushNotification(
                    string.Format(NotificationConstants.CustomerAdded, customer.BusinessName, curUser.Email, curUser.Role.Name),
                    curUser.Id,
                    Url.Action("ViewCustomer", "Customer", new { cust_id = customer.Id }),
                    NotficationEnums.CustomerAdded.ToString(),
                    $"{Roles.Admin.GetDescription()},{Roles.SalesManager.GetDescription()},{Roles.MarketingManager.GetDescription()}",
                    null);
                }

                var responseData = new
                {
                    Id = customer.Id
                };
                return Ok(new ApiResponseModel(responseData));
            }
            catch (Exception ex)
            {
                //await LogException(LogActions.Add.ToString(), ex.Message);
                return BadRequest(new ApiResponseModel(ApiStatus.Error, ApiErrors.DefaultError.GetDescription(), ApiErrors.DefaultError));
            }
        }

        /// <summary>
        /// Post method for user addition
        /// </summary>
        /// <returns>Lisof customer wrt page num and page size</returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        [Route("GetCustomers")]
        public IActionResult GetCustomers(int PageNumber,int RecordsFetchLimit)
        {
            try
            {
                int totalCustomers =0;
                var email = DecodeJwt();

                var user = _userManager.Users.Include(x => x.Routes.Where(x => x.DeletedAt == null)).
                    ThenInclude(x => x.Route).ThenInclude(x => x.Customers).ThenInclude(x => x.ProfilePicture)
                    .Include(x => x.Routes).ThenInclude(x => x.Route).ThenInclude(x => x.Customers)
                    .ThenInclude(x => x.Discounts.Where(x => x.DeletedAt == null && x.ProductID == null && x.IsActive))
                    .FirstOrDefault(x => x.Email.Equals(email));

                if(!user.IsActive)
                {
                    return Forbid();
                }

                var customers = GetSPCustomers(user);


                object responseData;
                if (customers != null && customers.Count > 0)
                {
                    //List<Guid> customerIds = customers.Select(x => x.Id).ToList();
                    //var allPayments = _paymentRepo.FindAll(x => x.DeletedAt == null && !x.IsMarked && customerIds.Contains(x.CustomerId));
                    //var allOrders = _orderRepo.FindAll(x => x.DeletedAt == null && !x.IsMarked && customerIds.Contains(x.CustomerId));
                    //var ordersTotal = 0.0;
                    //var paymentsTotal = 0.0;

                    totalCustomers = customers.Count;

                    customers = customers.Skip((PageNumber - 1) * RecordsFetchLimit).Take(RecordsFetchLimit).ToList();

                    customers?.ForEach(x =>
                    {
                        var toRemove = x.Discounts.OrderByDescending(x => x.CreatedAt).Skip(1).ToList();
                        toRemove.ForEach(y => x.Discounts.Remove(y));

                        //ordersTotal = allOrders.Where(y => y.CustomerId.Equals(x.Id))
                        //.Sum(x => x.Total);

                        //paymentsTotal = allPayments.Where(y => y.CustomerId.Equals(x.Id)).Sum(y => y.PaymentReceived);

                        //x.Balance = ordersTotal - paymentsTotal;
                    });

                    List<CustomerApiViewModel> customersView = _mapper.Map<List<Customer>, List<CustomerApiViewModel>>(customers.ToList());
                    responseData = new
                    {
                        Message = SuccessMessageConstants.DefaultSuccess,
                        TotalCustomers = totalCustomers,
                        Customers = customersView
                    };
                }
                else
                {
                    responseData = new
                    {
                        Message = SuccessMessageConstants.DefaultSuccess,
                        TotalCustomers = totalCustomers,
                        Customers = customers
                    };
                }
                return Ok(new ApiResponseModel(responseData));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseModel(ApiStatus.Error, ApiErrors.DefaultError.GetDescription(), ApiErrors.DefaultError));
            }
        }


        #region Helper Methods
        [NonAction]
        private Customer UpdateCustomer(CustomerApiViewModel customerApiViewModel)
        {
            Customer _customerEntity = _customerRepo.FindAll(x => x.Id.Equals(customerApiViewModel.Id)).Include(x => x.ProfilePicture).FirstOrDefault();

            if (_customerEntity != null)
            {
                _customerEntity.Latitude = string.IsNullOrWhiteSpace(customerApiViewModel.Latitude?.Trim()) ? _customerEntity.Latitude : customerApiViewModel.Latitude;
                _customerEntity.Longitude = string.IsNullOrWhiteSpace(customerApiViewModel.Longitude?.Trim()) ? _customerEntity.Longitude : customerApiViewModel.Longitude;

                if (!string.IsNullOrWhiteSpace(customerApiViewModel.Image) && IsBase64String(customerApiViewModel.Image))
                {
                    var image = Convert.FromBase64String(customerApiViewModel.Image);
                    if (_customerEntity.ProfilePicture != null)
                    {
                        _customerEntity.ProfilePicture.File = image;
                    }
                    else
                    {
                        ResourceFile customerImage = new ResourceFile()
                        {
                            File = image,
                            Name = "pp_" + _customerEntity.Id.ToString() + GetFileExtension(customerApiViewModel.Image),
                            MimeType = "Image"
                        };
                        _filesRepo.Insert(customerImage);
                        _customerEntity.PictureId = customerImage.Id;
                    }
                }
                _customerRepo.Update(_customerEntity);
            }
            return _customerEntity;
        }


        [NonAction]
        public List<Customer> GetSPCustomers(ApplicationUser user)
        {
            if (user.Routes != null && user.Routes.Count > 0)
            {


                var assignedRoutes = user.Routes.Where(x => x.Route.DeletedAt == null && x.Route.IsActive).ToList();
                List<Customer> customers = new List<Customer>();

                var permRoute = assignedRoutes.FirstOrDefault(x => x.TemporaryAssignedTill == null);
                if (permRoute != null)
                {

                    var routeAssignToAnotherSp = _assignRouteRepo.FindBy(x => x.RouteId.Equals(permRoute.RouteId) && x.TemporaryAssignedTill.HasValue && x.TemporaryAssignedTill.Value.Date >= DateTime.Today.Date && x.DeletedAt == null);
                    if (routeAssignToAnotherSp != null)
                    {
                        return null;
                    }
                    customers.AddRange(permRoute.Route.Customers.Where(c => c.DeletedAt == null && c.IsActive).ToList());
                }
                var tempRoute = assignedRoutes.FirstOrDefault(x => x.TemporaryAssignedTill != null && x.TemporaryAssignedTill.Value.Date >= DateTime.Today);
                if (tempRoute != null)
                {
                    customers.AddRange(tempRoute.Route.Customers.Where(c => c.DeletedAt == null && c.IsActive).ToList());
                }
                return customers;
            }
            return null;
        }
        [NonAction]
        public bool IsBase64String(string base64)
        {
            Span<byte> buffer = new Span<byte>(new byte[base64.Length]);
            return Convert.TryFromBase64String(base64, buffer, out int bytesParsed);
        }
        /// <summary>
        /// To demonstrate extraction of file extension from base64 string.
        /// </summary>
        /// <param name="base64String">base64 string.</param>
        /// <returns>Henceforth file extension from string.</returns>
        [NonAction]
        public string GetFileExtension(string base64String)
        {
            var data = base64String.Substring(0, 5);

            switch (data.ToUpper())
            {
                case "IVBOR":
                    return ".png";
                case "/9J/4":
                    return ".jpg";
                case "AAAAF":
                    return ".mp4";
                case "JVBER":
                    return ".pdf";
                case "AAABA":
                    return ".ico";
                case "UMFYI":
                    return ".rar";
                case "E1XYD":
                    return ".rtf";
                case "U1PKC":
                    return ".txt";
                case "MQOWM":
                case "77U/M":
                    return ".srt";
                default:
                    return string.Empty;
            }
        }
        #endregion

    }
}