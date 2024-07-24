using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadyGo.Domain.Entities;
using ReadyGo.Domain.Entities.ViewModels;
using ReadyGo.Service.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using ReadyGo.Domain.Constants;
using ReadyGo.Service.Stored_Procedures.Interface;
using ReadyGo.Service.Interfaces;
using System.Threading.Tasks;
using ReadyGo.Domain.Enum;
using ReadyGo.Persistence.Seeds;
using System.Collections.Generic;

namespace ReadyGo.Web.Controllers
{
    [Authorize]
    public class OrderController : BaseController
    {
        private readonly IGenericRepository<Order> _orderRepo;
        private readonly IProcedures _sp;
        private readonly INotificationService _notificationService;
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<OrderDetail> _orderDetailRepo;
        private readonly IGenericRepository<ReturnOrder> _retOrderRepo;
        private readonly IGenericRepository<WasteOrders> _wasteOrderRepo;
        private readonly IGenericRepository<Configuration> _configRepo;
        private readonly IGenericRepository<Promotion> _promotionRepo;
        private readonly IGenericRepository<Payment> _paymentRepo;
        private readonly IInvoiceService _invoiceService;

        public OrderController(IGenericRepository<Order> orderRepo, IGenericRepository<Product> productsRepo,
            IProcedures sp, INotificationService notificationService,
            IGenericRepository<OrderDetail> orderDetailRepo, IGenericRepository<Promotion> promotionRepo,
        IGenericRepository<WasteOrders> wasteRepo, IGenericRepository<Configuration> configRepo,
            IGenericRepository<ReturnOrder> returnRepo, IInvoiceService invoiceService,
            IGenericRepository<Payment> paymentRepo)
        {
            _paymentRepo = paymentRepo;
            _invoiceService = invoiceService;
            _promotionRepo = promotionRepo;
            _configRepo = configRepo;
            _wasteOrderRepo = wasteRepo;
            _retOrderRepo = returnRepo;
            _orderDetailRepo = orderDetailRepo;
            _productsRepo = productsRepo;
            _sp = sp;
            _notificationService = notificationService;
            _orderRepo = orderRepo;
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
        public IActionResult SPOrders()
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
                var isMarked = Convert.ToBoolean(Request.Form["isMarked"].FirstOrDefault());
                var date = Request.Form["columns[5][search][value]"].FirstOrDefault();
                int pageSize = Convert.ToInt32(length ?? "0");
                int skip = Convert.ToInt32(start ?? "0");
                int recordsTotal = 0;

                var orders = !string.IsNullOrEmpty(id) ?
                    _orderRepo.FindAll(x => x.SalesPersonId.Equals(id) && x.IsMarked == isMarked && x.DeletedAt == null)
                    .Include(x => x.Customer)
                    .Include(x => x.Orders)
                    .Include(x => x.ReturnOrders)
                    .Include(x => x.WasteOrders)
                    .Include(x => x.SalesPerson)
                    .Include(x => x.Payment)
                    .ToList() :
                    _orderRepo.FindAll(x => x.IsMarked == isMarked && x.DeletedAt == null)
                    .Include(x => x.Customer)
                    .Include(x => x.Orders)
                    .Include(x => x.ReturnOrders)
                    .Include(x => x.SalesPerson).ThenInclude(x => x.Routes).ThenInclude(x => x.Route)
                    .Include(x => x.WasteOrders)
                    .Include(x => x.Payment)
                    .ToList();
                orders = string.IsNullOrEmpty(spId) ? orders : orders.Where(x => x.SalesPersonId == spId).ToList();
                var orderData = FindTotal(orders);
                if (orderData.Count > 0)
                {
                    if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                    {
                        int column = int.Parse(sortColumn);
                        if (isMarked)
                        {
                            switch (column)
                            {
                                case 1:
                                    orderData = (sortColumnDirection == "asc" ? orderData.OrderBy(c => c.OrderCode) :
                                        orderData.OrderByDescending(c => c.OrderCode)).ToList();
                                    break;
                                case 2:
                                    orderData = (sortColumnDirection == "asc" ? orderData.OrderBy(c => c.SalesPersonName) :
                                        orderData.OrderByDescending(c => c.SalesPersonName)).ToList();
                                    break;
                                case 3:
                                    orderData = ((sortColumnDirection == "asc" ? orderData.OrderBy(c => c.CustomerName) :
                                        orderData.OrderByDescending(c => c.CustomerName))).ToList();
                                    break;

                                case 4:
                                    orderData = ((sortColumnDirection == "asc" ? orderData.OrderBy(c => c.Gross) :
                                        orderData.OrderByDescending(c => c.Gross))).ToList();
                                    break;
                                case 5:
                                    orderData = ((sortColumnDirection == "asc" ? orderData.OrderBy(c => c.InvoiceDiscount) :
                                        orderData.OrderByDescending(c => c.InvoiceDiscount))).ToList();
                                    break;
                                case 6:
                                    orderData = ((sortColumnDirection == "asc" ? orderData.OrderBy(c => c.InvoiceDiscountPercentage) :
                                        orderData.OrderByDescending(c => c.InvoiceDiscountPercentage))).ToList();
                                    break;
                                case 7:
                                    orderData = ((sortColumnDirection == "asc" ? orderData.OrderBy(c => c.TotalDiscount) :
                                        orderData.OrderByDescending(c => c.TotalDiscount))).ToList();
                                    break;
                                case 8:
                                    orderData = ((sortColumnDirection == "asc" ? orderData.OrderBy(c => c.TotalDiscountPercentage) :
                                        orderData.OrderByDescending(c => c.TotalDiscountPercentage))).ToList();
                                    break;
                              
                                case 9:
                                    orderData = ((sortColumnDirection == "asc" ? orderData.OrderBy(c => c.Waste) :
                                        orderData.OrderByDescending(c => c.Waste))).ToList();
                                    break;
                                case 10:
                                    orderData = ((sortColumnDirection == "asc" ? orderData.OrderBy(c => c.Total) :
                                        orderData.OrderByDescending(c => c.Total))).ToList();
                                    break;
                                case 11:
                                    orderData = ((sortColumnDirection == "asc" ? orderData.OrderBy(c => c.CreatedAt) :
                                        orderData.OrderByDescending(c => c.CreatedAt))).ToList();
                                    break;
                            }

                        }
                        else
                        {
                            switch (column)
                            {
                                case 0:
                                    orderData = (sortColumnDirection == "asc" ? orderData.OrderBy(c => c.OrderCode) : orderData.OrderByDescending(c => c.OrderCode)).ToList();
                                    break;

                                case 1:
                                    orderData = (sortColumnDirection == "asc" ? orderData.OrderBy(c => c.SalesPersonName)
                                        : orderData.OrderByDescending(c => c.SalesPersonName)).ToList();
                                    break;

                                case 2:
                                    orderData = ((sortColumnDirection == "asc" ? orderData.OrderBy(c => c.CustomerName)
                                        : orderData.OrderByDescending(c => c.CustomerName))).ToList();
                                    break;

                                case 3:
                                    orderData = ((sortColumnDirection == "asc" ? orderData.OrderBy(c => c.Gross)
                                        : orderData.OrderByDescending(c => c.Gross))).ToList();
                                    break;
                                case 4:
                                    orderData = ((sortColumnDirection == "asc" ? orderData.OrderBy(c => c.InvoiceDiscount)
                                        : orderData.OrderByDescending(c => c.InvoiceDiscount))).ToList();
                                    break;
                                case 5:
                                    orderData = ((sortColumnDirection == "asc" ? orderData.OrderBy(c => c.InvoiceDiscountPercentage)
                                        : orderData.OrderByDescending(c => c.InvoiceDiscountPercentage))).ToList();
                                    break;
                                case 6:
                                    orderData = ((sortColumnDirection == "asc" ? orderData.OrderBy(c => c.TotalDiscount)
                                        : orderData.OrderByDescending(c => c.TotalDiscount))).ToList();
                                    break;
                                case 7:
                                    orderData = ((sortColumnDirection == "asc" ? orderData.OrderBy(c => c.TotalDiscountPercentage)
                                        : orderData.OrderByDescending(c => c.TotalDiscountPercentage))).ToList();
                                    break;
                                case 8:
                                    orderData = ((sortColumnDirection == "asc" ? orderData.OrderBy(c => c.Waste)
                                        : orderData.OrderByDescending(c => c.Waste))).ToList();
                                    break;
                                case 9:
                                    orderData = ((sortColumnDirection == "asc" ? orderData.OrderBy(c => c.Total)
                                        : orderData.OrderByDescending(c => c.Total))).ToList();
                                    break;
                                case 10:
                                    orderData = ((sortColumnDirection == "asc" ? orderData.OrderBy(c => c.Credit)
                                        : orderData.OrderByDescending(c => c.Credit))).ToList();
                                    break;
                                case 11:
                                    orderData = ((sortColumnDirection == "asc" ? orderData.OrderBy(c => c.CreatedAt)
                                        : orderData.OrderByDescending(c => c.CreatedAt))).ToList();
                                    break;
                            }
                        }
                    }

                    var createdDate = new DateTime();
                    if (date != "")
                    {
                        createdDate = Convert.ToDateTime(date);
                        orderData = orderData.Where(x => x.CreatedAt.Date == createdDate.Date).ToList();
                    }
                    if (!string.IsNullOrEmpty(searchValue))
                    {
                        orderData = orderData.Where(m => !string.IsNullOrEmpty(m.OrderCode) && m.OrderCode.Contains(searchValue, StringComparison.OrdinalIgnoreCase)
                                        || (m.CustomerName.Contains(searchValue, StringComparison.OrdinalIgnoreCase))
                                        || (m.SalesPersonName.Contains(searchValue, StringComparison.OrdinalIgnoreCase))).ToList();
                    }


                    recordsTotal = orderData.Count();
                    var data = orderData.Skip(skip).Take(pageSize).ToList();
                    return Json(new { draw, recordsFiltered = recordsTotal, recordsTotal, data });
                }
                return Json(new { draw = 0, recordsFiltered = 0, recordsTotal = 0, data = orderData });

            }

