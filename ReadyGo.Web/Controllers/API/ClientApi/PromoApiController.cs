using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReadyGo.Domain.Constants;
using ReadyGo.Domain.Entities;
using ReadyGo.Domain.Entities.ViewModels;
using ReadyGo.Domain.Enum;
using ReadyGo.Service.Repositories.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;

namespace ReadyGo.Web.Controllers.API.ClientApi
{
    //    [ApiKey]
    [ApiController]
    [ApiVersion("2.0")]
    [ApiExplorerSettings(GroupName = "client")]
    [Route("api/v{version:apiVersion}/Promos/")]
    [SwaggerTag("Create, Read, Update and Delete Promos based on Promo Id Or AxCode")]
    public class PromoApiController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Promotion> _promoRepo;
        private readonly IGenericRepository<Route> _routeRepo;
        private readonly IGenericRepository<Product> _productRepo;

        public PromoApiController(IGenericRepository<Promotion> promoRepo, IGenericRepository<Route> routeRepo, IGenericRepository<Product> productRepo, IMapper mapper)
        {
            _mapper = mapper;
            _promoRepo = promoRepo;
            _routeRepo = routeRepo;
            _productRepo = productRepo;
        }

        /// <summary>
        /// Get all the Registered promos
        /// </summary>
        /// <returns>Routes</returns>
        [HttpGet]
        [Route("GetPromos")]
        public IActionResult GetAll()
        {
            try
            {
                var promos = _promoRepo.FindAll(x => x.DeletedAt == null);

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = SuccessMessageConstants.DefaultSuccess, Promotions = promos });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        /// Get a registered promo based on promo id
        /// </summary>
        /// <returns>Promo if id is valid </returns>
        /// <response code="200">Promo found against id provided.</response>
        /// <response code="400">Promo not found against id provided.</response>
        [HttpGet("GetPromoById/{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var promo = _promoRepo.FindBy(x => x.Id == id && x.DeletedAt == null);
                if (promo == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, "Promo") });

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = SuccessMessageConstants.DefaultSuccess, Promotion = promo });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        /// Get a registered promo based on promo AxCode
        /// </summary>
        /// <returns>Promo if AxCode is valid </returns>
        /// <response code="200">Promo found against code provided.</response>
        /// <response code="400">Promo not found against code provided.</response>
        [HttpGet("GetPromoByAx/{code}")]
        public IActionResult GetByAx(string code)
        {
            try
            {
                var promo = _promoRepo.FindBy(x => x.AxCode == code && x.DeletedAt == null);
                if (promo == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, "Promo") });

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = SuccessMessageConstants.DefaultSuccess, Promotion = promo });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        /// Register a new Promo.
        /// </summary>
        /// <param name="promoVM"></param>
        /// <returns> Message based on valid promo</returns>
        /// <response code="200">Promo created successfully</response>
        /// <response code="400">Error occured while saving a new promo</response>
        [HttpPost]
        [Route("InsertPromo")]
        public IActionResult Post([FromBody] PromotionViewModel promoVM)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception();

                if (_promoRepo.FindBy(x => x.Title.ToLower() == promoVM.Title.ToLower() && x.DeletedAt == null) != null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.AlreadyExists, "Promo " + promoVM.Title) });

                if (!string.IsNullOrWhiteSpace(promoVM.RouteCode) && (_routeRepo.FindBy(x => x.AxCode == promoVM.RouteCode && x.DeletedAt == null) == null))
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotValid, "Route") });

                if (promoVM.StartDate >= promoVM.EndDate)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.InvalidDate });

                if (promoVM.BaseProductQuantity < 1 || promoVM.PromoProductQuantity < 1 || promoVM.MaxPromoQuantity < 0)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotValid, "Quantity") });

                var promo = _mapper.Map<Promotion>(promoVM);

                var baseProduct = _productRepo.FindBy(x => x.AxCode == promoVM.BaseProductCode && x.DeletedAt == null);
                promo.BaseProductId = baseProduct.Id;
                promo.BaseProduct = baseProduct;

                var promoProduct = _productRepo.FindBy(x => x.AxCode == promoVM.PromoProductCode && x.DeletedAt == null);
                promo.PromoProductId = promoProduct.Id;
                promo.PromoProduct = promoProduct;

                promo.IsActive = true;
                promo.SyncedAt = DateTime.Now;

                _promoRepo.Insert(promo);

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = string.Format(SuccessMessageConstants.CreateSuccess, promo.Title) });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        /// Register multiple promos at a time
        /// </summary>
        [HttpPost]
        [Route("InsertMultiplePromos")]
        [ProducesResponseType(typeof(PromotionViewModel), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Produces("application/json", "application/xml")]
        public IActionResult InsertMultiplePromos([FromBody] IEnumerable<PromotionViewModel> promos)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception();

                List<object> responseMessages = new List<object>();
                var count = 0;
                foreach (var promo in promos)
                {
                    count++;

                    var existingPromo = _promoRepo.FindBy(x => (x.Title.ToLower() == promo.Title.ToLower()) && x.DeletedAt == null);
                    if (existingPromo != null)
                    {
                        responseMessages.Add(new { RecordNumber = count, Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.AlreadyExists, "Promo " + promo.Title) });
                        continue;
                    }

                    if (!string.IsNullOrWhiteSpace(promo.RouteCode) && (_routeRepo.FindBy(x => x.AxCode == promo.RouteCode && x.DeletedAt == null) == null))
                    {
                        responseMessages.Add(new { RecordNumber = count, Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotValid, "Route") });
                        continue;
                    }

                    if (promo.StartDate >= promo.EndDate)
                    {
                        responseMessages.Add(new { RecordNumber = count, Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.InvalidDate });
                        continue;
                    }

                    if (promo.BaseProductQuantity < 1 || promo.PromoProductQuantity < 1)
                    {
                        responseMessages.Add(new { RecordNumber = count, Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotValid, "Quantity") });
                        continue;
                    }

                    var newPromo = _mapper.Map<Promotion>(promo);

                    var baseProduct = _productRepo.FindBy(x => x.AxCode == promo.BaseProductCode && x.DeletedAt == null);
                    newPromo.BaseProductId = baseProduct.Id;
                    newPromo.BaseProduct = baseProduct;

                    var promoProduct = _productRepo.FindBy(x => x.AxCode == promo.PromoProductCode && x.DeletedAt == null);
                    newPromo.PromoProductId = promoProduct.Id;
                    newPromo.PromoProduct = promoProduct;


                    newPromo.IsActive = true;
                    newPromo.SyncedAt = DateTime.Now;

                    if (_promoRepo.Insert(newPromo))
                    {
                        responseMessages.Add(new { RecordNumber = count, Status = ApiStatus.Success, Message = string.Format(SuccessMessageConstants.CreateSuccess, promo.Title) });
                        continue;
                    }
                    else
                    {
                        responseMessages.Add(new { RecordNumber = count, Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
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

        [HttpPut("UpdatePromo/{id}")]
        public IActionResult Put(Guid id, [FromBody] PromotionViewModel promoVM)
        {
            try
            {
                var promo = _promoRepo.FindBy(x => x.Id == id && x.DeletedAt == null);
                if (promo == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, "Promo") });

                if (_promoRepo.FindBy(x => x.Title == promo.Title && x.Id != id && x.DeletedAt == null) != null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.AlreadyExists, "Promo " + promo.Title) });

                if (promoVM.StartDate >= promoVM.EndDate)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.InvalidDate });

                if (promoVM.BaseProductQuantity < 1 || promoVM.PromoProductQuantity < 1 || promoVM.MaxPromoQuantity < 0)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotValid, "Quantity") });

                promo.Title = promoVM.Title;
                promo.Description = promoVM.Description;
                promo.RouteCode = promoVM.RouteCode;
                promo.AxCode = promoVM.AxCode;
                promo.SyncedAt = DateTime.Now;
                promo.BaseProductCode = promoVM.BaseProductCode;
                promo.BaseProductQuantity = promoVM.BaseProductQuantity;
                promo.PromoProductCode = promoVM.PromoProductCode;
                promo.PromoProductQuantity = promoVM.PromoProductQuantity;
                promo.MaxPromoQuantity = promoVM.MaxPromoQuantity;

                var baseProduct = _productRepo.FindBy(x => x.AxCode == promoVM.BaseProductCode && x.DeletedAt == null);
                promo.BaseProductId = baseProduct.Id;

                var promoProduct = _productRepo.FindBy(x => x.AxCode == promoVM.PromoProductCode && x.DeletedAt == null);
                promo.PromoProductId = promoProduct.Id;

                _promoRepo.Update(promo);

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = string.Format(SuccessMessageConstants.UpdateSuccess, promo.Title) });

            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        /// Delete a promo.
        /// </summary>
        /// <returns> Message based on deleted promo</returns>
        /// <response code="200">If promo deleted successfully</response>
        /// <response code="400">If promo not found against id provided.</response>
        [HttpDelete("DeletePromo/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var promo = _promoRepo.FindBy(x => x.Id == id && x.DeletedAt == null);
                if (promo == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, "Promo") });

                promo.DeletedAt = DateTime.Now;
                _promoRepo.Update(promo);

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = string.Format(SuccessMessageConstants.DeleteSuccess, promo.Title) });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        /// Delete a promo based on AxCode
        /// </summary>
        /// <returns> Message based on deleted promo</returns>
        /// <response code="200">If promo deleted successfully</response>
        /// <response code="400">If promo not found against AxCode provided.</response>
        [HttpDelete("DeletePromoByAx/{code}")]
        public IActionResult Delete(string code)
        {
            try
            {
                var promo = _promoRepo.FindBy(x => x.AxCode == code && x.DeletedAt == null);
                if (promo == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, "AxCode") });

                promo.DeletedAt = DateTime.Now;
                _promoRepo.Update(promo);

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = string.Format(SuccessMessageConstants.DeleteSuccess, promo.Title) });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }
    }
}
