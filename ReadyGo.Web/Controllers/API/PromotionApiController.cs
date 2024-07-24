using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadyGo.Domain.Constants;
using ReadyGo.Domain.Entities;
using ReadyGo.Domain.Entities.ApiModels;
using ReadyGo.Domain.Entities.Identity;
using ReadyGo.Domain.Enum;
using ReadyGo.Persistence.Seeds;
using ReadyGo.Service.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReadyGo.Web.Controllers.API
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "mobile")]
    [Route("api/v{version:apiVersion}/Promotion/")]
    public class PromotionApiController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Promotion> _promotionRepo;
        private readonly UserManager<ApplicationUser> _userManager;

        public PromotionApiController(IMapper mapper, IGenericRepository<Promotion> promotionRepo,
                                      UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _promotionRepo = promotionRepo;
            _userManager = userManager;
        }

        /// <summary>
        /// Get method for get Promos
        /// </summary>
        /// <returns>Return a list of active promotions</returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        [Route("GetPromotions")]
        public IActionResult GetPromotions()
        {
            try
            {
                List<Promotion> promotionEntityList = new List<Promotion>();

                var email = DecodeJwt();

                var user = _userManager.Users.Include(x => x.Routes.Where(x => x.DeletedAt == null))
                    .ThenInclude(x => x.Route).ThenInclude(x => x.Promotions.Where(x => x.DeletedAt == null && x.IsActive))
                    .AsNoTracking().FirstOrDefault(x => x.Email.Equals(email));

                if (!user.IsActive)
                {
                    return Forbid();
                }

                List<AssignedRoute> assignRoutes = new List<AssignedRoute>();

                var permanentRoute = user.Routes.FirstOrDefault(x => !x.TemporaryAssignedTill.HasValue && x.Route.DeletedAt == null && x.Route.IsActive);

                if (permanentRoute != null)
                {
                    assignRoutes.Add(permanentRoute);
                }

                var temporaryRoute = user.Routes.FirstOrDefault(x => x.TemporaryAssignedTill.HasValue && x.TemporaryAssignedTill.Value.Date >= DateTime.Today.Date
                   && x.Route.DeletedAt == null && x.Route.IsActive);

                if (temporaryRoute != null)
                {
                    assignRoutes.Add(temporaryRoute);
                }

                if (assignRoutes != null && assignRoutes.Count > 0)
                {
                    foreach (var item in assignRoutes)
                    {
                        promotionEntityList.AddRange(item.Route.Promotions);
                    }
                }
                var openPromo = _promotionRepo.FindAll(x => x.DeletedAt == null && x.IsActive && x.RouteId == null).AsNoTracking().ToList();
                if (openPromo != null && openPromo.Count > 0)
                {
                    promotionEntityList.AddRange(openPromo);
                }
                var promoViewList = _mapper.Map<List<PromotionApiViewModel>>(promotionEntityList);

                var responseData = new
                {
                    Promotions = promoViewList
                };
                return Ok(new ApiResponseModel(responseData));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponseModel(ApiStatus.Error, ApiErrors.DefaultError.GetDescription(), ApiErrors.DefaultError));
            }
        }
    }
}