            catch (Exception ex)
            {
                LogException(ex);
                return null;
            }
        }

        public IActionResult MarkedOrders()
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
        public IActionResult UnMarkOrder(string id)
        {
            var claims = User.Claims.ToArray();
            var curruser = _userManager.Users.Include(x => x.Role).First(x => x.Id.Equals(claims[0].Value));
            try
            {
                var order = _orderRepo.FindAll(x => x.Id.Equals(new Guid(id))).Include(x => x.SalesPerson)
                    .Include(x=>x.Payment).FirstOrDefault();
                if (order == null)
                {
                    return BadRequest(new
                    {
                        Message = string.Format(ErrorMessageConstants.NotFound, "Order")
                    });
                }
                else
                {
                    order.IsMarked = false;
                    _orderRepo.Update(order);
                    if(order.Payment != null)
                    {
                        order.Payment.IsMarked = false;
                        _paymentRepo.Update(order.Payment);
                    }
                    _sp.UpdateCustomerBalance(order.CustomerId);
                    _notificationService.PushNotification(
                        string.Format(NotificationConstants.UnMarkedOrder, order.OrderCode, curruser.Email, curruser.Role.Name),
                        curruser.Id,
                        Url.Action("OrderDetails", "SalesPerson", new { id = order.Id }),
                        null,
                        null,
                        $"{order.SalesPerson.Email}"
                        );
                    return Ok(new
                    {
                        Message = string.Format(SuccessMessageConstants.UnMarkSuccess, "Order")
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
        public IActionResult EditOrder(string id)
        {
            ViewBag.Products = _productsRepo.FindAll(x => x.DeletedAt == null && x.ProductId == null).Include(x => x.Category).Select(x => new
            {
                x.Id,
                Name = x.Category.Name + " - " + x.Name
            }).ToList();
            var order = _orderRepo.FindAll(x => x.Id.Equals(new Guid(id))).
                Include(x => x.Customer).ThenInclude(x => x.Discounts).
                Include(x => x.SalesPerson).
                Include(x => x.Orders).ThenInclude(x => x.Product).
                Include(x => x.Orders).ThenInclude(x => x.Product).ThenInclude(x => x.VariantOf).
                Include(x => x.Orders).ThenInclude(x => x.Product).ThenInclude(x => x.Category).
                Include(x => x.Orders).ThenInclude(x => x.Promotion).
                Include(x => x.WasteOrders).ThenInclude(x => x.Product).
                Include(x => x.WasteOrders).ThenInclude(x => x.Product).ThenInclude(x => x.VariantOf).
                Include(x => x.WasteOrders).ThenInclude(x => x.Product).ThenInclude(x => x.Category).
                Include(x => x.ReturnOrders).ThenInclude(x => x.Product).
                Include(x => x.ReturnOrders).ThenInclude(x => x.Product).ThenInclude(x => x.VariantOf).
                Include(x => x.ReturnOrders).ThenInclude(x => x.Product).ThenInclude(x => x.Category).
                Include(x => x.Payment).First();
            var details = GetOrderDetails(order);
            ViewBag.TotalWithoutDiscount = details.Total - details.ProductsDiscount;
            ViewBag.Total = details.Total - details.ProductsDiscount < 0 ? details.Total - details.ProductsDiscount + details.InvoiceDiscount
                : details.Total - details.ProductsDiscount - details.InvoiceDiscount;
            ViewBag.Gross = details.Gross;
            ViewBag.Return = details.Return + details.Waste;
            order.Discount = (float)details.InvoiceDiscount;
            ViewBag.Percentage = false;
            ViewBag.CustomerDiscount = false;
            ViewBag.Payment = details.Payment;
            ViewBag.Credit = details.Credit;
            ViewBag.ProductDiscount = details.ProductsDiscount;
            if (order.Discount == 0)
            {
                var discount = order.Customer.Discounts.Where(x => x.DeletedAt == null && x.ProductID == null).FirstOrDefault();
                if (discount != null)
                {
                    if (discount.IsPercentage)
                    {
                        ViewBag.Percentage = true;
                    }
                    ViewBag.CustomerDiscount = true;
                    order.Discount = (float)discount.DiscountValue;
                }
            }

            return View(order);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteOrderAsync(string id)
        {
            try
            {
                var order = _orderRepo.FindAll(x=>x.Id.Equals(new Guid(id))).Include(x=>x.Payment).FirstOrDefault();
                order.DeletedAt = DateTime.Now;
                if(order.Payment != null)
                {
                    order.Payment.DeletedAt = DateTime.Now;
                    _paymentRepo.Update(order.Payment);
                }
                _orderRepo.Update(order);
                _sp.UpdateCustomerBalance(order.CustomerId);
                await AddLogAsync(LogActions.DeleteOrder.GetDescription(), order.OrderCode, LogsActionSrc.SPManagement.ToString());
                return Ok(new
                {
                    Message = string.Format(SuccessMessageConstants.DeleteSuccess, "Order")
                });
            }
            catch (Exception ex)
            {
                LogException(ex);
                return BadRequest(new
                {
                    Message = string.Format(ErrorMessageConstants.DeleteFail, "Order")
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> EditOrderAsync(EditOrderViewModel model)
        {
            try
            {
                double percentage = 0.0;
                var orderTotal = double.Parse(model.Total, System.Globalization.CultureInfo.InvariantCulture);
                var order = _orderRepo.FindAll(x => x.Id.Equals(new Guid(model.OrderId))).Include(x => x.Customer).First();
                var thrashHold = _configRepo.FindAll(x => x.ConfigKey == "SalesManager_DiscountThrashHold" || x.ConfigKey == "MarketingManager_DiscountThrashHold").ToList();
                var MmDiscount = thrashHold.Where(x => x.ConfigKey == "MarketingManager_DiscountThrashHold").Select(x => x.Value).FirstOrDefault();
                var SmDiscount = thrashHold.Where(x => x.ConfigKey == "SalesManager_DiscountThrashHold").Select(x => x.Value).FirstOrDefault();
                order.Discount = (float)Convert.ToDouble(model.Discount);
                if (order.Discount > 0)
                {
                    if (orderTotal > 0)
                    {
                        percentage = (Convert.ToDouble(model.Discount) / (Convert.ToDouble(model.Discount) + orderTotal)) * 100;
                    }
                    else if (order.Total < 0)
                    {
                        percentage = (Convert.ToDouble(model.Discount) / Math.Abs(orderTotal - (Convert.ToDouble(model.Discount)))) * 100;
                    }
                }
                if (percentage < Convert.ToDouble(SmDiscount))
                {
                    order.Status = ApprovalStatus.Approved;
                    order.ApprovalFor = ApprovalFor.NotRequired;
                    await AddLogAsync(LogActions.DiscountApprovedAuto.GetDescription(), $"order no: {order.OrderCode}", LogsActionSrc.DiscountManagement.ToString());
                }
                else if (percentage >= Convert.ToDouble(SmDiscount) && percentage < Convert.ToDouble(MmDiscount))
                {
                    order.Status = ApprovalStatus.Pending;
                    order.ApprovalFor = ApprovalFor.SalesManager;
                    _notificationService.PushNotification(
                        string.Format(NotificationConstants.DiscountApproval, order.OrderCode),
                        User.Claims.First().Value,
                        Url.Action("OrderDetails", "Discount", new { id = order.Id }),
                        NotficationEnums.DiscountedOrder.ToString(),
                        $"{Roles.SalesManager.GetDescription()}",
                        null);
                }
                else
                {
                    order.Status = ApprovalStatus.Pending;
                    order.ApprovalFor = ApprovalFor.MarketingManager;
                    _notificationService.PushNotification(
                        string.Format(NotificationConstants.DiscountApproval,
                        order.OrderCode),
                        User.Claims.First().Value,
                        Url.Action("OrderDetails", "Discount", new { id = order.Id }),
                        NotficationEnums.DiscountedOrder.ToString(),
                        $"{Roles.MarketingManager.GetDescription()}",
                        null);
                }
                order.Total = Convert.ToInt32(orderTotal);
                if (order.Reason != null)
                {
                    if ((model.Orders != null && model.Orders.Count > 0) ||
                        (model.ReturnOrders != null && model.ReturnOrders.Count > 0) ||
                        (model.WasteOrders != null && model.WasteOrders.Count > 0))
                    {
                        order.Reason = null;
                    }
                }
                _orderRepo.Update(order);
                _sp.UpdateCustomerBalance(order.CustomerId);

                var returnOrders = _retOrderRepo.FindAll(x => x.OrderId.Equals(new Guid(model.OrderId))).ToList();

                var orderDetails = _orderDetailRepo.FindAll(x => x.OrderId.Equals(new Guid(model.OrderId))).ToList();

                var oldWasteOrders = _wasteOrderRepo.FindAll(x => x.OrderId.Equals(new Guid(model.OrderId))).ToList();

                _retOrderRepo.DeleteRange(returnOrders);

                _orderDetailRepo.DeleteRange(orderDetails);

                _wasteOrderRepo.DeleteRange(oldWasteOrders);

                List<OrderDetail> orders = new List<OrderDetail>();
                if (model.Orders != null && model.Orders.Count > 0)
                {
                    foreach (var item in model.Orders)
                    {
                        OrderDetail orderDetail = new OrderDetail
                        {
                            OrderId = order.Id,
                            Quantity = (float)Convert.ToDouble(item.Quantity),
                            ProductId = new Guid(item.ProductId),
                            Price = (float)Convert.ToDouble(item.Price),
                            Discount = (float)Convert.ToDouble(item.Discount)
                        };
                        if (item.PromoId != null)
                        {
                            orderDetail.PromotionId = new Guid(item.PromoId);
                        }
                        orders.Add(orderDetail);
                    }
                    _orderDetailRepo.InsertRange(orders);
                }
                List<ReturnOrder> retOrders = new List<ReturnOrder>();
                if (model.ReturnOrders != null && model.ReturnOrders.Count > 0)
                {
                    foreach (var item in model.ReturnOrders)
                    {
                        ReturnOrder returnOrder = new ReturnOrder
                        {
                            OrderId = order.Id,
                            Quantity = (float)Convert.ToDouble(item.Quantity),
                            ProductId = new Guid(item.ProductId),
                            ReturnReason = item.ReturnReason,
                            Price = (float)Convert.ToDouble(item.Price),
                            Discount = (float)Convert.ToDouble(item.Discount),
                        };
                        retOrders.Add(returnOrder);
                    }
                    _retOrderRepo.InsertRange(retOrders);
                }
                List<WasteOrders> wasteOrders = new List<WasteOrders>();
                if (model.WasteOrders != null && model.WasteOrders.Count > 0)
                {
                    foreach (var item in model.WasteOrders)
                    {
                        WasteOrders wasteOrder = new WasteOrders
                        {
                            OrderId = order.Id,
                            Quantity = (float)Convert.ToDouble(item.Quantity),
                            ProductId = new Guid(item.ProductId),
                            WasteReason = item.ReturnReason,
                            Discount = (float)Convert.ToDouble(item.Discount),
                            Price = (float)Convert.ToDouble(item.Price)
                        };
                        wasteOrders.Add(wasteOrder);
                    }
                    _wasteOrderRepo.InsertRange(wasteOrders);
                }
                //var balance = Convert.ToDouble(model.CustomerBalance);
                //if (balance > 0)
                //{
                //    var customer = order.Customer;
                //    customer.Balance += balance;
                //    _customerRepo.Update(customer);
                //}
                await AddLogAsync(LogActions.UpdateOrder.GetDescription(), order.OrderCode, LogsActionSrc.SPManagement.ToString());

                return Ok(new
                {
                    Message = string.Format(SuccessMessageConstants.UpdateSuccess, "Order"),
                });
            }
            catch (Exception ex)
            {
                LogException(ex);
                return BadRequest(new
                {
                    Message = ErrorMessageConstants.Error,
                    Exception = ex
                });
            }

        }
        public IActionResult OrderDetails(string id)
        {
            var order = _orderRepo.FindAll(x => x.Id.Equals(new Guid(id))).
                Include(x => x.Vehicle).
                Include(x => x.SalesPerson).
                Include(x => x.Customer).ThenInclude(x => x.ProfilePicture).
                Include(x => x.Customer).ThenInclude(x => x.Route).
                Include(x => x.Orders).ThenInclude(x => x.Product).ThenInclude(x => x.VariantOf).
                Include(x => x.Orders).ThenInclude(x => x.Promotion).
                Include(x => x.WasteOrders).ThenInclude(x => x.Product).ThenInclude(x => x.VariantOf).
                Include(x => x.ReturnOrders).ThenInclude(x => x.Product).ThenInclude(x => x.VariantOf).
                Include(x => x.Payment).First();
            var orderDetails = GetOrderDetails(order);
            orderDetails.Total -= orderDetails.ProductsDiscount;
            if (orderDetails.Total > 0)
            {
                orderDetails.Total = (float)Math.Round(orderDetails.Total - orderDetails.InvoiceDiscount, 2);
            }
            else if (orderDetails.Total < 0)
            {
                orderDetails.Total = (float)Math.Round(orderDetails.Total + orderDetails.InvoiceDiscount, 2);
            }
            if (order.DeletedAt == null)
                return View(orderDetails);
            else
            {
                TempData["Message"] = "Order";
                return RedirectToAction("RecordDeleted", "Home");
            }
        }
        [HttpPost]
        public IActionResult CheckPromos(string[] promos, CheckPromoProductViewModel[] products)
        {
            var promotions = _promotionRepo.FindAll(x => promos.Contains(x.Id.ToString())).ToList();

            var baseProducts = promotions.GroupBy(x => x.BaseProductId);
            if (baseProducts.Any(x => x.Count() > 1))
            {
                return BadRequest(new
                {
                    Message = ErrorMessageConstants.MultiplePromotions
                });
            }
            var allProducts = _productsRepo.GetAll().Include(x => x.Category).Include(x => x.VariantOf).ToList();
            var selectedProducts = allProducts.Where(x => products.Select(z => z.Id).Contains(x.Id)).Select(
                x => new
                {
                    x.Id,
                    x.AxCode,
                    Quantity = products.Where(z => z.Id.Equals(x.Id)).Select(y => y.Quantity).FirstOrDefault()
                });
            foreach (var promo in promotions)
            {

                var check1 = selectedProducts.Where(x => x.Id.Equals(promo.BaseProductId)).ToList();
                var check2 = check1.FirstOrDefault();
                if (check1.Count > 1)
                {
                    return BadRequest(new
                    {
                        Message = ErrorMessageConstants.MultiplePromotions
                    });
                }
                else if (check2 == null || check2.Quantity < promo.BaseProductQuantity)
                {
                    return BadRequest(new
                    {
                        Message = ErrorMessageConstants.InvalidPromotion
                    });
                }
            }

            var promoProducts = from promo in promotions
                                join baseProduct in allProducts on promo.PromoProductId equals baseProduct.Id
                                join promoProduct in allProducts on promo.PromoProductId equals promoProduct.Id
                                select new
                                {
                                    promo.Id,
                                    promo.Title,
                                    PromoProduct = promoProduct.ProductId != null ? promoProduct.Category.Name + " - " +
                                        promoProduct.VariantOf.Name + " - " + promoProduct.Name
                                        : promoProduct.Category.Name + " - " + promoProduct.Category.Name + " - " + promoProduct.Name,
                                    Quantity = promo.MaxPromoQuantity == null ? (int)(products.Where(x => x.Id.Equals(promo.BaseProductId)).Select(x => x.Quantity).FirstOrDefault() / promo.BaseProductQuantity) * promo.PromoProductQuantity :
                                    (int)(products.Where(x => x.Id.Equals(promo.BaseProductId)).Select(x => x.Quantity).FirstOrDefault() / promo.BaseProductQuantity) * promo.PromoProductQuantity >= promo.MaxPromoQuantity ? promo.MaxPromoQuantity :
                                    (int)(products.Where(x => x.Id.Equals(promo.BaseProductId)).Select(x => x.Quantity).FirstOrDefault() / promo.BaseProductQuantity) * promo.PromoProductQuantity,
                                    PromoProductId = promoProduct.Id,
                                    promo.BaseProductId
                                };
            return Ok(new
            {
                promoProducts
            });
        }
        public IActionResult GetProduct(string cat_Id, string orderId)
        {
            try
            {
                var order = _orderRepo.FindAll(x => x.Id.Equals(new Guid(orderId))).Include(x => x.Customer).ThenInclude(x => x.Route).First();
                var products = _productsRepo.FindAll(x => x.ProductId.Equals(new Guid(cat_Id))).Include(x => x.Discounts).Include(x => x.Prices).
                    Include(x => x.Category).Include(x => x.VariantOf).Select(x => new
                    {
                        Name = x.Category.Name + " - " + x.VariantOf.Name + " - " + x.Name,
                        x.Id,
                        x.Quantity,
                        x.AxCode,
                        Price = x.Prices != null ? x.Prices.Where(z => z.DeletedAt == null && z.From <= order.CreatedAt).OrderByDescending(x => x.From).
                          Select(y => y.Price).First() : 0,
                        Discount = x.Discounts.Where(y => y.IsActive && y.DeletedAt == null && y.CustomerId.Equals(order.CustomerId) || y.CustomerId == null)
                          .Select(z => z.DiscountValue).FirstOrDefault() != null ?
                          x.Discounts.Where(y => y.DeletedAt == null && y.IsActive && (y.CustomerId.Equals(order.CustomerId) || y.CustomerId == null)
                          && (y.RouteId.Equals(order.Customer.RouteId) || y.RouteId == null))
                          .Select(z => z.IsPercentage).FirstOrDefault() == true ?
                          (x.Discounts.Where(y => y.DeletedAt == null && y.IsActive && (y.CustomerId.Equals(order.CustomerId) || y.CustomerId == null)
                          && (y.RouteId.Equals(order.Customer.RouteId) || y.RouteId == null))
                          .Select(z => z.DiscountValue).FirstOrDefault() / 100) * (x.Prices != null ? x.Prices.Where(z => z.DeletedAt == null &&
                            z.From <= order.CreatedAt).OrderByDescending(x => x.From).
                          Select(y => y.Price).First() : 0) : x.Discounts.Where(y => y.DeletedAt == null && y.IsActive && (y.CustomerId.Equals(order.CustomerId)
                          || y.CustomerId == null)
                          && (y.RouteId.Equals(order.Customer.RouteId) || y.RouteId == null)).Select(z => z.DiscountValue).FirstOrDefault() : 0.0,

                    }).ToList();
                if (products.Count > 0)
                {
                    var promotions = _promotionRepo.FindAll(x => x.StartDate <= order.CreatedAt && x.EndDate >= order.CreatedAt && x.IsActive &&
                    (string.IsNullOrEmpty(x.RouteCode) || x.RouteCode.Equals(order.Customer.Route.AxCode)) &&
                    (x.CustomerId == null || x.CustomerId.Equals(order.CustomerId)) && x.DeletedAt == null).ToList();
                    promotions = promotions.Where(x => products.Any(y => y.Id.Equals(x.BaseProductId))).ToList();

                    return Json(new
                    {
                        Flag = "Products",
                        products,
                        promotions
                    });
                }
                else
                {
                    var product = _productsRepo.FindAll(x => x.Id.Equals(new Guid(cat_Id))).Include(x => x.Prices).Include(x => x.Discounts).First();
                    var promotions = _promotionRepo.FindAll(x => x.IsActive && x.DeletedAt == null && x.StartDate <= order.CreatedAt && x.EndDate
                    >= order.CreatedAt && x.IsActive && x.BaseProductId.Equals(product.Id) && (string.IsNullOrEmpty(x.RouteCode) ||
                    x.RouteCode.Equals(order.Customer.Route.AxCode)) && (x.CustomerId == null || x.CustomerId.Equals(order.CustomerId))).ToList();

                    return Json(new
                    {
                        Flag = "Product",
                        product.Id,
                        promotions,
                        Price = product.Prices != null ? product.Prices.Where(z => z.DeletedAt == null && z.From <= order.CreatedAt).OrderByDescending(x => x.From)
                        .Select(y => y.Price).FirstOrDefault() : 0,
                        Discount = product.Discounts.Where(y => y.IsActive && y.DeletedAt == null && (y.CustomerId.Equals(order.CustomerId) || y.CustomerId == null)
                        && (y.RouteId.Equals(order.Customer.RouteId) || y.RouteId == null))
                        .Select(z => z.DiscountValue).FirstOrDefault() != null ?
                        product.Discounts.Where(y => y.DeletedAt == null && (y.CustomerId.Equals(order.CustomerId) || y.CustomerId == null)
                        && (y.RouteId.Equals(order.Customer.RouteId) || y.RouteId == null))
                        .Select(z => z.IsPercentage).FirstOrDefault() == true ?
                        (product.Discounts.Where(y => y.DeletedAt == null && y.IsActive && (y.CustomerId.Equals(order.CustomerId) || y.CustomerId == null)
                        && (y.RouteId.Equals(order.Customer.RouteId) || y.RouteId == null))
                        .Select(z => z.DiscountValue).FirstOrDefault() / 100) * (product.Prices != null ? product.Prices.Where(z => z.From <= order.CreatedAt)
                        .OrderByDescending(x => x.From).
                        Select(y => y.Price).First() : 0) : product.Discounts.Where(y => y.DeletedAt == null && (y.CustomerId.Equals(order.CustomerId) || y.CustomerId == null)
                        && (y.RouteId.Equals(order.Customer.RouteId) || y.RouteId == null)).Select(z => z.DiscountValue).FirstOrDefault() : 0.0,
                    });
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw;
            }
        }
        [HttpGet]
        public IActionResult OrderInvoice(string id)
        {
            try
            {
                var order = _orderRepo.FindAll(x => x.Id.Equals(new Guid(id))).
                Include(x => x.Vehicle).
                Include(x => x.SalesPerson).
                Include(x => x.Customer).ThenInclude(x => x.ProfilePicture).
                Include(x => x.Customer).ThenInclude(x => x.Route).
                Include(x => x.Orders).ThenInclude(x => x.Product).ThenInclude(x => x.VariantOf).
                Include(x => x.Orders).ThenInclude(x => x.Promotion).
                Include(x => x.WasteOrders).ThenInclude(x => x.Product).ThenInclude(x => x.VariantOf).
                Include(x => x.ReturnOrders).ThenInclude(x => x.Product).ThenInclude(x => x.VariantOf).
                Include(x => x.Payment).First();
                var terms = _configRepo.Get(AppConstants.TermsConditions);
                var orderDetail = GetOrderDetails(order);
                var file = _invoiceService.OrderInvoice(orderDetail, terms.Value);
                if (file!=null)
                {
                    return File(fileStream: file, contentType: "application/pdf", fileDownloadName: "Order-" + id + ".pdf");
                }
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }

}