using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadyGo.Domain.Constants;
using ReadyGo.Domain.Entities;
using ReadyGo.Domain.Entities.Identity;
using ReadyGo.Domain.Entities.ViewModels;
using ReadyGo.Domain.Enum;
using ReadyGo.Infrastructure.Filters;
using ReadyGo.Persistence.Seeds;
using ReadyGo.Service.Interfaces;
using ReadyGo.Service.Repositories.Interfaces;
using ReadyGo.Service.Stored_Procedures.Interface;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyGo.Web.Controllers
{
    [Authorize]
    public class PaymentController : BaseController
    {
        private readonly IGenericRepository<Payment> _paymentRepo;
        private readonly IGenericRepository<Order> _orderRepo;
        private readonly IGenericRepository<Configuration> _configRepo;
        private readonly IProcedures _sp;
        private readonly INotificationService _notificationService;
        private readonly IInvoiceService _invoiceService;
        private readonly IMapper _mapper;
        public PaymentController(IGenericRepository<Payment> paymentRepo, IProcedures sp,
            INotificationService notificationService, IMapper mapper, 
            IGenericRepository<Configuration> configRepo,
            IInvoiceService invoiceService, IGenericRepository<Order> orderRepo)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
            _notificationService = notificationService;
            _sp = sp;
            _paymentRepo = paymentRepo;
            _configRepo = configRepo;
            _invoiceService = invoiceService;
        }
        public IActionResult Index()
        {
            ViewBag.SalesPersons = _userManager.Users.Where(x => x.DeletedAt == null && x.IsActive)
                   .Select(x => new SalesPerson
                   {
                       Id = x.Id,
                       Name = x.FirstName + " " + x.LastName
                   });
            return View();
        }
        [HttpPost]
        public IActionResult Payments()
        {
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var spId = Request.Form["columns[1][search][value]"].FirstOrDefault();
                var sortColumn = Request.Form["order[0][column]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault()?.Trim().Trim() ?? Request.Form["search"].FirstOrDefault().Trim().Trim();
                var id = Request.Form["id"].FirstOrDefault();
                var date = Request.Form["columns[5][search][value]"].FirstOrDefault();
                var isMarked = Convert.ToBoolean(Request.Form["isMarked"].FirstOrDefault());
                int pageSize = Convert.ToInt32(length ?? "0");
                int skip = Convert.ToInt32(start ?? "0");
                int recordsTotal = 0;

                var payments = !string.IsNullOrEmpty(id) ?
                    _paymentRepo.FindAll(x => x.DeletedAt == null && x.SalesPersonId.Equals(id) && x.IsMarked == isMarked).OrderBy(x => x.ReceivedAt)
                    .Include(x => x.Customer)
                    .Include(x => x.SalesPerson).Select(x => new
                    {
                        Code = x.PaymentCode,
                        x.Id,
                        CustomerCode = string.IsNullOrEmpty(x.Customer.AxCode) ? "---" : x.Customer.AxCode,
                        CustomerName = x.Customer.BusinessName,
                        CurrentBalance = Math.Round(x.CurrentBalance, 2),
                        NewBalance = Math.Round(x.NewBalance, 2),
                        PaymentReceived = Math.Round(x.PaymentReceived, 2),
                        SalesPersonName = x.SalesPerson.FirstName + " " + x.SalesPerson.LastName,
                        CreatedAt = x.ReceivedAt,
                        SpId = x.SalesPersonId
                    }).AsNoTracking().ToList() :
                    _paymentRepo.FindAll(x => x.DeletedAt == null && x.IsMarked == isMarked).OrderBy(x => x.ReceivedAt)
                    .Include(x => x.Customer)
                    .Include(x => x.SalesPerson).Select(x => new
                    {
                        Code = x.PaymentCode,
                        x.Id,
                        CustomerCode = string.IsNullOrEmpty(x.Customer.AxCode) ? "---" : x.Customer.AxCode,
                        CustomerName = x.Customer.BusinessName,
                        CurrentBalance = Math.Round(x.CurrentBalance, 2),
                        NewBalance = Math.Round(x.NewBalance, 2),
                        PaymentReceived = Math.Round(x.PaymentReceived, 2),
                        SalesPersonName = x.SalesPerson.FirstName + " " + x.SalesPerson.LastName,
                        CreatedAt = x.ReceivedAt,
                        SpId = x.SalesPersonId
                    }).AsNoTracking().ToList();

                payments = string.IsNullOrEmpty(spId) ? payments : payments.Where(x => x.SpId == spId).ToList();
                if (payments.Count > 0)
                {
                    if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                    {
                        int column = int.Parse(sortColumn);
                        if (isMarked)
                        {
                            switch (column)
                            {
                                case 1:
                                    payments = (sortColumnDirection == "asc" ? payments.OrderBy(c => c.Code)
                                        : payments.OrderByDescending(c => c.Code)).ToList();
                                    break;

                                case 2:
                                    payments = ((sortColumnDirection == "asc" ? payments.OrderBy(c => c.CustomerName)
                                        : payments.OrderByDescending(c => c.CustomerName))).ToList();
                                    break;

                                case 3:
                                    payments = (sortColumnDirection == "asc" ? payments.OrderBy(c => c.SalesPersonName)
                                        : payments.OrderByDescending(c => c.SalesPersonName)).ToList();
                                    break;

                                case 4:
                                    payments = ((sortColumnDirection == "asc" ? payments.OrderBy(c => c.CurrentBalance) :
                                        payments.OrderByDescending(c => c.CurrentBalance))).ToList();
                                    break;

                                case 5:
                                    payments = ((sortColumnDirection == "asc" ? payments.OrderBy(c => c.PaymentReceived) :
                                        payments.OrderByDescending(c => c.PaymentReceived))).ToList();
                                    break;

                                case 6:
                                    payments = ((sortColumnDirection == "asc" ? payments.OrderBy(c => c.NewBalance) :
                                        payments.OrderByDescending(c => c.NewBalance))).ToList();
                                    break;

                                case 7:
                                    payments = ((sortColumnDirection == "asc" ? payments.OrderBy(c => c.CreatedAt) :
                                        payments.OrderByDescending(c => c.CreatedAt))).ToList();
                                    break;
                            }
                        }
                        else
                        {
                            switch (column)
                            {
                                case 0:
                                    payments = (sortColumnDirection == "asc" ? payments.OrderBy(c => c.Code)
                                        : payments.OrderByDescending(c => c.Code)).ToList();
                                    break;

                                case 1:
                                    payments = ((sortColumnDirection == "asc" ? payments.OrderBy(c => c.CustomerName) :
                                        payments.OrderByDescending(c => c.CustomerName))).ToList();
                                    break;

                                case 2:
                                    payments = (sortColumnDirection == "asc" ? payments.OrderBy(c => c.SalesPersonName) :
                                        payments.OrderByDescending(c => c.SalesPersonName)).ToList();
                                    break;

                                case 3:
                                    payments = ((sortColumnDirection == "asc" ? payments.OrderBy(c => c.CurrentBalance) :
                                        payments.OrderByDescending(c => c.CurrentBalance))).ToList();
                                    break;

                                case 4:
                                    payments = ((sortColumnDirection == "asc" ? payments.OrderBy(c => c.PaymentReceived) :
                                        payments.OrderByDescending(c => c.PaymentReceived))).ToList();
                                    break;

                                case 5:
                                    payments = ((sortColumnDirection == "asc" ? payments.OrderBy(c => c.NewBalance) :
                                        payments.OrderByDescending(c => c.NewBalance))).ToList();
                                    break;

                                case 6:
                                    payments = ((sortColumnDirection == "asc" ? payments.OrderBy(c => c.CreatedAt) :
                                        payments.OrderByDescending(c => c.CreatedAt))).ToList();
                                    break;
                            }
                        }
                    }
                    var createdDate = new DateTime();
                    if (date != "")
                    {
                        createdDate = Convert.ToDateTime(date);
                        payments = payments.Where(x => x.CreatedAt.Date == createdDate.Date).ToList();
                    }
                    if (!string.IsNullOrEmpty(searchValue))
                    {
                        payments = payments.Where(m => m.Code != null && m.Code.ToString().Contains(searchValue, StringComparison.OrdinalIgnoreCase)
                                        || (m.CustomerName != null && m.CustomerName.Contains(searchValue, StringComparison.OrdinalIgnoreCase))
                                        || (m.SalesPersonName != null && m.SalesPersonName.Contains(searchValue, StringComparison.OrdinalIgnoreCase))).ToList();
                    }

                    recordsTotal = payments.Count();
                    var data = payments.Skip(skip).Take(pageSize).ToList();
                    return Json(new { draw, recordsFiltered = recordsTotal, recordsTotal, data });
                }
                return Json(new { draw = 0, recordsFiltered = 0, recordsTotal = 0, data = payments });

            }

            catch (Exception ex)
            {
                LogException(ex);
                return null;
            }
        }
        [HttpGet]
        public IActionResult PaymentInvoice(string id)
        {
            try
            {
                var payment = _paymentRepo.FindAll(x => x.Id.Equals(new Guid(id))).
                Include(x => x.SalesPerson).
                Include(x => x.Customer).ThenInclude(x => x.ProfilePicture).
                Include(x => x.Customer).ThenInclude(x => x.Route).First();
                var terms = _configRepo.Get(AppConstants.TermsConditions);
                var file = _invoiceService.PaymentInvoice(payment, terms.Value);
                if (file != null)
                {
                    return File(fileStream: file, contentType: "application/pdf", fileDownloadName: "Payment-" + id + ".pdf");
                }
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        public IActionResult MarkedPayments()
        {
            ViewBag.SalesPersons = _userManager.Users.Where(x => x.DeletedAt == null && x.IsActive)
                   .Select(x => new SalesPerson
                   {
                       Id = x.Id,
                       Name = x.FirstName + " " + x.LastName
                   });
            return View();
        }
        [ModelValidationFilter]
        [HttpPost]
        public IActionResult EditPayment(string Id, double PaymentReceived)
        {
            try
            {
                var payment = _paymentRepo.Get(new Guid(Id));
                payment.PaymentReceived = PaymentReceived;
                payment.NewBalance = payment.CurrentBalance - PaymentReceived;
                _paymentRepo.Update(payment);
                _sp.UpdateCustomerBalance(payment.CustomerId);
                return Ok(new
                {
                    Message = string.Format(SuccessMessageConstants.UpdateSuccess, "Payment")
                });
            }
            catch(Exception ex)
            {
                LogException(ex);
                return BadRequest(string.Format(ErrorMessageConstants.UpdateFail, "Payment"));
            }
        }
        [HttpPost]
        public IActionResult UnMarkPayment(string id)
        {
            var claims = User.Claims.ToArray();
            var curruser = _userManager.Users.Include(x => x.Role).First(x => x.Id.Equals(claims[0].Value));
            try
            {
                var payment = _paymentRepo.FindAll(x => x.Id.Equals(new Guid(id))).Include(x => x.SalesPerson).FirstOrDefault();
                if (payment == null)
                {
                    return BadRequest(new
                    {
                        Message = string.Format(ErrorMessageConstants.NotFound, "Payment")
                    });
                }
                else
                {
                    if (_orderRepo.FindBy(x => x.PaymentId.Equals(new Guid(id))) == null)
                    {


                        payment.IsMarked = false;
                        _paymentRepo.Update(payment);
                        _sp.UpdateCustomerBalance(payment.CustomerId);
                        _notificationService.PushNotification(
                            string.Format(NotificationConstants.UnMarkedPayment, payment.PaymentCode, curruser.Email, curruser.Role.Name),
                            curruser.Id,
                            Url.Action("PaymentDetails", "Payment", new { id = payment.Id, flag = "readonly" }),
                            null,
                            null,
                            $"{payment.SalesPerson.Email}"
                            );
                        return Ok(new
                        {
                            Message = string.Format(SuccessMessageConstants.UnMarkSuccess, "Payment")
                        });
                    }
                    else
                    {
                        return BadRequest(new
                        {
                            Message = "Payment cannot be unmarked, please unmark the associated order first."
                        });
                    }
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
        public IActionResult PaymentDetails(string id, string flag)
        {
            var payment = _paymentRepo.FindAll(x => x.Id.Equals(new Guid(id)))
                .Include(x => x.SalesPerson)
                .FirstOrDefault();
            //var busname = payment.Customer.BusinessName;
            PaymentViewModel model = _mapper.Map<PaymentViewModel>(payment);
            //payment.Customer.BusinessName =  busname;
            ViewBag.PageTitle = "Edit Payment";
            ViewBag.Editable = true;
            if (flag.Equals("readonly"))
            {
                ViewBag.PageTitle = "Payment Details";
                ViewBag.Editable = false;
            }
            if (payment.DeletedAt == null)
                return View(model);
            else
            {
                TempData["Message"] = "Payment";
                return RedirectToAction("RecordDeleted", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeletePaymentAsync(string id)
        {
            try
            {
                if (_orderRepo.FindBy(x => x.PaymentId.Equals(new Guid(id))) == null)
                {
                    var payment = _paymentRepo.Get(new Guid(id));
                    payment.DeletedAt = DateTime.Now;
                    _paymentRepo.Update(payment);
                    _sp.UpdateCustomerBalance(payment.CustomerId);
                    await AddLogAsync(LogActions.DeletePayment.GetDescription(), payment.PaymentCode, LogsActionSrc.SPManagement.ToString());
                    return Ok(new
                    {
                        Message = string.Format(SuccessMessageConstants.DeleteSuccess, "Payment")
                    });
                }
                return BadRequest(new
                {
                    Message = "Payment cannot be deleted, please delete the associated order first."
                });
            }
            catch (Exception ex)
            {
                LogException(ex);
                return BadRequest(new
                {
                    Message = string.Format(ErrorMessageConstants.DeleteFail, "Payment")
                });
            }
        }
    }
}