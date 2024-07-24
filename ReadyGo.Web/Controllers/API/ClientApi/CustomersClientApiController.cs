using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    // [ApiKey]
    [ApiController]
    [ApiVersion("2.0")]
    [ApiExplorerSettings(GroupName = "client")]
    [Route("api/v{version:apiVersion}/CustomersClient/")]
    [SwaggerTag("Create, Read, Update and Delete Customers based on Customer Id Or AxCode")]
    public class CustomersClientApiController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Customer> _customersRepo;
        private readonly IGenericRepository<ResourceFile> _filesRepo;
        private readonly IGenericRepository<Route> _routeRepo;

        public CustomersClientApiController(IGenericRepository<Customer> customerRepo, IMapper mapper, IGenericRepository<ResourceFile> filesRepo, IGenericRepository<Route> routeRepo)
        {
            _mapper = mapper;
            _customersRepo = customerRepo;
            _filesRepo = filesRepo;
            _routeRepo = routeRepo;
        }

        /// <summary>
        /// Get all Customers
        /// </summary>
        /// <param name="synced" Example="false">Customer Synced Status</param>
        /// <param name="dateCreated" Example="12/15/2020">Customer Created Date Format (Month/Day/Year)</param>
        [HttpGet]
        [Route("GetCustomers")]
        public IActionResult GetAll(bool synced = false, DateTime? dateCreated = null)
        {
            try
            {
                var customers = (synced == true) ? _customersRepo.FindAll(x => x.SyncedAt == null && x.DeletedAt == null) : _customersRepo.FindAll(x => x.SyncedAt != null && x.DeletedAt == null);

                if (dateCreated != null)
                    customers = customers.Where(x => x.CreatedAt.Date == dateCreated.Value.Date);

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = SuccessMessageConstants.DefaultSuccess, Customers = customers });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        /// Get Customer based on Customer Id.
        /// </summary>
        /// <param name="id">Customer Id</param>
        /// <response code="200">Customer found against id provided.</response>
        /// <response code="400">Customer not found against id provided.</response>
        [HttpGet("GetCustomerById/{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var customer = _customersRepo.FindBy(x => x.Id == id && x.DeletedAt == null);
                if (customer == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, "Customer") });

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = SuccessMessageConstants.DefaultSuccess, Customer = customer });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }


        /// <summary>
        /// Get Customer based on Customer Ax Code.
        /// </summary>
        /// <param name="code"></param>
        /// <response code="200">Customer found against Ax Code provided.</response>
        /// <response code="400">Customer not found against Ax Code provided.</response>
        [HttpGet("GetCustomerByAxCode/{code}")]
        public IActionResult GetByAxCode(string code)
        {
            try
            {
                var customer = _customersRepo.FindBy(x => x.AxCode == code && x.DeletedAt == null);
                if (customer == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, "Customer") });

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = SuccessMessageConstants.DefaultSuccess, Customer = customer });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        ///   Delete customer based on customer Id.
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">If customer deleted successfully</response>
        /// <response code="400">If customer not found against id provided.</response>
        [HttpDelete("DeleteCustomerById/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var customer = _customersRepo.FindBy(x => x.Id == id && x.DeletedAt == null);
                if (customer == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, "Customer") });

                customer.DeletedAt = DateTime.Now;
                _customersRepo.Update(customer);

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = string.Format(SuccessMessageConstants.DeleteSuccess, customer.FirstName + " " + customer.LastName) });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }


        /// <summary>
        ///   Delete customer based on customer Ax Code.
        /// </summary>
        /// <param name="code"></param>
        /// <response code="200">If customer deleted successfully</response>
        /// <response code="400">If customer not found against Ax Code provided.</response>
        [HttpDelete("DeleteCustomerByAxCode/{code}")]
        public IActionResult DeleteByAxCode(string code)
        {
            try
            {
                var customer = _customersRepo.FindBy(x => x.AxCode == code && x.DeletedAt == null);
                if (customer == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, "Customer") });

                customer.DeletedAt = DateTime.Now;
                _customersRepo.Update(customer);

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = string.Format(SuccessMessageConstants.DeleteSuccess, customer.FirstName + " " + customer.LastName) });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        /// Add a new Customer
        /// </summary>
        /// <param name="customerVM"></param>
        /// <response code="200">If new customer added successfully</response>
        /// <response code="400">If phone number already exist</response>
        [HttpPost]
        [Route("InsertCustomer")]
        public IActionResult Post([FromBody] CustomerViewModel customerVM)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception();

                var route = _routeRepo.FindBy(x => x.AxCode == customerVM.RouteAxCode && x.DeletedAt == null);
                if (string.IsNullOrWhiteSpace(customerVM.AxCode))
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.Required, "Customer AxCode") });

                if (_customersRepo.FindBy(x => x.PhoneNumber == customerVM.PhoneNumber) != null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.AlreadyExists, "Customer Phone Number") });

                if (!string.IsNullOrWhiteSpace(customerVM.RouteAxCode))
                {
                    if (route == null)
                        return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotValid, "Route AxCode") });
                }

                customerVM.RouteId = route.Id;
                var customer = _mapper.Map<Customer>(customerVM);

                customer.CreatedAt = DateTime.Now;
                customer.SyncedAt = DateTime.Now;
                _customersRepo.Insert(customer);

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = string.Format(SuccessMessageConstants.CreateSuccess, "Customer") });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        /// Insert multiple categories
        /// </summary>
        [HttpPost]
        [Route("InsertMultipleCustomers")]
        [ProducesResponseType(typeof(CustomerViewModel), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Produces("application/json", "application/xml")]
        public IActionResult InsertMultipleCustomers([FromBody] IEnumerable<CustomerViewModel> customers)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception();

                List<object> responseMessages = new List<object>();
                var count = 0;
                foreach (var customer in customers)
                {
                    count++;

                    var route = _routeRepo.FindBy(x => x.AxCode == customer.RouteAxCode && x.DeletedAt == null);

                    if (string.IsNullOrWhiteSpace(customer.AxCode))
                    {
                        responseMessages.Add(new { RecordNumber = count, Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.AlreadyExists, "Customer AxCode") });
                        continue;
                    }

                    var existingCustomer = _customersRepo.FindBy(x => x.PhoneNumber == customer.PhoneNumber && x.DeletedAt == null);
                    if (existingCustomer != null)
                    {
                        responseMessages.Add(new { RecordNumber = count, Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.AlreadyExists, "Customer Phone Number") });
                        continue;
                    }

                    if (!string.IsNullOrWhiteSpace(customer.RouteAxCode))
                    {
                        if (route == null)
                        {
                            responseMessages.Add(new { RecordNumber = count, Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotValid, "Route AxCode") });
                            continue;
                        }
                    }

                    customer.RouteId = route.Id;
                    var newCustomer = _mapper.Map<Customer>(customer);

                    newCustomer.SyncedAt = DateTime.Now;

                    if (_customersRepo.Insert(newCustomer))
                    {
                        responseMessages.Add(new { RecordNumber = count, Status = ApiStatus.Success, Message = string.Format(SuccessMessageConstants.CreateSuccess, customer.Email) });
                        continue;
                    }
                    else
                    {
                        responseMessages.Add(new { RecordNumber = count, Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.AlreadyExists, "Customer") });
                        continue;
                    }
                }
                return Ok(responseMessages);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        /// Update a customer.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customerVM"></param>
        /// <response code="200">If customer updated successfully</response>
        /// <response code="400">If customer already exist with same phone number</response>
        [HttpPut("UpdateCustomer/{id}")]
        public IActionResult Put(Guid id, [FromBody] CustomerViewModel customerVM)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception();

                var route = _routeRepo.FindBy(x => x.AxCode == customerVM.RouteAxCode && x.DeletedAt == null);

                var customer = _customersRepo.FindBy(x => x.Id == id && x.DeletedAt == null);
                if (customer == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, "Customer") });

                var customerAxCode = _customersRepo.FindBy(x => x.Id != id && x.AxCode == customerVM.AxCode && x.DeletedAt == null);
                if (customerAxCode != null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.AlreadyExists, "Customer") });

                var existingPhoneNumber = _customersRepo.FindBy(x => x.PhoneNumber == customerVM.PhoneNumber && x.DeletedAt == null);
                if (existingPhoneNumber != null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.AlreadyExists, "Customer Phone Number") });

                if (!string.IsNullOrWhiteSpace(customerVM.RouteAxCode))
                {
                    if (route == null)
                        return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotValid, "Route AxCode") });
                }

                customerVM.RouteId = route.Id;

                customer.FirstName = customerVM.FirstName;
                customer.LastName = customerVM.LastName;
                customer.Address1 = customerVM.Address1;
                customer.Address2 = customerVM.Address2;
                customer.Province = customerVM.Province;
                customer.Email = customerVM.Email;
                customer.PhoneNumber = customerVM.PhoneNumber;
                customer.Balance = customerVM.Balance;
                customer.Latitude = customerVM.Latitude;
                customer.Longitude = customerVM.Longitude;
                customer.RouteId = customerVM.RouteId;

                customer.SyncedAt = DateTime.Now;
                _customersRepo.Update(customer);

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = string.Format(SuccessMessageConstants.UpdateSuccess, customer.FirstName + " " + customer.LastName) });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        /// Update a customer By Ax Code.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="customerVM"></param>
        /// <response code="200">If customer updated successfully</response>
        /// <response code="400">If customer already exist with same phone number</response>
        [HttpPut("UpdateCustomerByAxCode/{code}")]
        public IActionResult PutByAxCode(string code, [FromBody] CustomerViewModel customerVM)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception();

                var route = _routeRepo.FindBy(x => x.AxCode == customerVM.RouteAxCode && x.DeletedAt == null);

                var customer = _customersRepo.FindBy(x => x.AxCode == code && x.DeletedAt == null);
                if (customer == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, "Customer") });

                var customerAxCode = _customersRepo.FindBy(x => x.Id != customer.Id && x.AxCode == customerVM.AxCode && x.DeletedAt == null);
                if (customerAxCode != null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.AlreadyExists, "Customer") });

                var existingPhoneNumber = _customersRepo.FindBy(x => x.PhoneNumber == customerVM.PhoneNumber && x.DeletedAt == null);
                if (existingPhoneNumber != null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.AlreadyExists, "Customer Phone Number") });

                if (!string.IsNullOrWhiteSpace(customerVM.RouteAxCode))
                {
                    if (route == null)
                        return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotValid, "Route AxCode") });
                }

                customerVM.RouteId = route.Id;
                customer.FirstName = customerVM.FirstName;
                customer.LastName = customerVM.LastName;
                customer.Address1 = customerVM.Address1;
                customer.Address2 = customerVM.Address2;
                customer.Province = customerVM.Province;
                customer.Email = customerVM.Email;
                customer.PhoneNumber = customerVM.PhoneNumber;
                customer.Balance = customerVM.Balance;
                customer.Latitude = customerVM.Latitude;
                customer.Longitude = customerVM.Longitude;
                customer.RouteId = customerVM.RouteId;

                customer.SyncedAt = DateTime.Now;
                _customersRepo.Update(customer);

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = string.Format(SuccessMessageConstants.UpdateSuccess, customer.FirstName + " " + customer.LastName) });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        ///   Sync customers based on ids provided.
        /// </summary>
        /// <param name="Ids"></param>
        /// <response code="200">All customer found against ids provided.</response>
        [HttpPost("SyncCustomers")]
        public IActionResult SyncCustomers([FromBody] IEnumerable<Guid> Ids)
        {
            try
            {
                var customers = _customersRepo.FindAll(x => Ids.Contains(x.Id) && x.DeletedAt == null).ToList();

                if (customers.Count > 0)
                {
                    foreach (var customer in customers)
                    {
                        customer.SyncedAt = DateTime.Now;
                        _customersRepo.Update(customer);
                    }
                }

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = SuccessMessageConstants.DefaultSuccess });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        /// Upload profile photo of customer.
        /// </summary>
        /// <remarks>
        /// Sample Code:
        /// 
        ///     byte[] imageArray = System.IO.File.ReadAllBytes(@"image file path");
        ///     string ImageString = Convert.ToBase64String(imageArray);
        ///     
        /// </remarks>
        /// <param name="imgVM"></param>
        /// <response code="200">Profie photo updated for a customer</response>
        [HttpPost]
        [Route("InsertProfilePhoto")]
        public IActionResult UploadProfilePicture(ImageViewModel imgVM)
        {
            try
            {
                var customer = _customersRepo.FindBy(x => x.AxCode == imgVM.AxCode && x.DeletedAt == null);
                if (customer == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotValid, "Customer Ax Code") });

                if (!IsBase64String(imgVM.ImageString))
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotValid, "Image") });

                Guid existingImageId = customer.PictureId.GetValueOrDefault();

                if (existingImageId != null)
                {
                    var existingImage = _filesRepo.FindBy(x => x.Id == existingImageId && x.DeletedAt == null);
                    if (existingImage != null)
                    {
                        existingImage.DeletedAt = DateTime.Now;
                        _filesRepo.Update(existingImage);
                    }
                }

                var image = Convert.FromBase64String(imgVM.ImageString);
                ResourceFile customerImage = new ResourceFile()
                {
                    File = image,
                    Name = "pp_" + customer.Id + GetFileExtension(imgVM.ImageString),
                    MimeType = "Image"
                };
                _filesRepo.Insert(customerImage);
                customer.PictureId = customerImage.Id;
                _customersRepo.Update(customer);

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = string.Format(SuccessMessageConstants.UpdateSuccess, "Profile Photo") });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        [NonAction]
        private string GetFileExtension(string base64String)
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

        [NonAction]
        private bool IsBase64String(string base64)
        {
            Span<byte> buffer = new Span<byte>(new byte[base64.Length]);
            return Convert.TryFromBase64String(base64, buffer, out int bytesParsed);
        }
    }
}
