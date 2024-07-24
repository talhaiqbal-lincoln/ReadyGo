using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadyGo.Domain.Entities;
using ReadyGo.Infrastructure.Filters;
using ReadyGo.Service.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using ReadyGo.Domain.Entities.ViewModels;
using ReadyGo.Domain.Constants;
using ReadyGo.Domain.Enum;
using ReadyGo.Persistence.Seeds;

namespace ReadyGo.Web.Controllers
{
    [Authorize]
    [TypeFilter(typeof(AuthorizationFilter))]
    public class PromoController : BaseController
    {
        private readonly IGenericRepository<Promotion> _promosRepo;
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Route> _routesRepo;

        public PromoController(IGenericRepository<Promotion> promosRepo,
            IGenericRepository<Product> productsRepo, IMapper mapper,
            IGenericRepository<Route> routesRepo)
        {
            _routesRepo = routesRepo;
            _mapper = mapper;
            _productsRepo = productsRepo;
            _promosRepo = promosRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AllPromos()
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

                var products = _productsRepo.GetAll().Include(x => x.VariantOf).AsEnumerable();
                var routes = _routesRepo.GetAll().AsEnumerable();

                var promos = _promosRepo.FindAll(x => x.DeletedAt == null).
                    Include(x => x.BaseProduct).ThenInclude(x => x.VariantOf)
                    .Include(x => x.PromoProduct).ThenInclude(x => x.VariantOf)
                    .Include(x => x.Route).ToList();
                List<PromoTableViewModel> promosData = _mapper.Map<List<PromoTableViewModel>>(promos);

                if (promosData.Count > 0)
                {
                    if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                    {
                        int column = Int32.Parse(sortColumn);
                        switch (column)
                        {
                            case 0:
                                promosData = (sortColumnDirection == "asc" ? promosData.OrderBy(c => c.AxCode)
                                    : promosData.OrderByDescending(c => c.AxCode)).ToList();
                                break;
                            
                            case 1:
                                promosData = (sortColumnDirection == "asc" ? promosData.OrderBy(c => c.Title)
                                    : promosData.OrderByDescending(c => c.Title)).ToList();
                                break;

                            case 2:
                                promosData = (sortColumnDirection == "asc" ? promosData.OrderBy(c => c.RouteName)
                                    : promosData.OrderByDescending(c => c.RouteName)).ToList();
                                break;

                            case 3:
                                promosData = (sortColumnDirection == "asc" ? promosData.OrderBy(c => c.BaseProduct)
                                    : promosData.OrderByDescending(c => c.BaseProduct)).ToList();
                                break;

                            case 4:
                                promosData = (sortColumnDirection == "asc" ? promosData.OrderBy(c => c.PromoProduct)
                                    : promosData.OrderByDescending(c => c.PromoProduct)).ToList();
                                break;

                            case 5:
                                promosData = (sortColumnDirection == "asc" ? promosData.OrderBy(c => c.MaxQuantity)
                                    : promosData.OrderByDescending(c => c.MaxQuantity)).ToList();
                                break;

                            case 6:
                                promosData = (sortColumnDirection == "asc" ? promosData.OrderBy(c => c.StartDate).ThenBy(c=>c.EndDate)
                                    : promosData.OrderByDescending(c => c.StartDate).ThenByDescending(c=>c.EndDate)).ToList();
                                break;
                        }
                    }
                    if (!string.IsNullOrEmpty(searchValue))
                    {
                        promosData = promosData.Where(m => m.Title.Contains(searchValue, StringComparison.OrdinalIgnoreCase)
                                            || (!string.IsNullOrEmpty(m.RouteName) && m.RouteName.Contains(searchValue, StringComparison.OrdinalIgnoreCase))
                                            || m.BaseProduct.Contains(searchValue, StringComparison.OrdinalIgnoreCase)
                                            || m.PromoProduct.Contains(searchValue, StringComparison.OrdinalIgnoreCase)
                                            || m.AxCode.Contains(searchValue, StringComparison.OrdinalIgnoreCase)).ToList();
                    }
                    recordsTotal = promosData.Count();
                    var data = promosData.Skip(skip).Take(pageSize).ToList();

                    return Json(new { draw, recordsFiltered = recordsTotal, recordsTotal, data });
                }
                recordsTotal = 0;
                return Json(new { draw, recordsFiltered = recordsTotal, recordsTotal, data = promosData});
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw;
            }
        }
      
        [HttpGet]
        public async Task<IActionResult> ChangeStatusAsync(string id)
        {
            try
            {
                Guid custId = new Guid(id);
                var promo = _promosRepo.Get(custId);
                promo.IsActive = !promo.IsActive;
                _promosRepo.Update(promo);
                var Message = string.Empty;
                if (promo.IsActive)
                {
                    Message = string.Format(SuccessMessageConstants.ActiveSuccess, "Promo");
                }
                else
                {
                    Message = string.Format(SuccessMessageConstants.InactiveSuccess, "Promo");
                }
                await AddLogAsync(LogActions.ChangeStatus.GetDescription(), promo.Title, LogsActionSrc.PromoManagement.ToString());
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
        public IActionResult Details(string id)
        {
            var promo = _promosRepo.FindAll(x=>x.Id.Equals(new Guid(id)))
                .Include(x=>x.BaseProduct).ThenInclude(x=>x.VariantOf)
                .Include(x=>x.PromoProduct).ThenInclude(x=>x.VariantOf)
                .Include(x=>x.Route).First();
            var promoDetails = _mapper.Map<PromoTableViewModel>(promo);
            return View(promoDetails);
        }
    }
}