using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReadyGo.Domain.Constants;
using ReadyGo.Domain.Entities;
using ReadyGo.Domain.Entities.ApiModels;
using ReadyGo.Domain.Entities.ViewModels;
using ReadyGo.Domain.Enum;
using ReadyGo.Service.Repositories.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReadyGo.Web.Controllers.API.ClientApi
{
    [ApiController]
    [ApiVersion("2.0")]
    [ApiExplorerSettings(GroupName = "client")]
    [Route("api/v{version:apiVersion}/PriceHistory/")]
    [SwaggerTag("Create, Read, Update and Delete Price History based on Product Id Or AxCode")]
    public class PriceHistoryApiController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<PriceHistory> _priceHistoryRepo;
        private readonly IGenericRepository<Product> _productRepo;

        public PriceHistoryApiController(IGenericRepository<PriceHistory> priceHistoryRepo, IGenericRepository<Product> productRepo, IMapper mapper)
        {
            _mapper = mapper;
            _productRepo = productRepo;
            _priceHistoryRepo = priceHistoryRepo;
        }

        /// <summary>
        /// Get All Product's Price Histories
        /// </summary>
        [HttpGet]
        [Route("GetPriceHistories")]
        public IActionResult GetAll()
        {
            try
            {
                var productPriceHistories = _priceHistoryRepo.FindAll(x => x.DeletedAt == null).ToList().GroupBy(x => x.ProductId, (key, g) => new { ProductId = key, ProductPriceHistory = g.Select(x => new { x.Id, x.Price, x.Tax, x.From }).ToList() });

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = SuccessMessageConstants.DefaultSuccess, ProductPriceHistories = productPriceHistories });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        /// Get PriceHistory based on Product Id.
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Price history found against id provided.</response>
        /// <response code="400">Price history not found against id provided.</response>
        [HttpGet("GetPriceHistoryByProductId/{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var priceHistory = _priceHistoryRepo.FindAll(x => x.ProductId == id && x.DeletedAt == null).Select(x => new { x.Id, x.Price, x.Tax, x.From });
                if (priceHistory == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotValid, "Product Id") });

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = SuccessMessageConstants.DefaultSuccess, ProductPriceHistory = priceHistory });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        /// Get PriceHistory based on Product AxCode.
        /// </summary>
        /// <param name="code"></param>
        /// <response code="200">Price history found against AxCode provided.</response>
        /// <response code="400">Price history not found against AxCode provided.</response>
        [HttpGet("GetPriceHistoryByProductAxCode/{code}")]
        public IActionResult GetByAxCode(string code)
        {
            try
            {
                var product = _productRepo.FindBy(x => x.AxCode == code && x.DeletedAt == null);
                if (product == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotValid, "Product") });

                var priceHistory = _priceHistoryRepo.FindAll(x => x.ProductId == product.Id && x.DeletedAt == null).Select(x => new { x.Id, x.Price, x.Tax, x.From });
                if (priceHistory == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotValid, "Product Id") });

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = SuccessMessageConstants.DefaultSuccess, ProductPriceHistory = priceHistory });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        /// Add a new price history against a specific product.
        /// </summary>
        /// <param name="priceHistoryVM"></param>
        /// <response code="200">If new price history added successfully</response>
        /// <response code="400">If pricehistory FromDate is less than today's date</response>
        [HttpPost]
        [Route("InsertPriceHistory")]
        public IActionResult Post([FromBody] PriceHistoryViewModel priceHistoryVM)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception();

                var product = _productRepo.FindBy(x => x.AxCode == priceHistoryVM.ProductAxCode && x.DeletedAt == null);
                if (product == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotValid, "Product AxCode") });

                if (priceHistoryVM.From < DateTime.Today)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.InvalidPriceHistoryDate });

                if (priceHistoryVM.Price <= 0)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.InvalidAmount, "Price") });

                var priceHistory = _mapper.Map<PriceHistory>(priceHistoryVM);
                priceHistory.ProductId = product.Id;
                priceHistory.Product = product;
                priceHistory.CreatedAt = DateTime.Now;

                _priceHistoryRepo.Insert(priceHistory);
                return Ok(new { Status = ApiStatus.Success.ToString(), Message = string.Format(SuccessMessageConstants.CreateSuccess, "Price History") });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }


        /// <summary>
        /// Add multiple price histories against products.
        /// </summary>
        /// <param name="priceHistories"></param>
        [HttpPost]
        [Route("InsertMultiplePriceHistories")]
        public IActionResult InsertMultiplePriceHistories([FromBody] List<PriceHistoryViewModel> priceHistories)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception();

                List<object> responseMessages = new List<object>();
                var count = 0;
                foreach (var priceHistoryVM in priceHistories)
                {
                    count++;

                    var product = _productRepo.FindBy(x => x.AxCode == priceHistoryVM.ProductAxCode && x.DeletedAt == null);
                    if (product == null)
                    {
                        responseMessages.Add(new { RecordNumber = count, Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotValid, "Product AxCode") });
                        continue;
                    }

                    if (priceHistoryVM.From < DateTime.Today)
                    {
                        responseMessages.Add(new { RecordNumber = count, Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.InvalidPriceHistoryDate });
                        continue;
                    }

                    if (priceHistoryVM.Price <= 0)
                    {
                        responseMessages.Add(new { RecordNumber = count, Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.InvalidAmount, "Price") });
                        continue;
                    }

                    var priceHistory = _mapper.Map<PriceHistory>(priceHistoryVM);
                    priceHistory.ProductId = product.Id;
                    priceHistory.Product = product;
                    priceHistory.CreatedAt = DateTime.Now;

                    if (_priceHistoryRepo.Insert(priceHistory))
                    {
                        responseMessages.Add(new { RecordNumber = count, Status = ApiStatus.Success, Message = string.Format(SuccessMessageConstants.CreateSuccess, "Price History") });
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
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        /// Update a price history based on productId and price history applied date.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="fromDate"></param>
        /// <param name="priceHistoryVM"></param>
        /// <response code="200">If route updated successfully</response>
        /// <response code="500">If route already exist with same name</response>
        [HttpPut("UpdatePriceHistory/{productId}/{fromDate}")]
        public IActionResult Put(Guid productId, DateTime fromDate, [FromBody] PriceHistoryViewModel priceHistoryVM)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception();

                var product = _productRepo.FindBy(x => x.Id == productId && x.DeletedAt == null);
                if (product == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotValid, "Product Id") });

                var priceHistory = _priceHistoryRepo.FindBy(x => x.ProductId == productId && x.From.Date == fromDate.Date && x.DeletedAt == null);
                if (priceHistory == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, "Price History") });

                if (priceHistoryVM.From < DateTime.Today)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.InvalidPriceHistoryDate });

                if (priceHistoryVM.Price <= 0)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.InvalidAmount, "Price") });

                priceHistory.Price = priceHistoryVM.Price;
                priceHistory.Tax = priceHistoryVM.Tax;
                priceHistory.From = priceHistoryVM.From;

                _priceHistoryRepo.Update(priceHistory);
                var responseData = new { Message = string.Format(SuccessMessageConstants.UpdateSuccess, "Price history") };
                return Ok(new ApiResponseModel(responseData));
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        /// Update a price history based on productId and price history applied date.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="fromDate"></param>
        /// <param name="priceHistoryVM"></param>
        /// <response code="200">If route updated successfully</response>
        /// <response code="500">If route already exist with same name</response>
        [HttpPut("UpdatePriceHistoryByProductAxCode/{code}/{fromDate}")]
        public IActionResult PutByAxCode(string code, DateTime fromDate, [FromBody] PriceHistoryViewModel priceHistoryVM)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception();

                var product = _productRepo.FindBy(x => x.AxCode == code && x.DeletedAt == null);
                if (product == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotValid, "Product AxCode") });

                var priceHistory = _priceHistoryRepo.FindBy(x => x.ProductId == product.Id && x.From.Date == fromDate.Date && x.DeletedAt == null);
                if (priceHistory == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, "Price History") });

                if (priceHistoryVM.From < DateTime.Today)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.InvalidPriceHistoryDate });

                if (priceHistoryVM.Price <= 0)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.InvalidAmount, "Price") });

                priceHistory.Price = priceHistoryVM.Price;
                priceHistory.Tax = priceHistoryVM.Tax;
                priceHistory.From = priceHistoryVM.From;

                _priceHistoryRepo.Update(priceHistory);
                var responseData = new { Message = string.Format(SuccessMessageConstants.UpdateSuccess, "Price history") };
                return Ok(new ApiResponseModel(responseData));
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }
    }
}
