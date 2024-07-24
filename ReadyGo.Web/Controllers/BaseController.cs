using log4net;
using log4net.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ReadyGo.Domain.Constants;
using ReadyGo.Domain.Entities;
using ReadyGo.Domain.Entities.Identity;
using ReadyGo.Domain.Entities.ViewModels;
using ReadyGo.Domain.Enum;
using ReadyGo.Infrastructure.ViewModel;
using ReadyGo.Persistence.Seeds;
using ReadyGo.Service.Interfaces;
using ReadyGo.Service.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyGo.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private IEmailService emailSender;
        private IFileService imageHelper;
        protected readonly ILog _logger = LogManager.GetLogger(typeof(LoggerManager));
        private IGenericRepository<LogInformation> logsRepo;
        private IGenericRepository<AssignedRoute> assignedRouteRepo;
        private IGenericRepository<ResourceFile> imgRepo;
        private IGenericRepository<PriceHistory> priceRepo;
        protected UserManager<ApplicationUser> _userManager => userManager ??= HttpContext?.RequestServices.GetService<UserManager<ApplicationUser>>();
        protected IEmailService _emailSender => emailSender ??= HttpContext?.RequestServices.GetService<IEmailService>();
        protected IFileService _imageHelper => imageHelper ??= HttpContext?.RequestServices.GetService<IFileService>();
        protected IGenericRepository<LogInformation> _logsRepo => logsRepo ??= HttpContext?.RequestServices.GetService<IGenericRepository<LogInformation>>();
        protected IGenericRepository<AssignedRoute> _assignedRouteRepo => assignedRouteRepo ??= HttpContext?.RequestServices.GetService<IGenericRepository<AssignedRoute>>();
        protected IGenericRepository<ResourceFile> _imgRepo => imgRepo ??= HttpContext?.RequestServices.GetService<IGenericRepository<ResourceFile>>();
        protected IGenericRepository<PriceHistory> _priceRepo => priceRepo ??= HttpContext?.RequestServices.GetService<IGenericRepository<PriceHistory>>();
       

        public LogInformation LogInformation(ApplicationUser changedBy, string actionSrc, string action, string userName, string ipAddress)
        {
            _logger.Info(action + " " + userName ?? "");
            var logInformation = new LogInformation()
            {
                ChangedBy = changedBy,
                IPAddress = ipAddress,
                ActionSource = actionSrc,
                Action = action + " " + userName ?? "",
                CreatedAt = DateTime.Now
            };
            _logsRepo.Insert(logInformation);
            return logInformation;
        }

        public void LogException(Exception exception)
        {
            _logger.Error("Error", exception);
        }

        [NonAction]
        public async Task AddLogAsync(string Action, string userName, string source)
        {
            var user = await _userManager.GetUserAsync(User);
            LogInformation(user, source, Action, userName, HttpContext.Connection.RemoteIpAddress.ToString());
        }

        [NonAction]
        public async Task<bool> InviteUser(ApplicationUser user, string email, EmailRequest emailRequest, bool logFlag)
        {
            string code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callbackUrl = Url.Action("SetPassword", "Account", new { user.Email, code }, protocol: Request.Scheme);
            //emailRequest.Body = EmailConstants.InvitationBody + " <a href=\"" + callbackUrl + "\">here</a>";
            emailRequest.Body = string.Format(EmailConstants.EmailBodyHtml,$"{user.FirstName} {user.LastName}",callbackUrl);
            emailRequest.ToEmail = user.Email;
            emailRequest.Subject = EmailConstants.InvitationSubject;
            emailRequest.IsBodyHtml = true;
            if (await _emailSender.SendEmailAsync(emailRequest))
            {
                user.InviteTime = DateTime.Now;
                await _userManager.UpdateAsync(user);
                if (logFlag)
                {
                    await AddLogAsync(LogActions.SendInvite.GetDescription(), user.UserName, LogsActionSrc.UserManagement.ToString());
                }
                return true;
            }
            return false;
        }

        [NonAction]
        public string RouteSp(List<AssignedRoute> SalesPersons)
        {
            if (SalesPersons != null && SalesPersons.Count > 0)
            {
                var tempSp = SalesPersons.FirstOrDefault(x => x.TemporaryAssignedTill.HasValue && x.TemporaryAssignedTill.Value.Date >= DateTime.Today);
                if (tempSp != null)
                {
                    return tempSp.SalesPerson.FirstName + " " + tempSp.SalesPerson.LastName;
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
    
        [NonAction]
        public AssignedRoute CurrentRoute(List<AssignedRoute> Routes)
        {
            if (Routes != null && Routes.Count > 0)
            {
                var tempRoute = Routes.FirstOrDefault(x => x.TemporaryAssignedTill.HasValue && x.TemporaryAssignedTill.Value.Date >= DateTime.Today);
                if (tempRoute != null)
                {
                    return tempRoute;
                }
                else
                {
                    var route = Routes.FirstOrDefault(x => !x.TemporaryAssignedTill.HasValue);
                    return route;
                }
            }
            return null;
        }
        [NonAction]
        public List<AssignedRoute> GetAllSpRoutes(List<AssignedRoute> Routes)
        {
            List<AssignedRoute> assignedRoutes = new List<AssignedRoute>();
            if (Routes != null && Routes.Count > 0)
            {
                var tempRoute = Routes.FirstOrDefault(x => x.TemporaryAssignedTill.HasValue && x.TemporaryAssignedTill.Value.Date >= DateTime.Today);
                if (tempRoute != null)
                {
                    assignedRoutes.Add(tempRoute);
                }
                var route = Routes.FirstOrDefault(x => !x.TemporaryAssignedTill.HasValue);
                if (route != null) {
                    assignedRoutes.Add(route);
                }
            }
            return assignedRoutes;
        }
        [NonAction]
        public List<Customer> SpRouteCustomers(List<AssignedRoute> assignedRoutes)
        {
            List<Customer> customers = new List<Customer>();
            var permRoute = assignedRoutes.FirstOrDefault(x => x.TemporaryAssignedTill == null);
            if (permRoute != null)
            {
                customers.AddRange(permRoute.Route.Customers.Where(x=>x.DeletedAt==null && x.IsActive).ToList());
            }
            var tempRoute = assignedRoutes.FirstOrDefault(x => x.TemporaryAssignedTill != null
            && x.TemporaryAssignedTill.Value.Date >= DateTime.Today);
            if (tempRoute != null)
            {
                customers.AddRange(tempRoute.Route.Customers.Where(x => x.DeletedAt == null && x.IsActive).ToList());
            }
            return customers;
        }
        [NonAction]
        public AssignedRoute TempRoute(List<AssignedRoute> Routes)
        {
            if (Routes != null && Routes.Count > 0)
            {
                var tempRoute = Routes.FirstOrDefault(x => x.TemporaryAssignedTill.HasValue && x.TemporaryAssignedTill.Value.Date >= DateTime.Today);
                if (tempRoute != null)
                {
                    return tempRoute;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

        [NonAction]
        public AssignedRoute PermanentRoute(List<AssignedRoute> Routes)
        {
            if (Routes != null && Routes.Count > 0)
            {
                var route = Routes.FirstOrDefault(x => !x.TemporaryAssignedTill.HasValue);
                return route;
            }
            return null;
        }
        [NonAction]
        public ApplicationUser HandleImage(IFormFile file, ApplicationUser appUser)
        {
            if (file != null)
            {
                if (file.Length > 0 && file.ContentType.Contains("image"))
                {
                    string id = appUser.Id;
                    ResourceFile resultImage = _imageHelper.SaveReshape(file, id);
                    if (resultImage != null)
                    {
                        if (appUser.ProfileImage != null)
                        {
                            appUser.ProfileImage.File = resultImage.File;
                            _imgRepo.Update(appUser.ProfileImage);
                        }
                        else
                        {
                            appUser.ProfileImage = resultImage;
                            _imgRepo.Insert(resultImage);
                        }
                    }
                }
            }
            return appUser;
        }
        [NonAction]
        public RequestModel RequestDetails(HttpRequest Request)
        {
            var requestModel = new RequestModel();
            requestModel.Draw = Request.Form["draw"].FirstOrDefault();
            requestModel.Status = Request.Form["status"].FirstOrDefault();
            requestModel.Start = Request.Form["start"].FirstOrDefault();
            requestModel.Length = Request.Form["length"].FirstOrDefault();
            requestModel.SortColumn = Request.Form["order[0][column]"].FirstOrDefault();
            requestModel.SortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
            requestModel.SearchValue = Request.Form["search[value]"].FirstOrDefault()?.Trim() ?? Request.Form["search"].FirstOrDefault().Trim();
            requestModel.PageSize = Convert.ToInt32(requestModel.Length ?? "0");
            requestModel.Skip = Convert.ToInt32(requestModel.Start ?? "0");
            requestModel.Role = Request.Form["role"].FirstOrDefault();
            return requestModel;
        }
        [NonAction]
        public List<OrdersTableViewModel> FindTotal(List<Order> orders)
        {
            List<OrdersTableViewModel> ordersList = new List<OrdersTableViewModel>();
            foreach (var order in orders)
            {
                double credit = 0;
                double productDiscount = 0;
                double gross = 0;
                double total = 0;
                double waste = 0;
                double payment = 0;
                double discount = order.Discount;
                double returnAmount = 0;
                double price;
                if (order.Orders.Count > 0)
                {
                    foreach (var orderDetail in order.Orders.Where(x => x.PromotionId == null))
                    {
                        productDiscount += (orderDetail.Discount * orderDetail.Quantity);
                        price = orderDetail.Price;
                        gross += price * orderDetail.Quantity;
                        total += price * orderDetail.Quantity;
                    }
                }
                if (order.ReturnOrders.Count > 0)
                {
                    foreach (var orderDetail in order.ReturnOrders)
                    {
                        price = orderDetail.Price;
                        returnAmount += (price - orderDetail.Discount) * orderDetail.Quantity;
                        total -= (price - orderDetail.Discount) * orderDetail.Quantity;
                    }
                }
                if (order.WasteOrders.Count > 0)
                {
                    foreach (var orderDetail in order.WasteOrders)
                    {
                        price = orderDetail.Price;
                        waste += (price - orderDetail.Discount) * orderDetail.Quantity;
                        total -= (price - orderDetail.Discount) * orderDetail.Quantity;
                    }
                }
                if (order.PaymentId != null)
                {
                    payment = order.Payment.PaymentReceived;
                    if (total + productDiscount < 0)
                    {
                        credit = Math.Round(total - productDiscount + discount - payment);
                    }
                    else
                    {
                        credit = Math.Round(total - productDiscount - discount - payment);
                    }
                }
                double totalWithoutDiscount = total - productDiscount;
                ordersList.Add(new OrdersTableViewModel()
                {
                    CustomerName =  order.Customer.BusinessName,
                    SalesPersonName = order.SalesPerson != null ? 
                        order.SalesPerson.FirstName + " " + order.SalesPerson.LastName : "--",
                    Credit = credit,
                    Gross = Math.Round(gross),
                    Id = order.Id,
                    Return = Math.Round(returnAmount),
                    Total = total > 0 ? Math.Round(total - (productDiscount + discount)) : 
                        Math.Round(total - productDiscount + discount),
                    Waste = Math.Round(waste + returnAmount),
                    InvoiceDiscount = Math.Round(discount, 2),
                    TotalDiscount = Math.Round(discount + productDiscount, 2),
                    TotalDiscountPercentage = total == 0 ? 0 :
                        Math.Abs(Math.Round(((discount + productDiscount) / total) * 100, 2)),
                    InvoiceDiscountPercentage = totalWithoutDiscount == 0 ? 0 :
                        Math.Abs(Math.Round((discount / totalWithoutDiscount) * 100, 2)),
                    Status = order.Status.ToString(),
                    Payment = payment,
                    OrderCode = order.OrderCode,
                    CreatedAt = order.CreatedAt,
                });

            }

            return ordersList;
        }
        [NonAction]
        public OrderDetailsViewModel GetOrderDetails(Order order)
        {
            var prices = _priceRepo.FindAll(x=>x.From.Date<=order.CreatedAt.Date).OrderByDescending(x=>x.From).ToList();

            double price = 0;
            double gross = 0;
            double waste = 0;
            double returnAmount = 0;
            double totalWithoutDiscount = 0.0;
            double tax = 0.0;
            var orderDetails = new OrderDetailsViewModel
            {
                CustomerCode = string.IsNullOrEmpty(order.Customer.AxCode)?"-": order.Customer.AxCode,
                CustomerId = order.CustomerId,
                CustomerName = order.Customer.FirstName + " " + order.Customer.LastName,
                BusinessName = string.IsNullOrEmpty(order.Customer.BusinessName) ? "-" : order.Customer.BusinessName,
                CustomerPhone = order.Customer.PhoneNumber,
                CustomerAddress = string.IsNullOrEmpty(order.Customer.Address1) ? "-" : order.Customer.Address1,
                Credit = 0,
                InvoiceDiscount = Math.Round(order.Discount, 2),
                SalesPersonId = order.SalesPersonId,
                Id = order.Id,
                VehicleNo = order.Vehicle != null ? order.Vehicle.VehicleNumber : "---",
                DriverName = !string.IsNullOrEmpty(order.DriverName) ? order.DriverName : "---",
                IsMarked = order.IsMarked,
                OrderCode = order.OrderCode,
                Status = order.Status,
                ApprovalFor = order.ApprovalFor,
                Payment = 0,
                CreatedAt = order.CreatedAt,
                RouteName = order.Customer.Route?.Name ?? "---",
                SalesPersonName = order.SalesPerson.FirstName + " " + order.SalesPerson.LastName
            };
            orderDetails.Details = new List<OrderDetailsTableViewModel>();
            var productName = string.Empty;
            var discount = 0.0;
            var productsDiscount = 0.0;
            if (order.Orders.Count > 0)
            {
                foreach (var orderDetail in order.Orders)
                {
                    if (orderDetail.PromotionId == null)
                    {
                        tax = prices.OrderByDescending(x=>x.From).FirstOrDefault(x => x.ProductId.Equals(orderDetail.ProductId))?.Tax ?? 0;
                        price = orderDetail.Price;
                        discount = orderDetail.Discount;
                        productsDiscount += (discount * orderDetail.Quantity);
                        gross = price * orderDetail.Quantity;
                        tax = (gross - (discount * orderDetail.Quantity)) - ((gross - (discount * orderDetail.Quantity)) / (1 + (tax / 100)));
                        orderDetails.TotalTax += tax;
                        orderDetails.Gross += gross;
                        orderDetails.Total += gross;
                        if (orderDetail.Product.ProductId != null)
                        {
                            productName = orderDetail.Product.VariantOf.Name + " - " + orderDetail.Product.Name;
                        }
                        else
                        {
                            productName = orderDetail.Product.Name;
                        }
                        orderDetails.Details.Add(new OrderDetailsTableViewModel()
                        {
                            ProductCode = orderDetail.Product.AxCode,
                            Tax = tax,
                            ProductName = productName,
                            Quantity = orderDetail.Quantity,
                            Promos = "---",
                            Gross = Math.Round(gross),
                            UnitPrice = Math.Round(price, 2),
                            Waste = 0,
                            Discount = Math.Round(orderDetail.Discount, 2)
                        }) ;
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
                        orderDetails.Details.Add(new OrderDetailsTableViewModel()
                        {
                            ProductCode = orderDetail.Product.AxCode,
                            ProductName = productName,
                            Quantity = orderDetail.Quantity,
                            Promos = orderDetail.Promotion.Title,
                            Gross = 0,
                            UnitPrice = 0,
                            Waste = 0,
                            Discount = 0,
                        });
                    }

                }
            }
            if (order.ReturnOrders.Count > 0)
            {
                foreach (var orderDetail in order.ReturnOrders)
                {
                    price = (float)orderDetail.Price;
                    discount = orderDetail.Discount;
                    returnAmount = (price - discount) * orderDetail.Quantity;
                    orderDetails.Total -= returnAmount;
                    orderDetails.Return -= returnAmount;
                    tax = prices.OrderByDescending(x => x.From).FirstOrDefault(x => x.ProductId.Equals(orderDetail.ProductId))?.Tax ?? 0;
                    tax = (Math.Abs(returnAmount)) - ((Math.Abs(returnAmount)) / (1 + (tax / 100)));
                    orderDetails.TotalReturnTax += tax;
                    if (orderDetail.Product.ProductId != null)
                    {
                        productName = orderDetail.Product.VariantOf.Name + " - " + orderDetail.Product.Name;
                    }
                    else
                    {
                        productName = orderDetail.Product.Name;
                    }
                    orderDetails.Details.Add(new OrderDetailsTableViewModel()
                    {
                        ProductCode = orderDetail.Product.AxCode,
                        ProductName = productName,
                        Quantity = orderDetail.Quantity,
                        Promos = "---",
                        Gross = 0,
                        UnitPrice = price,
                        Waste = Math.Round(returnAmount, 2),
                        Discount = discount,
                        Tax = tax,
                        Reason = orderDetail.ReturnReason?.ToString() ?? "---"
                    });
                }
            }
            if (order.WasteOrders.Count > 0)
            {
                foreach (var orderDetail in order.WasteOrders)
                {
                    discount = orderDetail.Discount;
                    price = orderDetail.Price;
                    waste = (price - discount) * orderDetail.Quantity;
                    orderDetails.Total -= waste;
                    orderDetails.Waste -= waste;
                    tax = prices.OrderByDescending(x => x.From).FirstOrDefault(x => x.ProductId.Equals(orderDetail.ProductId))?.Tax ?? 0; 
                    tax = (Math.Abs(waste) - ((Math.Abs(waste) / (1 + (tax / 100)))));
                    orderDetails.TotalReturnTax += tax;

                    if (orderDetail.Product.ProductId != null)
                    {
                        productName = orderDetail.Product.VariantOf.Name + " - " + orderDetail.Product.Name;
                    }
                    else
                    {
                        productName = orderDetail.Product.Name;
                    }
                    orderDetails.Details.Add(new OrderDetailsTableViewModel()
                    {
                        ProductCode = orderDetail.Product.AxCode,
                        ProductName = productName,
                        Quantity = orderDetail.Quantity,
                        Promos = "---",
                        Gross = 0,
                        UnitPrice = Math.Round(price, 2),
                        Waste = Math.Round(waste),
                        Discount = discount,
                        Tax = tax,
                        Reason = orderDetail.WasteReason?.ToString() ?? "---",
                        IsWaste = true
                    });
                }
            }
            discount = order.Discount;
            orderDetails.TotalDiscountPercentage = orderDetails.Total == 0 ? 0 :
                Math.Abs(Math.Round(((discount + productsDiscount) / orderDetails.Total) * 100, 2));

            totalWithoutDiscount = orderDetails.Total - productsDiscount;

            orderDetails.InvoiceDiscountPercentage = totalWithoutDiscount == 0 ? 0 :
                Math.Abs(Math.Round((discount / totalWithoutDiscount) * 100, 2));

            orderDetails.TotalDiscount = order.Discount + productsDiscount;

            if (order.PaymentId != null && !order.Payment.IsMarked && order.Payment.DeletedAt == null)
            {
                orderDetails.Payment = order.Payment.PaymentReceived;
                if (orderDetails.Total + productsDiscount < 0)
                {
                    orderDetails.Credit = Math.Round(orderDetails.Total - productsDiscount + discount - orderDetails.Payment);
                }
                else
                {
                    orderDetails.Credit = Math.Round(orderDetails.Total - productsDiscount - discount - orderDetails.Payment);
                }

            }
            orderDetails.ProductsDiscount = productsDiscount;
            return orderDetails;
        }
    }
}