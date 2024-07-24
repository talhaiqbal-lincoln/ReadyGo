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
    [Route("api/v{version:apiVersion}/Category/")]
    [SwaggerTag("Create, Read, Update and Delete Categories based on Category Id Or AxCode")]
    public class CategoryApiController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Category> _categoryRepo;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<PriceHistory> _priceHistoryRepo;

        public CategoryApiController(IGenericRepository<Category> categoryRepo, IGenericRepository<Product> productRepo, IGenericRepository<PriceHistory> priceHistoryRepo, IMapper mapper)
        {
            _mapper = mapper;
            _categoryRepo = categoryRepo;
            _productRepo = productRepo;
            _priceHistoryRepo = priceHistoryRepo;
        }

        /// <summary>
        /// Get all Categories
        /// </summary>
        [HttpGet]
        [Route("GetCategories")]
        public IActionResult GetAll()
        {
            try
            {
                var categories = _categoryRepo.FindAll(x => x.DeletedAt == null);

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = SuccessMessageConstants.DefaultSuccess, Categories = categories });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        /// Get Category based on Category Id.
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Category found against id provided.</response>
        /// <response code="400">Category not found against id provided.</response>
        [HttpGet("GetCategoryById/{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var category = _categoryRepo.FindBy(x => x.Id == id && x.DeletedAt == null);
                if (category == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, "Category") });

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = SuccessMessageConstants.DefaultSuccess, Category = category });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        /// Get Category based on Category AxCode.
        /// </summary>
        /// <param name="code"></param>
        /// <response code="200">Category found against id provided.</response>
        /// <response code="400">Category not found against id provided.</response>
        [HttpGet("GetCategoryByAxCode/{code}")]
        public IActionResult GetByAxCode(string code)
        {
            try
            {
                var category = _categoryRepo.FindBy(x => x.AxCode == code && x.DeletedAt == null);
                if (category == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, "Category") });

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = SuccessMessageConstants.DefaultSuccess, Category = category });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        /// Add a new category
        /// </summary>
        /// <param name="categoryVM"></param>
        /// <response code="200">If new category added successfully</response>
        /// <response code="400">If  category exist with same name</response>
        [HttpPost]
        [Route("InsertCategory")]
        public IActionResult Post([FromBody] CategoryViewModel categoryVM)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception();

                if (string.IsNullOrWhiteSpace(categoryVM.AxCode))
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.Required, "Category AxCode") });

                if (_categoryRepo.FindBy(x => x.AxCode.ToLower() == categoryVM.AxCode.ToLower() && x.DeletedAt == null) != null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.AlreadyExists, "Category AxCode") });

                if (_categoryRepo.FindBy(x => x.Name.ToLower() == categoryVM.Name.ToLower() && x.DeletedAt == null) != null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.AlreadyExists, "Category Name") });


                var category = _mapper.Map<Category>(categoryVM);

                var lastPosition = _categoryRepo.FindAll(x => x.DeletedAt == null).OrderByDescending(x => x.Position).FirstOrDefault()?.Position;
                if (lastPosition == null)
                    lastPosition = 0;

                category.Position = (int)(lastPosition + 1);

                category.SyncedAt = DateTime.Now;
                _categoryRepo.Insert(category);

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = SuccessMessageConstants.DefaultSuccess, Category = category });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        /// Insert multiple categories
        /// </summary>
        [HttpPost]
        [Route("InsertMultipleCategories")]
        [ProducesResponseType(typeof(CategoryViewModel), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Produces("application/json", "application/xml")]
        public IActionResult InsertMultipleCategories([FromBody] IEnumerable<CategoryViewModel> categories)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception();

                List<object> responseMessages = new List<object>();
                var count = 0;
                foreach (var category in categories)
                {
                    count++;

                    if (string.IsNullOrWhiteSpace(category.AxCode))
                    {
                        responseMessages.Add(new { RecordNumber = count, Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.Required, "Category AxCode") });
                        continue;
                    }

                    var existingAxCode = _categoryRepo.FindBy(x => (x.AxCode.ToLower() == category.AxCode.ToLower()) && x.DeletedAt == null);
                    if (existingAxCode != null)
                    {
                        responseMessages.Add(new { RecordNumber = count, Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.AlreadyExists, "Category AxCode") });
                        continue;
                    }

                    var existingCategoryName = _categoryRepo.FindBy(x => (x.Name.ToLower() == category.Name.ToLower()) && x.DeletedAt == null);
                    if (existingCategoryName != null)
                    {
                        responseMessages.Add(new { RecordNumber = count, Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.AlreadyExists, "Category Name") });
                        continue;
                    }

                    var newCategory = _mapper.Map<Category>(category);
                    newCategory.SyncedAt = DateTime.Now;

                    if (_categoryRepo.Insert(newCategory))
                    {
                        responseMessages.Add(new { RecordNumber = count, Status = ApiStatus.Success, Message = string.Format(SuccessMessageConstants.CreateSuccess, category.Name) });
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
        /// Update a category based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="categoryVM"></param>
        /// <response code="200">If category updated successfully</response>
        /// <response code="400">If category already exist with same name</response>
        [HttpPut("UpdateCategoryById/{id}")]
        public IActionResult Put(Guid id, [FromBody] CategoryViewModel categoryVM)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception();

                var category = _categoryRepo.FindBy(x => x.Id == id && x.DeletedAt == null);
                if (category == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, "Category") });

                if (_categoryRepo.FindBy(x => x.AxCode.ToLower() == categoryVM.AxCode.ToLower() && x.Id != id && x.DeletedAt == null) != null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.AlreadyExists, "Category AxCode") });

                if (_categoryRepo.FindBy(x => x.Name.ToLower() == categoryVM.Name.ToLower() && x.Id != id && x.DeletedAt == null) != null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.AlreadyExists, "Category Name") });

                category.Name = categoryVM.Name;
                category.AxCode = categoryVM.AxCode;
                category.SyncedAt = DateTime.Now;

                _categoryRepo.Update(category);

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = string.Format(SuccessMessageConstants.UpdateSuccess, category.Name), Category = category });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        /// Update a category based on AxCode.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="categoryVM"></param>
        /// <response code="200">If category updated successfully</response>
        /// <response code="400">If category already exist with same name</response>
        [HttpPut("UpdateCategoryByAxCode/{code}")]
        public IActionResult PutByAxCode(string code, [FromBody] CategoryViewModel categoryVM)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception();

                var category = _categoryRepo.FindBy(x => x.AxCode == code && x.DeletedAt == null);
                if (category == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, "Category") });

                if (_categoryRepo.FindBy(x => x.AxCode.ToLower() == categoryVM.AxCode.ToLower() && x.Id != category.Id && x.DeletedAt == null) != null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.AlreadyExists, "Category AxCode") });

                if (_categoryRepo.FindBy(x => x.Name.ToLower() == categoryVM.Name.ToLower() && x.Id != category.Id && x.DeletedAt == null) != null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.AlreadyExists, "Category Name") });

                category.Name = categoryVM.Name;
                category.AxCode = categoryVM.AxCode;
                category.SyncedAt = DateTime.Now;

                _categoryRepo.Update(category);

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = string.Format(SuccessMessageConstants.UpdateSuccess, category.Name), Category = category });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        ///   Delete category based on category Id.
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">If category deleted successfully</response>
        /// <response code="400">If category not found against id provided.</response>
        [HttpDelete("DeleteCategoryById/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var category = _categoryRepo.FindBy(x => x.Id == id && x.DeletedAt == null);

                if (category == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, "Category") });

                var existingProducts = _productRepo.FindAll(x => x.CategoryId == category.Id && x.DeletedAt == null).ToList();
                foreach (var product in existingProducts)
                {
                    var existingPriceHistories = _priceHistoryRepo.FindAll(x => x.ProductId == product.Id).ToList();
                    foreach (var history in existingPriceHistories)
                    {
                        history.DeletedAt = DateTime.Now;
                        _priceHistoryRepo.Update(history);
                    }

                    product.DeletedAt = DateTime.Now;
                    _productRepo.Update(product);
                }

                category.DeletedAt = DateTime.Now;
                _categoryRepo.Update(category);

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = string.Format(SuccessMessageConstants.DeleteSuccess, category.Name) });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        ///   Delete category based on category Ax Code.
        /// </summary>
        /// <param name="code"></param>
        /// <response code="200">If category deleted successfully</response>
        /// <response code="400">If category not found against id provided.</response>
        [HttpDelete("DeleteCategoryByAxCode/{code}")]
        public IActionResult DeleteByAxCode(string code)
        {
            try
            {
                var category = _categoryRepo.FindBy(x => x.AxCode == code && x.DeletedAt == null);
                if (category == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, "Category") });

                var existingProducts = _productRepo.FindAll(x => x.CategoryId == category.Id && x.DeletedAt == null).ToList();
                foreach (var product in existingProducts)
                {
                    var existingPriceHistories = _priceHistoryRepo.FindAll(x => x.ProductId == product.Id).ToList();
                    foreach (var history in existingPriceHistories)
                    {
                        history.DeletedAt = DateTime.Now;
                        _priceHistoryRepo.Update(history);
                    }

                    product.DeletedAt = DateTime.Now;
                    _productRepo.Update(product);
                }

                category.DeletedAt = DateTime.Now;
                _categoryRepo.Update(category);

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = string.Format(SuccessMessageConstants.DeleteSuccess, category.Name) });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }
    }
}
