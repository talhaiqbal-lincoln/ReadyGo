using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadyGo.Domain.Constants;
using ReadyGo.Domain.Entities;
using ReadyGo.Domain.Entities.Identity;
using ReadyGo.Domain.Entities.ViewModels;
using ReadyGo.Domain.Enum;
using ReadyGo.Persistence.Seeds;
using ReadyGo.Service.Interfaces;
using ReadyGo.Service.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyGo.Web.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private IGenericRepository<Order> _ordersRepo { get; set; }
        private IGenericRepository<OrderDetail> _ordersDetailRepo { get; set; }
        private IGenericRepository<ReturnOrder> _returnOrderRepo { get; set; }
        private IGenericRepository<Payment> _paymentsRepo { get; set; }
        private IGenericRepository<WasteOrders> _wasteOrderRepo { get; set; }
        public HomeController(IGenericRepository<Order> ordersRepo,
            IGenericRepository<OrderDetail> ordersDetailRepo,
            IGenericRepository<ReturnOrder> returnOrder,
            IGenericRepository<WasteOrders> wasteOrder, IGenericRepository<Payment> paymentsRepo)
        {
            _paymentsRepo = paymentsRepo;
            _returnOrderRepo = returnOrder;
            _wasteOrderRepo = wasteOrder;
            _ordersRepo = ordersRepo;
            _ordersDetailRepo = ordersDetailRepo;
        }
        public IActionResult Index()
        {
            DashboardViewModel model = new DashboardViewModel();
            var monthOrders = _ordersRepo.FindAll(x => !x.IsMarked && x.DeletedAt == null &&
            x.CreatedAt.Month.Equals(DateTime.Now.Month) && x.CreatedAt.Year.Equals(DateTime.Now.Year));

            var prevMonthOrders = _ordersRepo.FindAll(x => !x.IsMarked && x.DeletedAt == null &&
            x.CreatedAt.Month.Equals(DateTime.Now.AddMonths(-1).Month) && x.CreatedAt.Year.Equals(DateTime.Now.AddMonths(-1).Year));

            model.Sales = monthOrders.Sum(x => x.Total);

            var previousOrdersSales = prevMonthOrders.Sum(x => x.Total);

            model.SalesPercentage = previousOrdersSales <= 0 ? 100 : ((model.Sales - previousOrdersSales) / previousOrdersSales)*100;

            var currentOrdersIds = monthOrders.Select(x => x.Id).ToList();
            var prevOrdersIds = prevMonthOrders.Select(x => x.Id).ToList();

            var monthPayments = _paymentsRepo.FindAll(x => !x.IsMarked && x.DeletedAt == null &&
          x.ReceivedAt.Month.Equals(DateTime.Now.Month) && x.ReceivedAt.Year.Equals(DateTime.Now.Year))
               .Sum(x => x.PaymentReceived);

            var prevMonthPayments = _paymentsRepo.FindAll(x => !x.IsMarked && x.DeletedAt == null &&
            x.ReceivedAt.Month.Equals(DateTime.Now.AddMonths(-1).Month) &&
            x.ReceivedAt.Year.Equals(DateTime.Now.AddMonths(-1).Year)).Sum(x => x.PaymentReceived);


            model.Balance = _ordersDetailRepo.FindAll(x => currentOrdersIds.Contains(x.OrderId))
                .Sum(y => (y.Price - y.Discount) * y.Quantity) -
              monthPayments;

            var prevMonthBalance = _ordersDetailRepo.FindAll(x => prevOrdersIds.Contains(x.OrderId))
               .Sum(y => (y.Price - y.Discount) * y.Quantity) -
              prevMonthPayments;

            model.BalancePercentage = prevMonthBalance <= 0 ? 100 : ((model.Balance - prevMonthBalance) / prevMonthBalance) * 100;


            model.Return = _returnOrderRepo.FindAll(x => currentOrdersIds.Contains(x.OrderId))
                .Sum(x => (x.Price - x.Discount) * x.Quantity);

            var previousReturns = _returnOrderRepo.FindAll(x => prevOrdersIds.Contains(x.OrderId))
                .Sum(x => (x.Price - x.Discount) * x.Quantity);
            model.ReturnPercentage = previousReturns == 0 ? 100 : ((model.Return - previousReturns) / previousReturns) * 100;

            model.Waste = _wasteOrderRepo.FindAll(x => currentOrdersIds.Contains(x.OrderId))
                .Sum(x => (x.Price - x.Discount) * x.Quantity);

            var previousWaste = _wasteOrderRepo.FindAll(x => prevOrdersIds.Contains(x.OrderId))
                .Sum(x => (x.Price - x.Discount) * x.Quantity);
            model.WastePercentage = previousWaste == 0 ? 100 : ((model.Waste - previousWaste) / previousWaste) * 100;
            model.SalesPersons = _userManager.Users.Where(x => x.DeletedAt == null && x.IsActive)
                .Select(x => new SalesPerson
                {
                    Id = x.Id,
                    Name = x.FirstName + " " + x.LastName
                });

            var curUser = _userManager.Users.Include(x => x.Role).
                   First(x => x.Id.Equals(User.Claims.First().Value));

            if (curUser.Role.Name.Equals(Roles.SalesManager.GetDescription()))
            {
                var orders = _ordersRepo.FindAll(x => x.DeletedAt == null &&
                !x.IsMarked && x.ApprovedById.Equals(curUser.Id));
                model.SMOrders = orders.Count();
                model.SMApprovedOrders = orders.Where(x => x.Status.Equals(ApprovalStatus.Approved)).Count();
                model.SMReAdjustOrders = orders.Where(x => x.Status.Equals(ApprovalStatus.ReAdjusted)).Count();
            }
            else if (curUser.Role.Name.Equals(Roles.MarketingManager.GetDescription()))
            {
                var orders = _ordersRepo.FindAll(x => x.DeletedAt == null && (x.Status.Equals(ApprovalStatus.ReAdjusted) ||
              x.Status.Equals(ApprovalStatus.Approved)) && !string.IsNullOrEmpty(x.ApprovedById) && !x.IsMarked);

                model.SMOrders = orders.Count();
                model.SMApprovedOrders = orders.Where(x => x.Status.Equals(ApprovalStatus.Approved) &&
                    x.ApprovalFor.Equals(ApprovalFor.SalesManager)).Count();
                model.SMReAdjustOrders = orders.Where(x => x.Status.Equals(ApprovalStatus.ReAdjusted) &&
                  x.ApprovalFor.Equals(ApprovalFor.SalesManager)).Count();

                model.MMOrders = orders.Where(x => x.ApprovedById.Equals(curUser.Id)).Count();
                model.MMApprovedOrders = orders.Where(x => x.Status.Equals(ApprovalStatus.Approved) &&
                    x.ApprovedById.Equals(curUser.Id)).Count();
                model.MMReAdjustOrders = orders.Where(x => x.Status.Equals(ApprovalStatus.ReAdjusted) &&
                    x.ApprovedById.Equals(curUser.Id)).Count();
            }
            var claims = User.Claims.ToArray();
            var currUser = _userManager.Users.Include(x => x.Role).Where(x => x.Id == claims[0].Value).FirstOrDefault();
            ViewBag.Role = currUser.Role.Name;
            return View(model);
        }
        [HttpPost]
        public IActionResult TotalSales(string period, string startDate, string endDate)
        {
            try
            {
                List<string> labels = new List<string>();
                List<double> sales = new List<double>();
                if (!string.IsNullOrEmpty(period))
                {
                    if (period.Equals("Year"))
                    {
                        var orders = _ordersRepo.FindAll(x => x.CreatedAt >= DateTime.Now.AddMonths(-12) &&
                             x.DeletedAt == null && !x.IsMarked).ToList();
                        DateTime start = DateTime.Now.AddMonths(-12);
                        while(start <= DateTime.Now)
                        {
                            var TotalSales = orders.Where(x => x.CreatedAt.Month.Equals(start.Month) && x.CreatedAt.Year.Equals(start.Year)
                            ).Sum(x => x.Total);
                            labels.Add(start.ToString("MMMM"));
                            start = start.AddMonths(1);
                            sales.Add(TotalSales);
                        }

                    }
                    if (period.Equals("Half"))
                    {
                        var orders = _ordersRepo.FindAll(x => x.CreatedAt >= DateTime.Now.AddMonths(-6) &&
                             x.DeletedAt == null && !x.IsMarked).ToList();
                        DateTime start = DateTime.Now.AddMonths(-6);

                        while (start <= DateTime.Now)
                        {
                            var TotalSales = orders.Where(x => x.CreatedAt.Month.Equals(start.Month) && x.CreatedAt.Year.Equals(start.Year)
                                ).Sum(x => x.Total);
                            labels.Add(start.ToString("MMMM"));
                            start = start.AddMonths(1);
                            sales.Add(TotalSales);
                        }

                    }
                    else if (period.Equals("Month"))
                    {
                        DateTime start = DateTime.Now.AddDays(-30), // prev sunday 00:00
                       end = start.AddDays(30); // next sunday 00:00

                        var orders = _ordersRepo.FindAll(x => x.CreatedAt >= start && x.CreatedAt <= end &&
                            x.DeletedAt == null && !x.IsMarked).ToList();

                        while(start.Date<=end.Date)
                        {
                            var TotalSales = orders.Where(x => x.CreatedAt.Date.Equals(start.Date)).Sum(x => x.Total);
                            labels.Add(start.Date.ToString("dd/MM"));
                            sales.Add(TotalSales);
                            start = start.AddDays(1);
                        }
                    }
                    else if (period.Equals("Week"))
                    {
                        DateTime start = DateTime.Now.AddDays(-7), // prev sunday 00:00
                        end = start.AddDays(7); // next sunday 00:00

                        var orders = _ordersRepo.FindAll(x => x.CreatedAt >= start && x.CreatedAt <= end &&
                            x.DeletedAt == null && !x.IsMarked).ToList();

                          while(start.Date<=end.Date)
                        {
                            var TotalSales = orders.Where(x => x.CreatedAt.Date.Equals(start.Date)).Sum(x => x.Total);
                            labels.Add(start.DayOfWeek.ToString());
                            sales.Add(TotalSales);
                            start = start.AddDays(1);
                        }
                    }
                }
                else
                {
                    DateTime from = Convert.ToDateTime(startDate);
                    DateTime end = Convert.ToDateTime(endDate);
                    var diffDays = (end - from).TotalDays;
                    var orders = _ordersRepo.FindAll(x => x.CreatedAt.Date >= from && x.CreatedAt.Date <= end &&
                       x.DeletedAt == null && !x.IsMarked).ToList();

                    if (diffDays < 30)
                    {

                        while (from <= end)
                        {
                            var TotalSales = orders.Where(x => x.CreatedAt.Date.Equals(from.Date)).Sum(x => x.Total);
                            labels.Add(from.Date.ToString("dd/MM"));
                            sales.Add(TotalSales);
                            from = from.AddDays(1);
                        }

                    }
                    else if (diffDays < 366)
                    {
                        while (from <= end)
                        {
                            var TotalSales = orders.Where(x => x.CreatedAt >= from &&
                            x.CreatedAt <= from.AddMonths(1)).Sum(x => x.Total);
                            labels.Add(from.ToString("MMMM"));
                            sales.Add(TotalSales);
                            from = from.AddMonths(1);
                        }
                    }
                    else
                    {
                        while (from <= end)
                        {
                            var TotalSales = orders.Where(x => x.CreatedAt >= from &&
                            x.CreatedAt <= from.AddYears(1)).Sum(x => x.Total);
                            labels.Add(from.ToString("yyyy"));
                            sales.Add(TotalSales);
                            from = from.AddYears(1);
                        }
                    }
                }
                return Ok(new
                {
                    labels,
                    sales
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ex
                });
            }
        }
        [HttpPost]
        public IActionResult SPSales(string period, string sp, string startDate, string endDate)
        {
            try
            {
                List<double> Sum = new List<double>();
                List<string> Name = new List<string>();
                if (string.IsNullOrEmpty(sp) && !string.IsNullOrEmpty(period))
                {
                    if (period.Equals("Year"))
                    {
                        var orders = _ordersRepo.FindAll(x => x.CreatedAt >= DateTime.Now.AddMonths(-12) &&
                             x.DeletedAt == null && !x.IsMarked).Include(x => x.SalesPerson).ToList();

                        var spSalesPersons = orders.Where(x => x.CreatedAt >= DateTime.Now.AddMonths(-12) &&
                            x.CreatedAt <= DateTime.Now).ToList();

                        var spSales = spSalesPersons.GroupBy(x => x.SalesPersonId).Select(x => new
                        {
                            Name = x.First().SalesPerson.FirstName + " " + x.First().SalesPerson.LastName,
                            Sum = x.Sum(x => x.Total)
                        });
                        var response = spSales.OrderByDescending(x => x.Sum).Take(10);
                        return Ok(new
                        {
                            Sum = response.Select(x => x.Sum).ToList(),
                            Name = response.Select(x => x.Name).ToList()

                        });
                    }
                    if (period.Equals("Half"))
                    {
                        var spSalesPersons = _ordersRepo.FindAll(x => x.CreatedAt >= DateTime.Now.AddMonths(-6) && x.CreatedAt <= DateTime.Now
                        && x.DeletedAt == null && !x.IsMarked).Include(x => x.SalesPerson).ToList();
                        var spSales = spSalesPersons.GroupBy(x => x.SalesPersonId).Select(x => new
                        {
                            Name = x.First().SalesPerson.FirstName + " " + x.First().SalesPerson.LastName,
                            Sum = x.Sum(x => x.Total)
                        });
                        var response = spSales.OrderByDescending(x => x.Sum).Take(10);
                        return Ok(new
                        {
                            Sum = response.Select(x => x.Sum).ToList(),
                            Name = response.Select(x => x.Name).ToList()

                        });
                    }
                    else if (period.Equals("Month"))
                    {
                        var spSalesPersons = _ordersRepo.FindAll(x => x.CreatedAt >= DateTime.Now.AddMonths(-1) && x.CreatedAt <= DateTime.Now
                        && x.DeletedAt == null && !x.IsMarked).Include(x => x.SalesPerson).ToList();


                        var spSales = spSalesPersons.GroupBy(x => x.SalesPersonId).Select(x => new
                        {
                            Name = x.First().SalesPerson.FirstName + " " + x.First().SalesPerson.LastName,
                            Sum = x.Sum(x => x.Total),
                            Id = x.Key,
                        });
                        var response = spSales.OrderByDescending(x => x.Sum).Take(10);
                        return Ok(new
                        {
                            Sum = response.Select(x => x.Sum).ToList(),
                            Name = response.Select(x => x.Name).ToList()

                        });
                    }
                    else if (period.Equals("Week"))
                    {
                        DateTime start = DateTime.Now.AddDays(-7), // prev sunday 00:00
                        end = start.AddDays(7); // next sunday 00:00

                        var spSalesPersons = _ordersRepo.FindAll(x => x.CreatedAt.Date >= start && x.CreatedAt.Date <= end &&
                             x.DeletedAt == null && !x.IsMarked).Include(x => x.SalesPerson).ToList();
                        var spSales = spSalesPersons.GroupBy(x => x.SalesPersonId)
                            .Select(x => new
                            {
                                Name = x.First().SalesPerson.FirstName + " " + x.First().SalesPerson.LastName,
                                Sum = x.Sum(x => x.Total)
                            });
                        var response = spSales.OrderByDescending(x => x.Sum).Take(10);
                        return Ok(new
                        {
                            Sum = response.Select(x => x.Sum).ToList(),
                            Name = response.Select(x => x.Name).ToList()

                        });
                    }
                }
                else if (string.IsNullOrEmpty(sp))
                {
                    DateTime from = Convert.ToDateTime(startDate);
                    DateTime end = Convert.ToDateTime(endDate);
                    var diffDays = (end - from).TotalDays;
                    var orders = _ordersRepo.FindAll(x => x.CreatedAt.Date >= from && x.CreatedAt.Date <= end &&
                       x.DeletedAt == null && !x.IsMarked).Include(x=>x.SalesPerson).ToList();

                    var spSales = orders.GroupBy(x => x.SalesPersonId).Select(x => new
                    {
                        Name = x.First().SalesPerson.FirstName + " " + x.First().SalesPerson.LastName,
                        Sum = x.Sum(x => x.Total),
                        Id = x.Key,
                    });
                    var response = spSales.OrderByDescending(x => x.Sum).Take(10);
                    return Ok(new
                    {
                        Sum = response.Select(x => x.Sum).ToList(),
                        Name = response.Select(x => x.Name).ToList()

                    });
                }
                else
                {
                    if (!string.IsNullOrEmpty(period))
                    {
                        if (period.Equals("Year"))
                        {
                            var orders = _ordersRepo.FindAll(x => x.CreatedAt >= DateTime.Now.AddMonths(-12) &&
                                 x.DeletedAt == null && !x.IsMarked && x.SalesPersonId.Equals(sp)).ToList();
                            DateTime start = DateTime.Now.AddMonths(-12);

                            while (start <= DateTime.Now)
                            {
                                var TotalSales = orders.Where(x => x.CreatedAt.Month.Equals(start.Month) && x.CreatedAt.Year.Equals(start.Year)
                                ).Sum(x => x.Total);
                                Name.Add(start.ToString("MMMM"));
                                start = start.AddMonths(1);
                                Sum.Add(TotalSales);
                            }

                        }
                        if (period.Equals("Half"))
                        {
                            var orders = _ordersRepo.FindAll(x => x.CreatedAt >= DateTime.Now.AddMonths(-6) &&
                                 x.DeletedAt == null && !x.IsMarked && x.SalesPersonId.Equals(sp)).ToList();
                            DateTime start = DateTime.Now.AddMonths(-6);

                            while (start <= DateTime.Now)
                            { 
                                var TotalSales = orders.Where(x => x.CreatedAt.Month.Equals(start.Month) && x.CreatedAt.Year.Equals(start.Year)
                                ).Sum(x => x.Total);
                                 Name.Add(start.ToString("MMMM"));
                                start = start.AddMonths(1);
                                Sum.Add(TotalSales);
                            }

                        }
                        else if (period.Equals("Month"))
                        {
                            DateTime start = DateTime.Now.AddDays(-30), // prev sunday 00:00
                           end = start.AddDays(30); // next sunday 00:00

                            var orders = _ordersRepo.FindAll(x => x.CreatedAt >= start && x.CreatedAt < end &&
                                x.DeletedAt == null && !x.IsMarked && x.SalesPersonId.Equals(sp)).ToList();

                            while (start.Date <= end.Date)
                            {
                                var TotalSales = orders.Where(x => x.CreatedAt.Date.Equals(start.Date)).Sum(x => x.Total);
                                Name.Add(start.Date.ToString("dd/MM"));
                                Sum.Add(TotalSales);
                                start = start.AddDays(1);
                            }
                        }
                        else if (period.Equals("Week"))
                        {
                            DateTime start = DateTime.Now.AddDays(-7), // prev sunday 00:00
                            end = start.AddDays(7); // next sunday 00:00

                            var orders = _ordersRepo.FindAll(x => x.CreatedAt.Date >= start.Date && x.CreatedAt.Date < end.Date &&
                                x.DeletedAt == null && !x.IsMarked && x.SalesPersonId.Equals(sp)).ToList();

                            while (start.Date <= end.Date)
                            {
                                var TotalSales = orders.Where(x => x.CreatedAt.Date.Equals(start.Date)).Sum(x => x.Total);
                                Name.Add(start.DayOfWeek.ToString());
                                Sum.Add(TotalSales);
                                start = start.AddDays(1);
                            }
                        }
                    }
                    else
                    {
                        DateTime from = Convert.ToDateTime(startDate);
                        DateTime end = Convert.ToDateTime(endDate);
                        var diffDays = (end - from).TotalDays;
                        var orders = _ordersRepo.FindAll(x => x.CreatedAt.Date >= from.Date && x.CreatedAt.Date <= end.Date &&
                           x.DeletedAt == null && !x.IsMarked && x.SalesPersonId.Equals(sp)).ToList();

                        if (diffDays < 30)
                        {
                            while(from<=end)
                            {
                                var TotalSales = orders.Where(x => x.CreatedAt.Date.Equals(from.Date) && x.CreatedAt.Month.Equals(from.Month) && 
                                    x.CreatedAt.Year.Equals(from.Year)).Sum(x => x.Total);
                                Name.Add(from.Date.ToString("dd/MM"));
                                Sum.Add(TotalSales);
                                from = from.AddDays(1);
                            }

                        }
                        else if (diffDays < 366)
                        {
                            while (from <= end)
                            {
                                var TotalSales = orders.Where(x => x.CreatedAt.Month.Equals(from.Month) &&
                                    x.CreatedAt.Year.Equals(from.Year)).Sum(x => x.Total);
                                Name.Add(from.ToString("MMMM"));
                                Sum.Add(TotalSales);
                                from = from.AddMonths(1);
                            }
                        }
                        else
                        {
                            while (from <= end)
                            {
                                var TotalSales = orders.Where(x => x.CreatedAt.Year.Equals(from.Year)).Sum(x => x.Total);
                                Name.Add(from.ToString("yyyy"));
                                Sum.Add(TotalSales);
                                from = from.AddYears(1);
                            }
                        }
                    }
                }
                return Ok(new
                {
                    Sum,
                    Name
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    ex
                });
            }
        }
        [HttpPost]
        public IActionResult SpTable()
        {
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var status = Request.Form["status"].FirstOrDefault();
                var sortColumn = Request.Form["order[0][column]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search"].FirstOrDefault().Trim();
                var flag = Request.Form["flag"].FirstOrDefault();
                int pageSize = Convert.ToInt32(length ?? "0");
                int skip = Convert.ToInt32(start ?? "0");
                int recordsTotal = 0;

                var sps = _userManager.Users.
                    Include(x => x.Role).Include(x => x.ProfileImage).
                    Where(x => x.DeletedAt == null && x.EmailConfirmed && x.IsActive &&
                    x.Role.Name.Equals(Roles.SalesPerson.GetDescription())).ToList();
                var allOrders = _ordersRepo.FindAll(x => !x.IsMarked && x.DeletedAt == null && x.CreatedAt >= DateTime.Now.AddDays(-30))
                    .Include(x => x.WasteOrders).Include(x => x.ReturnOrders);
                List<SpDashboardTable> spDate = new List<SpDashboardTable>();
                foreach (var salesperson in sps)
                {
                    var spOrders = allOrders.Where(x => x.SalesPersonId.Equals(salesperson.Id)).ToList();
                    spDate.Add(new SpDashboardTable()
                    {
                        Name = salesperson.FirstName + " " + salesperson.LastName,
                        ProfileImage = salesperson.ProfileImage != null ? "data:image;base64," + Convert.ToBase64String(salesperson.ProfileImage.File) : "resource_files/default_user.jpg",
                        Sales = spOrders.Sum(x => x.Total),
                        Waste = spOrders.Sum(x => x.ReturnOrders.Sum(y => (y.Price - y.Discount) * y.Quantity) +
                            x.WasteOrders.Sum(y => (y.Price - y.Discount) * y.Quantity)),
                        Discount = spOrders.Sum(x => x.Discount)
                    });
                }

                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    int column = Int32.Parse(sortColumn);
                    switch (column)
                    {
                        case 0:
                            spDate = sortColumnDirection == "asc" ? spDate.OrderBy(c => c.Name).ToList() :
                                spDate.OrderByDescending(c => c.Name).ToList();
                            break;

                        case 1:
                            spDate = sortColumnDirection == "asc" ? spDate.OrderBy(c => c.Sales).ToList()
                                : spDate.OrderByDescending(c => c.Sales).ToList();
                            break;

                        case 2:
                            spDate = sortColumnDirection == "asc" ? spDate.OrderBy(c => c.Waste).ToList()
                                : spDate.OrderByDescending(c => c.Waste).ToList();
                            break;

                        case 3:
                            spDate = sortColumnDirection == "asc" ? spDate.OrderBy(c => c.Discount).ToList()
                                : spDate.OrderByDescending(c => c.Discount).ToList();
                            break;
                    }
                }

                if (!string.IsNullOrEmpty(searchValue))
                {
                    spDate = spDate.Where(m => m.Name.ToLower().Contains(searchValue.ToLower())).ToList();
                }
                recordsTotal = spDate.Count();
                var data = spDate.Skip(skip).Take(pageSize).ToList();

                return Json(new { draw, recordsFiltered = recordsTotal, recordsTotal, data });
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw;
            }
        }

        [HttpGet]
        public IActionResult RecordDeleted()
        {
            ViewBag.Message = TempData["Message"];
            return View();
        }
    }
}