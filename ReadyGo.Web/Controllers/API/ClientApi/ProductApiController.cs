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
using System.Linq;

namespace ReadyGo.Web.Controllers.API.ClientApi
{
    // [ApiKey]
    [ApiController]
    [ApiVersion("2.0")]
    [ApiExplorerSettings(GroupName = "client")]
    [Route("api/v{version:apiVersion}/Products/")]
    [SwaggerTag("Create, Read, Update and Delete Products based on Product Id Or AxCode")]
    public class ProductApiController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<PriceHistory> _priceHistoryRepo;
        private readonly IGenericRepository<ResourceFile> _filesRepo;
        private readonly IGenericRepository<Category> _categoryRepo;

        public ProductApiController(IGenericRepository<Product> productsRepo, IGenericRepository<PriceHistory> priceHistoryRepo, IMapper mapper, IGenericRepository<ResourceFile> filesRepo, IGenericRepository<Category> categoryRepo)
        {
            _mapper = mapper;
            _productsRepo = productsRepo;
            _priceHistoryRepo = priceHistoryRepo;
            _filesRepo = filesRepo;
            _categoryRepo = categoryRepo;
        }

        /// <summary>
        /// Get all Registered products
        /// </summary>
        [HttpGet]
        [Route("GetProducts")]
        public IActionResult GetAll()
        {
            try
            {
                var products = _productsRepo.FindAll(x => x.DeletedAt == null);

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = SuccessMessageConstants.DefaultSuccess, Products = products });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        /// Get product based on product Id.
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Product found against id provided.</response>
        /// <response code="400">Product not found against id provided.</response>
        [HttpGet("GetProductById/{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var product = _productsRepo.FindBy(x => x.Id == id && x.DeletedAt == null);
                if (product == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, "Product") });

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = SuccessMessageConstants.DefaultSuccess, Product = product });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        /// Get product based on product AxCode.
        /// </summary>
        /// <param name="code"></param>
        /// <response code="200">Product found against AxCode provided.</response>
        /// <response code="500">Product not found against AxCode provided.</response>
        [HttpGet("GetProductByAx/{code}")]
        public IActionResult GetByAx(string code)
        {
            try
            {
                var product = _productsRepo.FindBy(x => x.AxCode == code && x.DeletedAt == null);
                if (product == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, "Product") });

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = SuccessMessageConstants.DefaultSuccess, Product = product });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        /// Add a new product
        /// </summary>
        /// <param name="productVM"></param>
        /// <response code="200">If new product added successfully</response>
        /// <response code="400">If  product exist with same name</response>
        [HttpPost]
        [Route("InsertProduct")]
        public IActionResult Post([FromBody] ProductViewModel productVM)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception();

                var category = _categoryRepo.FindBy(x => x.AxCode.ToLower() == productVM.CategoryAxCode.ToLower() && x.DeletedAt == null);
                if (category == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotValid, "Category AxCode") });

                if (_productsRepo.FindBy(x => x.Name.ToLower() == productVM.Name.ToLower() && x.DeletedAt == null) != null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.AlreadyExists, "Product") });

                var product = _mapper.Map<Product>(productVM);

                product.CategoryId = category.Id;
                product.Category = category;

                if (!string.IsNullOrWhiteSpace(productVM.ParentProductCode))
                {
                    var productExists = _productsRepo.FindBy(x => x.AxCode == productVM.ParentProductCode && x.DeletedAt == null);
                    if (productExists == null)
                        return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, "Base Product") });

                    product.ProductId = productExists.Id;
                }

                _productsRepo.Insert(product);

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = SuccessMessageConstants.DefaultSuccess, Product = product });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        /// Add multiple new products
        /// </summary>
        /// <param name="products"></param>
        [HttpPost]
        [Route("InsertMultipleProducts")]
        public IActionResult InsertMultipleProducts([FromBody] List<ProductViewModel> products)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception();

                List<object> responseMessages = new List<object>();
                var count = 0;
                foreach (var productVM in products)
                {
                    count++;

                    var category = _categoryRepo.FindBy(x => x.AxCode.ToLower() == productVM.CategoryAxCode.ToLower() && x.DeletedAt == null);
                    if (category == null)
                    {
                        responseMessages.Add(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotValid, "Category AxCode") });
                        continue;
                    }

                    if (_productsRepo.FindBy(x => x.Name.ToLower() == productVM.Name.ToLower() && x.DeletedAt == null) != null)
                    {
                        responseMessages.Add(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.AlreadyExists, "Product") });
                        continue;
                    }

                    var product = _mapper.Map<Product>(productVM);
                    product.CategoryId = category.Id;
                    product.Category = category;

                    if (!string.IsNullOrWhiteSpace(productVM.ParentProductCode))
                    {
                        var productExists = _productsRepo.FindBy(x => x.AxCode == productVM.ParentProductCode && x.DeletedAt == null);
                        if (productExists == null)
                        {
                            responseMessages.Add(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, "Base Product") });
                            continue;
                        }
                        product.ProductId = productExists.Id;
                    }

                    if (_productsRepo.Insert(product))
                    {
                        responseMessages.Add(new { RecordNumber = count, Status = ApiStatus.Success, Message = string.Format(SuccessMessageConstants.CreateSuccess, "Product") });
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
        /// Update a product.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productVM"></param>
        /// <response code="200">If product updated successfully</response>
        /// <response code="400">If product already exist with same name</response>
        [HttpPut("UpdateProduct/{id}")]
        public IActionResult Put(Guid id, [FromBody] ProductViewModel productVM)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception();

                if (_productsRepo.FindBy(x => x.Id == id && x.DeletedAt == null) == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, "Product") });

                var category = _categoryRepo.FindBy(x => x.AxCode.ToLower() == productVM.CategoryAxCode.ToLower() && x.DeletedAt == null);
                if (category == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotValid, "Category AxCode") });

                if (_productsRepo.FindBy(x => x.Name.ToLower() == productVM.Name.ToLower() && x.DeletedAt == null) != null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.AlreadyExists, "Product") });

                var product = _productsRepo.Get(id);

                product.Name = productVM.Name;
                product.Description = productVM.Description;
                product.CategoryId = category.Id;
                if (!string.IsNullOrWhiteSpace(productVM.ParentProductCode))
                {
                    var productExists = _productsRepo.FindBy(x => x.AxCode == productVM.ParentProductCode && x.DeletedAt == null);
                    if (productExists == null)
                        return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, "Base Product") });

                    product.ProductId = productExists.Id;
                }

                _productsRepo.Update(product);

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = string.Format(SuccessMessageConstants.UpdateSuccess, product.Name) });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        /// Update a product based on AxCode.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="productVM"></param>
        /// <response code="200">If product updated successfully</response>
        /// <response code="400">If product already exist with same name</response>
        [HttpPut("UpdateProductByAxCode/{code}")]
        public IActionResult PutByAxCode(string code, [FromBody] ProductViewModel productVM)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception();

                var product = _productsRepo.FindBy(x => x.AxCode == code && x.DeletedAt == null);
                if (product == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, "Product") });

                var category = _categoryRepo.FindBy(x => x.AxCode.ToLower() == productVM.CategoryAxCode.ToLower() && x.DeletedAt == null);
                if (category == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotValid, "Category AxCode") });

                if (_productsRepo.FindBy(x => x.Name.ToLower() == productVM.Name.ToLower() && x.DeletedAt == null) != null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.AlreadyExists, "Product") });

                product.Name = productVM.Name;
                product.Description = productVM.Description;
                product.CategoryId = category.Id;
                if (!string.IsNullOrWhiteSpace(productVM.ParentProductCode))
                {
                    var productExists = _productsRepo.FindBy(x => x.AxCode == productVM.ParentProductCode && x.DeletedAt == null);
                    if (productExists == null)
                        return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, "Base Product") });

                    product.ProductId = productExists.Id;
                }

                _productsRepo.Update(product);

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = string.Format(SuccessMessageConstants.UpdateSuccess, product.Name) });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        ///  Delete product based on product Id.
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">If product deleted successfully</response>
        /// <response code="400">If product not found against id provided.</response>
        [HttpDelete("DeleteProductById/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var product = _productsRepo.FindBy(x => x.Id == id && x.DeletedAt == null);
                if (product == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotValid, "Product Id") });

                var productPriceHistory = _priceHistoryRepo.FindAll(x => x.DeletedAt == null).Where(x => x.ProductId == product.Id).ToList();

                foreach (var history in productPriceHistory)
                {
                    history.DeletedAt = DateTime.Now;
                    _priceHistoryRepo.Update(history);
                }

                var varients = _productsRepo.FindAll(x => x.DeletedAt == null).Where(x => x.ProductId == product.Id).ToList();
                foreach (var varient in varients)
                {
                    var varientPriceHistory = _priceHistoryRepo.GetAll().Where(x => x.ProductId == varient.Id).ToList();

                    foreach (var history in varientPriceHistory)
                    {
                        history.DeletedAt = DateTime.Now;
                        _priceHistoryRepo.Update(history);
                    }

                    varient.DeletedAt = DateTime.Now;
                    _productsRepo.Update(varient);
                }

                product.DeletedAt = DateTime.Now;
                _productsRepo.Update(product);

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = string.Format(SuccessMessageConstants.DeleteSuccess, product.Name) });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        /// Delete product based on product AxCode.
        /// </summary>
        /// <param name="code"></param>
        /// <response code="200">If product deleted successfully</response>
        /// <response code="400">If product not found against AxCode provided.</response>

        [HttpDelete("DeleteProductByAxCode/{code}")]
        public IActionResult DeleteByAx(string code)
        {
            try
            {
                var product = _productsRepo.FindBy(x => x.AxCode == code && x.DeletedAt == null);
                if (product == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotValid, "AxCode") });

                var productPriceHistory = _priceHistoryRepo.FindAll(x => x.DeletedAt == null).Where(x => x.ProductId == product.Id).ToList();

                foreach (var history in productPriceHistory)
                {
                    history.DeletedAt = DateTime.Now;
                    _priceHistoryRepo.Update(history);
                }

                var varients = _productsRepo.FindAll(x => x.DeletedAt == null).Where(x => x.ProductId == product.Id).ToList();
                foreach (var varient in varients)
                {
                    var varientPriceHistory = _priceHistoryRepo.GetAll().Where(x => x.ProductId == varient.Id).ToList();

                    foreach (var history in varientPriceHistory)
                    {
                        history.DeletedAt = DateTime.Now;
                        _priceHistoryRepo.Update(history);
                    }

                    varient.DeletedAt = DateTime.Now;
                    _productsRepo.Update(varient);
                }

                product.DeletedAt = DateTime.Now;
                _productsRepo.Update(product);

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = string.Format(SuccessMessageConstants.DeleteSuccess, product.Name) });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        /// Insert product in Base64 String format.
        /// </summary>
        /// <remarks>
        /// Sample Code:
        /// 
        ///     byte[] imageArray = System.IO.File.ReadAllBytes(@"image file path");
        ///     string ImageString = Convert.ToBase64String(imageArray);
        ///     
        /// </remarks>
        /// <param name="viewModel"></param>
        /// <response code="200">If product deleted successfully</response>
        /// <response code="400">If product not found against AxCode provided.</response>
        [HttpPost]
        [Route("InsertProductImage")]
        public IActionResult UploadProductImage(ImageViewModel viewModel)
        {
            try
            {
                if (!IsBase64String(viewModel.ImageString))
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotValid, "Image") });

                var product = _productsRepo.FindBy(x => x.AxCode == viewModel.AxCode && x.DeletedAt == null);
                if (product == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, "Product Ax Code") });

                var image = Convert.FromBase64String(viewModel.ImageString);
                ResourceFile productImage = new ResourceFile()
                {
                    File = image,
                    Name = "pi_" + product.Id.ToString() + GetFileExtension(viewModel.ImageString),
                    MimeType = "Image"
                };

                _filesRepo.Insert(productImage);
                product.ImageId = productImage.Id;
                _productsRepo.Update(product);
                return Ok(new { Status = ApiStatus.Success.ToString(), Message = string.Format(SuccessMessageConstants.UpdateSuccess, "Product Image") });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        [NonAction]
        public string GetFileExtension(string base64String)
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
        public bool IsBase64String(string base64)
        {
            Span<byte> buffer = new Span<byte>(new byte[base64.Length]);
            return Convert.TryFromBase64String(base64, buffer, out int bytesParsed);
        }
    }
}
