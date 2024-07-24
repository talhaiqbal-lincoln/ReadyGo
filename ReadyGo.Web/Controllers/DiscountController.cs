using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadyGo.Domain.Constants;
using ReadyGo.Domain.Entities;
using ReadyGo.Domain.Entities.ViewModels;
using ReadyGo.Domain.Enum;
using ReadyGo.Infrastructure.Filters;
using ReadyGo.Persistence.Seeds;
using ReadyGo.Service.Interfaces;
using ReadyGo.Service.Repositories.Interfaces;
using ReadyGo.Service.Stored_Procedures.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyGo.Web.Controllers
{
    public class DiscountController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Route> _routeRepo;
        private readonly IGenericRepository<Customer> _custRepo;
        private readonly IGenericRepository<Configuration> _configRepo;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<Discount> _discountRepo;
        private readonly IGenericRepository<Order> _orderRepo;
        private readonly INotificationService _notificationService;
        private readonly IProcedures _sp;
        public DiscountController(IGenericRepository<Route> routeRepo,
            IGenericRepository<Customer> custRepo, IProcedures sp,
            IGenericRepository<Configuration> configRepo,
            IGenericRepository<Product> productRepo,
            IGenericRepository<Discount> discountRepo,
            IGenericRepository<Order> orderRepo,
            INotificationService notificationService,
            IMapper mapper)
        {
            _sp = sp;
            _routeRepo = routeRepo;
            _custRepo = custRepo;
            _configRepo = configRepo;
            _productRepo = productRepo;
            _discountRepo = discountRepo;
            _orderRepo = orderRepo;
            _notificationService = notificationService;
            _mapper = mapper;
        }
        [HttpGet]
        [TypeFilter(typeof(AdminAccessFilter))]
        public IActionResult Overview()
        {
            return View();
        }
        //[TypeFilter(typeof(AdminAccessFilter))]
        [HttpGet]
        public IActionResult SalesManagerDiscount()
        {
            return View();
        }
        //[TypeFilter(typeof(AdminAccessFilter))]
        [HttpGet]
        public IActionResult MarketingManagerDiscount()
        {
            return View();
        }
        [TypeFilter(typeof(AdminAccessFilter))]
        [HttpGet]
        public IActionResult Config()
        {
            var discountConfig = _configRepo.FindAll(x => x.ConfigKey == "SalesManager_DiscountThrashHold" || x.ConfigKey == "MarketingManager_DiscountThrashHold").ToList();
            return View(discountConfig);
        }
        [HttpGet]
        public IActionResult Setup()
        {
            ViewBag.Route = _routeRepo.GetAll().Select(x => new { x.Id, x.Name });
            return View();
        }
        [HttpPost]
        public IActionResult GetDiscount()
        {
            try
            {
                var requestDetails = RequestDetails(Request);
                int recordsTotal = 0;
                var discounts = _discountRepo.FindAll(x => x.DeletedAt == null)
                    .Include(x => x.Customer).ThenInclude(x => x.Route)
                    .Include(x => x.Product).ThenInclude(x => x.VariantOf)
                    .Include(x => x.Product).ThenInclude(x => x.Category)
                    .Include(x => x.Route)
                    .Select(x => new
                    {
                        x.Id,
                        customerLocation = x.Customer == null ? "---" : x.Customer.Route.Name,
                        customerName = x.Customer == null ? "---" : x.Customer.BusinessName,
                        productName = x.Product == null ? "---" : x.Product.VariantOf != null ? x.Product.VariantOf.Name + " - " + x.Product.Name : x.Product.Name,
                        discount = x.DiscountValue,
                        //routeName = x.Route == null ? "N/A" : x.Route.Name,
                        x.IsPercentage,
                        x.IsActive,
                        category = x.Product.Category.Name
                    }).ToList();


                if (!(string.IsNullOrEmpty(requestDetails.SortColumn) && string.IsNullOrEmpty(requestDetails.SortColumnDirection)))
                {
                    int column = Int32.Parse(requestDetails.SortColumn);
                    switch (column)
                    {
                        case 0:
                            discounts = (requestDetails.SortColumnDirection == "asc" ? discounts.OrderBy(c => c.customerLocation) : discounts.OrderByDescending(c => c.customerLocation)).ToList();
                            break;
                        case 1:
                            discounts = (requestDetails.SortColumnDirection == "asc" ? discounts.OrderBy(c => c.customerName) : discounts.OrderByDescending(c => c.customerName)).ToList();
                            break;
                        case 2:
                            discounts = (requestDetails.SortColumnDirection == "asc" ? discounts.OrderBy(c => c.productName) : discounts.OrderByDescending(c => c.productName)).ToList();
                            break;
                        case 3:
                            discounts = (requestDetails.SortColumnDirection == "asc" ? discounts.OrderBy(c => c.discount) : discounts.OrderByDescending(c => c.discount)).ToList();
                            break;
                    }
                }
                if (requestDetails.Status != "All")
                {
                    discounts = requestDetails.Status.Equals("Active") ? discounts.Where(x => x.IsActive).ToList() : discounts.Where(x => !x.IsActive).ToList();
                }
                if (!string.IsNullOrEmpty(requestDetails.SearchValue))
                {
                    discounts = discounts.Where(m => m.customerLocation.Contains(requestDetails.SearchValue, StringComparison.OrdinalIgnoreCase)
                                        || m.customerName.Contains(requestDetails.SearchValue, StringComparison.OrdinalIgnoreCase)
                                        || m.productName.Contains(requestDetails.SearchValue, StringComparison.OrdinalIgnoreCase)
                                        || m.discount.ToString().Contains(requestDetails.SearchValue, StringComparison.OrdinalIgnoreCase)).ToList();
                }
                recordsTotal = discounts.Count();
                var data = discounts.Skip(requestDetails.Skip).Take(requestDetails.PageSize).ToList();
                return Json(new { requestDetails.Draw, recordsFiltered = recordsTotal, recordsTotal, data });

            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }
        [HttpPost]
        public IActionResult GetPending()
        {
            try
            {
                var requestDetails = RequestDetails(Request);
                ApprovalFor role = requestDetails.Role == "SalesManager" ? ApprovalFor.SalesManager : ApprovalFor.MarketingManager;
                int recordsTotal = 0;
                var order = _orderRepo.FindAll(x => !x.IsMarked && x.DeletedAt == null && x.Status == ApprovalStatus.Pending && x.ApprovalFor == role)
                    .Include(x => x.Customer)
                    .Include(x=>x.SalesPerson)
                    .Include(x => x.Orders)
                    .Include(x => x.ReturnOrders)
                    .Include(x => x.WasteOrders)
                    .Include(x => x.Payment)
                    .ToList();
                var orderData = FindTotal(order);

                if (!(string.IsNullOrEmpty(requestDetails.SortColumn) && string.IsNullOrEmpty(requestDetails.SortColumnDirection)))
                {
                    int column = Int32.Parse(requestDetails.SortColumn);
                    switch (column)
                    {
                        case 0:
                            orderData = (requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.OrderCode) :
                                orderData.OrderByDescending(c => c.OrderCode)).ToList();
                            break;
                        case 1:
                            orderData = (requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.SalesPersonName) :
                                orderData.OrderByDescending(c => c.SalesPersonName)).ToList();
                            break;

                        case 2:
                            orderData = ((requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.CustomerName) : orderData.OrderByDescending(c => c.CustomerName))).ToList();
                            break;

                        case 3:
                            orderData = ((requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.Gross) : orderData.OrderByDescending(c => c.Gross))).ToList();
                            break;

                        case 4:
                            orderData = ((requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.InvoiceDiscount) :
                                orderData.OrderByDescending(c => c.InvoiceDiscount))).ToList();
                            break;
                        case 5:
                            orderData = ((requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.InvoiceDiscountPercentage) :
                                orderData.OrderByDescending(c => c.InvoiceDiscountPercentage))).ToList();
                            break;
                        case 6:
                            orderData = ((requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.TotalDiscount) :
                                orderData.OrderByDescending(c => c.TotalDiscount))).ToList();
                            break;
                        case 7:
                            orderData = ((requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.TotalDiscountPercentage) :
                                orderData.OrderByDescending(c => c.TotalDiscountPercentage))).ToList();
                            break;
                        case 8:
                            orderData = ((requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.Waste) : orderData.OrderByDescending(c => c.Waste))).ToList();
                            break;
                        case 9:
                            orderData = ((requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.Total) : orderData.OrderByDescending(c => c.Total))).ToList();
                            break;
                      
                        case 11:
                            orderData = ((requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.Credit) :
                                orderData.OrderByDescending(c => c.Credit))).ToList();
                            break;

                        case 12:
                            orderData = ((requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.CreatedAt) :
                                orderData.OrderByDescending(c => c.CreatedAt))).ToList();
                            break;
                    }
                }
                if (!string.IsNullOrEmpty(requestDetails.SearchValue))
                {
                    orderData = orderData.Where(m => m.OrderCode != null && m.OrderCode.ToString().Contains(requestDetails.SearchValue, StringComparison.OrdinalIgnoreCase)
                                            || (m.CustomerName.Contains(requestDetails.SearchValue, StringComparison.OrdinalIgnoreCase)) ||
                                            m.SalesPersonName.Contains(requestDetails.SearchValue, StringComparison.OrdinalIgnoreCase)).ToList();
                }
                recordsTotal = orderData.Count();
                var data = orderData.Skip(requestDetails.Skip).Take(requestDetails.PageSize).ToList();
                return Json(new { requestDetails.Draw, recordsFiltered = recordsTotal, recordsTotal, data });
                    
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }
        [HttpPost]
        public IActionResult GetApproved()
        {
            try
            {
                var requestDetails = RequestDetails(Request);
                ApprovalFor role = requestDetails.Role == "SalesManager" ? ApprovalFor.SalesManager : ApprovalFor.MarketingManager;
                int recordsTotal = 0;
                var order = _orderRepo.FindAll(x => !x.IsMarked && x.DeletedAt == null && x.Status == ApprovalStatus.Approved && x.ApprovalFor == role)
                    .Include(x => x.Customer)
                    .Include(x => x.SalesPerson)
                    .Include(x => x.Orders)
                    .Include(x => x.ReturnOrders)
                    .Include(x => x.WasteOrders)
                    .Include(x => x.Payment)
                    .ToList();
                var orderData = FindTotal(order);

                if (!(string.IsNullOrEmpty(requestDetails.SortColumn) && string.IsNullOrEmpty(requestDetails.SortColumnDirection)))
                {
                    int column = Int32.Parse(requestDetails.SortColumn);
                    switch (column)
                    {
                        case 0:
                            orderData = (requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.OrderCode) :
                                orderData.OrderByDescending(c => c.OrderCode)).ToList();
                            break;
                        case 1:
                            orderData = (requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.SalesPersonName) :
                                orderData.OrderByDescending(c => c.SalesPersonName)).ToList();
                            break;

                        case 2:
                            orderData = ((requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.CustomerName) : orderData.OrderByDescending(c => c.CustomerName))).ToList();
                            break;

                        case 3:
                            orderData = ((requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.Gross) : orderData.OrderByDescending(c => c.Gross))).ToList();
                            break;

                        case 4:
                            orderData = ((requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.InvoiceDiscount) :
                                orderData.OrderByDescending(c => c.InvoiceDiscount))).ToList();
                            break;
                        case 5:
                            orderData = ((requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.InvoiceDiscountPercentage) :
                                orderData.OrderByDescending(c => c.InvoiceDiscountPercentage))).ToList();
                            break;
                        case 6:
                            orderData = ((requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.TotalDiscount) : 
                                orderData.OrderByDescending(c => c.TotalDiscount))).ToList();
                            break;
                        case 7:
                            orderData = ((requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.TotalDiscountPercentage) : 
                                orderData.OrderByDescending(c => c.TotalDiscountPercentage))).ToList();
                            break;
                        case 8:
                            orderData = ((requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.Waste) : orderData.OrderByDescending(c => c.Waste))).ToList();
                            break;
                        case 9:
                            orderData = ((requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.Total) : orderData.OrderByDescending(c => c.Total))).ToList();
                            break;
                        //case 6:
                        //    orderData = ((requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.Total) : orderData.OrderByDescending(c => c.Total))).ToList();
                        //    break;

                        case 11:
                            orderData = ((requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.Credit) :
                                orderData.OrderByDescending(c => c.Credit))).ToList();
                            break;

                        case 12:
                            orderData = ((requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.CreatedAt) :
                                orderData.OrderByDescending(c => c.CreatedAt))).ToList();
                            break;
                    }
                }
                if (!string.IsNullOrEmpty(requestDetails.SearchValue))
                {
                    orderData = orderData.Where(m => m.OrderCode != null && m.OrderCode.ToString().Contains(requestDetails.SearchValue, StringComparison.OrdinalIgnoreCase)
                                            || (m.CustomerName.Contains(requestDetails.SearchValue, StringComparison.OrdinalIgnoreCase)) ||
                                            m.SalesPersonName.Contains(requestDetails.SearchValue, StringComparison.OrdinalIgnoreCase)).ToList();
                }
                recordsTotal = orderData.Count();
                var data = orderData.Skip(requestDetails.Skip).Take(requestDetails.PageSize).ToList();
                return Json(new { requestDetails.Draw, recordsFiltered = recordsTotal, recordsTotal, data });

            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }
        [HttpPost]
        public IActionResult GetReAdjusted()
        {
            try
            {
                var requestDetails = RequestDetails(Request);
                ApprovalFor role = requestDetails.Role == "SalesManager" ? ApprovalFor.SalesManager : ApprovalFor.MarketingManager;
                int recordsTotal = 0;
                var order = _orderRepo.FindAll(x => !x.IsMarked && x.DeletedAt == null && x.Status == ApprovalStatus.ReAdjusted && x.ApprovalFor == role)
                    .Include(x => x.Customer)
                    .Include(x => x.SalesPerson)
                    .Include(x => x.Orders)
                    .Include(x => x.ReturnOrders)
                    .Include(x => x.WasteOrders)
                    .Include(x => x.Payment)
                    .ToList();
                var orderData = FindTotal(order);

                if (!(string.IsNullOrEmpty(requestDetails.SortColumn) && string.IsNullOrEmpty(requestDetails.SortColumnDirection)))
                {
                    int column = Int32.Parse(requestDetails.SortColumn);
                    switch (column)
                    {
                        case 0:
                            orderData = (requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.OrderCode) :
                                orderData.OrderByDescending(c => c.OrderCode)).ToList();
                            break;
                        case 1:
                            orderData = (requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.SalesPersonName) :
                                orderData.OrderByDescending(c => c.SalesPersonName)).ToList();
                            break;

                        case 2:
                            orderData = ((requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.CustomerName) : orderData.OrderByDescending(c => c.CustomerName))).ToList();
                            break;

                        case 3:
                            orderData = ((requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.Gross) : orderData.OrderByDescending(c => c.Gross))).ToList();
                            break;

                        case 4:
                            orderData = ((requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.InvoiceDiscount) :
                                orderData.OrderByDescending(c => c.InvoiceDiscount))).ToList();
                            break;
                        case 5:
                            orderData = ((requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.InvoiceDiscountPercentage) :
                                orderData.OrderByDescending(c => c.InvoiceDiscountPercentage))).ToList();
                            break;
                        case 6:
                            orderData = ((requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.TotalDiscount) : orderData.OrderByDescending(c => c.TotalDiscount))).ToList();
                            break;
                        case 7:
                            orderData = ((requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.TotalDiscountPercentage) : 
                                orderData.OrderByDescending(c => c.TotalDiscountPercentage))).ToList();
                            break;
                        case 8:
                            orderData = ((requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.Waste) : orderData.OrderByDescending(c => c.Waste))).ToList();
                            break;
                        case 9:
                            orderData = ((requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.Total) : orderData.OrderByDescending(c => c.Total))).ToList();
                            break;
                        //case 6:
                        //    orderData = ((requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.Total) : orderData.OrderByDescending(c => c.Total))).ToList();
                        //    break;

                        case 11:
                            orderData = ((requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.Credit) :
                                orderData.OrderByDescending(c => c.Credit))).ToList();
                            break;
                        case 12:
                            orderData = ((requestDetails.SortColumnDirection == "asc" ? orderData.OrderBy(c => c.CreatedAt) :
                                orderData.OrderByDescending(c => c.CreatedAt))).ToList();
                            break;
                    }
                }
                if (!string.IsNullOrEmpty(requestDetails.SearchValue))
                {
                    orderData = orderData.Where(m => m.OrderCode != null && m.OrderCode.ToString().Contains(requestDetails.SearchValue, StringComparison.OrdinalIgnoreCase)
                                            || (m.CustomerName.Contains(requestDetails.SearchValue, StringComparison.OrdinalIgnoreCase)) ||
                                            m.SalesPersonName.Contains(requestDetails.SearchValue, StringComparison.OrdinalIgnoreCase)).ToList();
                }
                recordsTotal = orderData.Count();
                var data = orderData.Skip(requestDetails.Skip).Take(requestDetails.PageSize).ToList();
                return Json(new { requestDetails.Draw, recordsFiltered = recordsTotal, recordsTotal, data });

            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }
        [HttpPost]
        public async Task<IActionResult> SaveDiscountConfigAsync()
        {
            try
            {
                var smThrashHold = Request.Form["sm-discount"].ToString();
                var mmThrashHold = Request.Form["mm-discount"].ToString();
                var discountConfig = _configRepo.FindAll(x => x.ConfigKey == "SalesManager_DiscountThrashHold" || x.ConfigKey == "MarketingManager_DiscountThrashHold").ToList();
                discountConfig.Where(x => x.ConfigKey == "SalesManager_DiscountThrashHold").FirstOrDefault().Value = smThrashHold;
                discountConfig.Where(x => x.ConfigKey == "MarketingManager_DiscountThrashHold").FirstOrDefault().Value = mmThrashHold;
                _configRepo.UpdateRange(discountConfig);
                await AddLogAsync(LogActions.Update.ToString(), "Discount cofiguration for marketing/sales manager", LogsActionSrc.DiscountManagement.ToString());
                return Ok(new
                {
                    Message = string.Format(SuccessMessageConstants.UpdateSuccess, "Discount Configurations")
                });
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
        public IActionResult GetCustomers(string id)
        {
            try
            {
                var customers = _routeRepo.FindAll(x => x.Id == new Guid(id))
                .Include(x => x.Customers.Where(x => x.DeletedAt == null)).FirstOrDefault()
                .Customers.Select(x => new
                {
                    x.Id,
                    custName = x.BusinessName
                }).ToList();
                return Ok(new
                {
                    customers
                });
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
        public IActionResult CustomerRule()
        {
            ViewBag.Route = _routeRepo.GetAll().Select(x => new { x.Id, x.Name });
            ViewBag.Products = _productRepo.FindAll(x => x.ProductId == null)
                .Include(x => x.Category)
                .Select(x => new
                {
                    x.Id,
                    ProductName = x.Category.Name + " - " + x.Name
                });
            return View();
        }
        [HttpGet]
        public IActionResult ProductRule()
        {
            ViewBag.Products = _productRepo.FindAll(x => x.ProductId == null)
                .Include(x => x.Category)
                .Select(x => new
                {
                    x.Id,
                    ProductName = x.Category.Name + " - " + x.Name
                });
            return View();
        }
        [HttpGet]
        public IActionResult RouteRule()
        {
            ViewBag.Routes = _routeRepo.FindAll(x => x.DeletedAt == null).Select(x => new { x.Id, x.Name });
            return View();
        }
        [HttpGet]
        public IActionResult GetSalesPerson(string id)
        {
            try
            {
                var routes = _assignedRouteRepo.FindAll(x => x.RouteId == new Guid(id)).Include(x => x.SalesPerson).ToList();
                var sp = RouteSp(routes);
                return Ok(new
                {
                    Name = sp
                });
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
        public IActionResult GetVariant(string id)
        {
            try
            {
                var variants = _productRepo.FindAll(x => x.ProductId == new Guid(id)).Select(x => new { x.Id, x.Name });
                return Ok(new
                {
                    variants
                });
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
        public async Task<IActionResult> AddDiscountAsync(IFormCollection form)
        {
            Discount discountObj = new Discount();
            Discount discount = new Discount();
            var msg = "";
            var discountValue = "";
            if (form["rule"].Equals("CustomerRule"))
            {
                if (form.Keys.Contains("hasProduct"))
                {
                    discount = _discountRepo.FindAll(x => x.ProductID.Equals(new Guid(form["variant"])) && x.CustomerId.Equals(new Guid(form["customer"]))).FirstOrDefault();
                    msg = "Discount on this specfic product against this customer";
                }
                else
                {
                    discount = _discountRepo.FindAll(x => x.ProductID == null && x.CustomerId.Equals(new Guid(form["customer"]))).FirstOrDefault();
                    msg = "Discount against this customer";
                }
                if (discount != null)
                {
                    if (Boolean.Parse(form["force"]))
                    {
                        discount.DiscountValue = Convert.ToDouble(form["discount"]);
                        discount.DeletedAt = null;
                        discount.IsPercentage = form.Keys.Contains("percentage") ? true : false;
                        _discountRepo.Update(discount);
                        await AddLogAsync(LogActions.DiscountUpdated.GetDescription(), $"{discount.Id}", LogsActionSrc.DiscountManagement.ToString());
                        return Ok(new
                        {
                            Message = string.Format(SuccessMessageConstants.UpdateSuccess, "Discount"),
                        });
                    }
                    else
                    {
                        return Conflict(new
                        {
                            Message = string.Format(ErrorMessageConstants.AlreadyExists, msg, discountValue)
                        });
                    }
                }
                else
                {
                    discountObj.CreatedAt = DateTime.Now;
                    discountObj.CustomerId = new Guid(form["customer"]);
                    if (form.Keys.Contains("hasProduct"))
                        discountObj.ProductID = new Guid(form["variant"]);
                    discountObj.IsPercentage = form.Keys.Contains("percentage") ? true : false;
                    discountObj.DiscountValue = Convert.ToDouble(form["discount"]);
                    _discountRepo.Insert(discountObj);
                    await AddLogAsync(LogActions.DiscountApplied.GetDescription(), $"Customer: {discountObj.CustomerId}", LogsActionSrc.DiscountManagement.ToString());
                    return Ok(new
                    {
                        Message = string.Format(SuccessMessageConstants.AddedSuccess, "Discount")
                    });
                }
            }
            else if (form["rule"].Equals("ProductRule"))
            {
                discount = _discountRepo.FindAll(x => x.ProductID.Equals(new Guid(form["variant"])) && x.CustomerId == null).FirstOrDefault();
                msg = "Discount on this product";
                if (discount != null)
                {
                    if (Boolean.Parse(form["force"]))
                    {
                        discount.DiscountValue = Convert.ToDouble(form["discount"]);
                        discount.DeletedAt = null;
                        discount.IsPercentage = form.Keys.Contains("percentage") ? true : false;
                        _discountRepo.Update(discount);
                        await AddLogAsync(LogActions.DiscountUpdated.GetDescription(), $"{discount.Id}", LogsActionSrc.DiscountManagement.ToString());
                        return Ok(new
                        {
                            Message = string.Format(SuccessMessageConstants.UpdateSuccess, "Discount"),
                        });
                    }
                    else
                    {
                        return Conflict(new
                        {
                            Message = string.Format(ErrorMessageConstants.AlreadyExists, msg, discountValue),
                        });
                    }
                }
                else
                {
                    discountObj.CreatedAt = DateTime.Now;
                    discountObj.ProductID = new Guid(form["variant"]);
                    discountObj.IsPercentage = form.Keys.Contains("percentage") ? true : false;
                    discountObj.DiscountValue = Convert.ToDouble(form["discount"]);
                    _discountRepo.Insert(discountObj);
                    await AddLogAsync(LogActions.DiscountApplied.GetDescription(), $"Product: {discountObj.ProductID}", LogsActionSrc.DiscountManagement.ToString());
                    return Ok(new
                    {
                        Message = string.Format(SuccessMessageConstants.AddedSuccess, "Discount")
                    });
                }
            }
            else
            {
                discount = _discountRepo.FindAll(x => x.RouteId.Equals(new Guid(form["route"]))).FirstOrDefault();
                msg = "Discount on this route";
                if (discount != null)
                {
                    if (Boolean.Parse(form["force"]))
                    {
                        discount.DiscountValue = Convert.ToDouble(form["discount"]);
                        discount.DeletedAt = null;
                        discount.IsPercentage = form.Keys.Contains("percentage") ? true : false;
                        _discountRepo.Update(discount);
                        return Ok(new
                        {
                            Message = string.Format(SuccessMessageConstants.UpdateSuccess, "Discount"),
                        });
                    }
                    else
                    {
                        return Conflict(new
                        {
                            Message = string.Format(ErrorMessageConstants.AlreadyExists, msg, discountValue),
                        });
                    }
                }
                else
                {
                    discountObj.CreatedAt = DateTime.Now;
                    discountObj.RouteId = new Guid(form["route"]);
                    discountObj.IsPercentage = form.Keys.Contains("percentage") ? true : false;
                    discountObj.DiscountValue = Convert.ToDouble(form["discount"]);
                    _discountRepo.Insert(discountObj);
                    return Ok(new
                    {
                        Message = string.Format(SuccessMessageConstants.AddedSuccess, "Discount")
                    });
                }
            }
        }
        [HttpGet]
        public IActionResult EditDiscount(string id)
        {
            var discount = _discountRepo.FindAll(x => x.Id.Equals(new Guid(id)))
                .Include(x => x.Customer).ThenInclude(x => x.Route)
                .Include(x => x.Product).ThenInclude(x => x.VariantOf)
                .Include(x => x.Product).ThenInclude(x => x.Prices)
                .Include(x => x.Route).ThenInclude(x => x.SalesPersons).ThenInclude(x => x.SalesPerson)
                .FirstOrDefault();
            ViewBag.SalesPerson = discount.Route == null ? "---" : RouteSp(discount.Route.SalesPersons.ToList());
            var price = discount.Product?.Prices.Count > 0 ? discount.Product.Prices.OrderByDescending(x => x.CreatedAt).First().Price : -1;
            ViewBag.Price = Convert.ToInt32(price);
            ViewBag.View = "Edit";
            return View(discount);
        }
        public IActionResult DiscountDetail(string id)
        {
            var discount = _discountRepo.FindAll(x => x.Id.Equals(new Guid(id)))
                .Include(x => x.Customer).ThenInclude(x => x.Route)
                .Include(x => x.Product).ThenInclude(x => x.VariantOf)
                .Include(x => x.Route).ThenInclude(x => x.SalesPersons).ThenInclude(x => x.SalesPerson)
                .FirstOrDefault();
            ViewBag.SalesPerson = discount.Route == null ? "---" : RouteSp(discount.Route.SalesPersons.ToList());
            ViewBag.View = "Detail";
            return View("EditDiscount", discount);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountAsync(string id)
        {
            try
            {
                var discount = _discountRepo.FindAll(x => x.Id.Equals(new Guid(id))).FirstOrDefault();
                _discountRepo.Delete(discount);
                await AddLogAsync(LogActions.DiscountDeleted.GetDescription(), $"{discount.Id}", LogsActionSrc.DiscountManagement.ToString());
                return Ok(new
                {
                    Message = string.Format(SuccessMessageConstants.DeleteSuccess, "Discount")
                });
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
        public async Task<IActionResult> EditDiscountAsync(IFormCollection form)
        {
            try
            {
                var discount = _discountRepo.FindAll(x => x.Id.Equals(new Guid(form["Id"])) && x.DeletedAt == null).FirstOrDefault();
                if (discount != null)
                {
                    discount.DiscountValue = Convert.ToDouble(form["DiscountValue"]);
                    if (form.Keys.Contains("percentage"))
                        discount.IsPercentage = true;
                    else
                        discount.IsPercentage = false;
                    _discountRepo.Update(discount);
                    await AddLogAsync(LogActions.DiscountUpdated.GetDescription(), $"{discount.Id}", LogsActionSrc.DiscountManagement.ToString());
                    return Ok(new
                    {
                        Message = string.Format(SuccessMessageConstants.UpdateSuccess, "Discount")
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        Message = string.Format(ErrorMessageConstants.NotFound, "Discount")
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
        public async Task<IActionResult> ChangeStatusAsync(string id)
        {
            try
            {
                var discount = _discountRepo.Get(new Guid(id));
                discount.IsActive = !discount.IsActive;
                _discountRepo.Update(discount);
                await AddLogAsync(LogActions.DiscountStatus.GetDescription(), $"{discount.Id}", LogsActionSrc.DiscountManagement.ToString());
                return Ok(new
                {
                    Message = discount.IsActive ? string.Format(SuccessMessageConstants.ActiveSuccess, "Discount") : string.Format(SuccessMessageConstants.InactiveSuccess, "Discount")
                });
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
        public IActionResult OrderDetailsAsync(string id)
        {
            var userId = User.Claims.First().Value;
            var user = _userManager.Users.Include(x => x.Role).Where(x => x.Id == userId).FirstOrDefault();
            var order = _orderRepo.FindAll(x => x.Id.Equals(new Guid(id))).
                Include(x => x.Vehicle).
                Include(x => x.SalesPerson).
                Include(x => x.Customer).ThenInclude(x => x.ProfilePicture).
                Include(x => x.Customer).ThenInclude(x => x.Route).
                Include(x => x.Orders).ThenInclude(x => x.Product).ThenInclude(x => x.VariantOf).
                Include(x => x.Orders).ThenInclude(x => x.Promotion).
                Include(x => x.WasteOrders).ThenInclude(x => x.Product).ThenInclude(x => x.VariantOf).
                Include(x => x.ReturnOrders).ThenInclude(x => x.Product).ThenInclude(x => x.VariantOf).
                Include(x => x.Payment).
                First();
            var orderDetails = GetOrderDetails(order);
            orderDetails.InvoiceDiscount = double.Parse(orderDetails.InvoiceDiscount.ToString(), System.Globalization.CultureInfo.InvariantCulture);
            if (orderDetails.DeletedAt == null && !orderDetails.IsMarked) {
                double totalWithoutDiscount = 0;
                if (orderDetails.Total > 0)
                {
                    totalWithoutDiscount = Math.Round(orderDetails.Total - orderDetails.ProductsDiscount, 2);
                    orderDetails.Total = Math.Round(totalWithoutDiscount - orderDetails.TotalDiscount, 2);
                }
                else if (orderDetails.Total < 0)
                {
                    totalWithoutDiscount = Math.Round(orderDetails.Total - orderDetails.ProductsDiscount, 2);
                    orderDetails.Total = Math.Round(totalWithoutDiscount + orderDetails.TotalDiscount, 2);

                }
                ViewBag.TotalWithoutDiscount = totalWithoutDiscount;
                if (user.Role.Name.Equals("Admin"))
                    ViewBag.MaxDiscount = 99;
                else
                {
                    var config = _configRepo.FindAll(x => x.ConfigKey == "SalesManager_DiscountThrashHold" || x.ConfigKey == "MarketingManager_DiscountThrashHold");
                    if (orderDetails.ApprovalFor.Equals(ApprovalFor.SalesManager))
                        ViewBag.MaxDiscount = Convert.ToInt32(config.Where(x => x.ConfigKey == "MarketingManager_DiscountThrashHold").Select(x => x.Value).FirstOrDefault()) - 0.01;
                    else
                        ViewBag.MaxDiscount = 99;
                }
                return View(orderDetails);
            }
            else
            {
                TempData["Message"] = "Order";
                return RedirectToAction("RecordDeleted", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> ChangeOrderStatusAsync(string id)
        {
            try
            {
                var claims = User.Claims.ToArray();
                var currUser = _userManager.Users.Include(x => x.Role).First(x => x.Id.Equals(claims[0].Value));
                var order = _orderRepo.FindAll(x => x.Id.Equals(new Guid(id))).Include(x => x.SalesPerson).FirstOrDefault();
                if (order != null)
                {
                    order.Status = ApprovalStatus.Approved;
                    order.ApprovedById = currUser.Id;
                    _orderRepo.Update(order);
                    await AddLogAsync(LogActions.DiscountApprovedBy.GetDescription(), $"{currUser.UserName}", LogsActionSrc.DiscountManagement.ToString());
                    _notificationService.PushNotification(
                        string.Format(NotificationConstants.ApproveOrder, order.OrderCode, currUser.Email, currUser.Role.Name),
                        currUser.Id,
                        Url.Action("OrderDetails", "Discount", new { id = order.Id }),
                        null,
                        null,
                        $"{order.SalesPerson.Email}");
                    return Ok(new
                    {
                        Message = string.Format(SuccessMessageConstants.ActiveSuccess, "The discounted order has been")
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        Message = string.Format(ErrorMessageConstants.NotFound, "Order")
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
        public async Task<IActionResult> ReAdjustDiscountAsync(IFormCollection form)
        {
            var claims = User.Claims.ToArray();
            var currUser = _userManager.Users.Include(x => x.Role).First(x => x.Id.Equals(claims[0].Value));
            try
            {
                var order = _orderRepo.FindAll(x => x.Id.Equals(new Guid(form["Id"]))).
                Include(x => x.Vehicle).
                Include(x => x.SalesPerson).
                Include(x => x.Customer).ThenInclude(x => x.ProfilePicture).
                Include(x => x.Customer).ThenInclude(x => x.Route).
                Include(x => x.Orders).ThenInclude(x => x.Product).ThenInclude(x => x.VariantOf).
                Include(x => x.Orders).ThenInclude(x => x.Promotion).
                Include(x => x.WasteOrders).ThenInclude(x => x.Product).ThenInclude(x => x.VariantOf).
                Include(x => x.ReturnOrders).ThenInclude(x => x.Product).ThenInclude(x => x.VariantOf).
                Include(x => x.SalesPerson).
                Include(x => x.Payment).
                First();
                var discount = Convert.ToDouble(form["discountAmt"]);
                if (order != null)
                {
                    var orderDetails = GetOrderDetails(order);
                    var total = orderDetails.Total < 0 ? orderDetails.Total + discount + orderDetails.ProductsDiscount : orderDetails.Total - discount - orderDetails.ProductsDiscount;
                    order.Discount = (float)discount;
                    order.Total = total;
                    order.Status = ApprovalStatus.ReAdjusted;
                    order.ApprovedById = currUser.Id;
                    _orderRepo.Update(order);
                    _sp.UpdateCustomerBalance(order.CustomerId);
                    await AddLogAsync(LogActions.DiscountReAdjustBy.GetDescription(), $"{currUser.UserName}", LogsActionSrc.DiscountManagement.ToString());
                    _notificationService.PushNotification(
                        string.Format(NotificationConstants.ReAdjustOrder, order.OrderCode, currUser.Email, currUser.Role.Name),
                        currUser.Id,
                        Url.Action("OrderDetails", "Discount", new { id = order.Id }),
                        null,
                        null,
                        $"{order.SalesPerson.Email}");
                    return Ok(new
                    {
                        Message = string.Format(SuccessMessageConstants.ReAdjustSuccess, "The discounted order has been")
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        Message = string.Format(ErrorMessageConstants.NotFound, "Order")
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = ErrorMessageConstants.Error,
                    Exception = ex
                });
            }
        }
        [HttpGet]
        public IActionResult GetPrice(string id)
        {
            try
            {
                var product = _productRepo
                .FindAll(x => x.Id.Equals(new Guid(id)) && x.DeletedAt == null).Include(x => x.Prices).FirstOrDefault();
                var price = product.Prices.Count > 0 ? product.Prices.OrderByDescending(x => x.CreatedAt).First().Price : -1;
                return Ok(new
                {
                    Price = Convert.ToInt32(price)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = ErrorMessageConstants.Error
                });
            }
        }
        public IActionResult CustomerInfo(string id)
        {
            try
            {
                var customer = _custRepo.FindAll(x => x.Id.Equals(new Guid(id))).Include(x => x.ProfilePicture)
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
    }
}
