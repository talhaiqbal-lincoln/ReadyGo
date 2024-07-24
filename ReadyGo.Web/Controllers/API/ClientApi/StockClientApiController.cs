using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadyGo.Domain.Constants;
using ReadyGo.Domain.Entities;
using ReadyGo.Domain.Entities.ApiModels;
using ReadyGo.Domain.Entities.ViewModels;
using ReadyGo.Domain.Enum;
using ReadyGo.Service.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyGo.Web.Controllers.API.ClientApi
{
    // [ApiKey]
    [ApiController]
    [ApiVersion("2.0")]
    [ApiExplorerSettings(GroupName = "client")]
    [Route("api/v{version:apiVersion}/Stock/")]
    public class StockClientApiController : ControllerBase
    {
        private readonly IGenericRepository<AssignStock> _assignRepo;
        private readonly IGenericRepository<Vehicle> _vehicleRepo;
        private readonly IGenericRepository<TransferStock> _tranferStockRepo;
        private readonly IGenericRepository<Route> _routeRepo;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IMapper _mapper;

        public StockClientApiController(IGenericRepository<Vehicle> vehicleRepo,
                                     IGenericRepository<AssignStock> assignRepo,
                                     IGenericRepository<Product> productRepo,
                                    IGenericRepository<TransferStock> tranferStockRepo,
                                    IGenericRepository<Route> routeRepo,
                                     IMapper mapper)
        {
            _assignRepo = assignRepo;
            _vehicleRepo = vehicleRepo;
            _tranferStockRepo = tranferStockRepo;
            _routeRepo = routeRepo;
            _productRepo = productRepo;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all Transfer Stocks
        /// </summary>
        /// <returns>Transfer Stocks</returns>
        [HttpGet]
        [Route("GetStock")]
        public IActionResult GetAll()
        {
            try
            {
                var transferStock = _tranferStockRepo.FindAll(x => x.DeletedAt == null).Include(x => x.AssignStocks);

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = SuccessMessageConstants.DefaultSuccess, TransferStock = transferStock });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        ///   Get Tranfer Stock based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Transfer stock if id is valid </returns>
        /// <response code="200">Transfer stock against id provided.</response>
        /// <response code="400">Transfer stock not found against id provided.</response>
        [HttpGet("GetTransferStockById/{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var transferStock = _tranferStockRepo.FindBy(x => x.Id == id && x.DeletedAt == null);

                if (transferStock == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, "Transfer Stock") });

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = SuccessMessageConstants.DefaultSuccess, TransferStock = transferStock });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        ///   Get Tranfer Stock based on sale person Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Transfer stock if id is valid </returns>
        /// <response code="200">Transfer stock found against id provided.</response>
        /// <response code="400">Transfer stock not found against id provided.</response>

        [HttpGet("GetTransferStockBySpId/{id}")]
        public IActionResult GetBySpId(string id)
        {
            try
            {
                var transferStock = _tranferStockRepo.FindAll(x => x.DeletedAt == null)
                                    .Include(x => x.Route).ThenInclude(x => x.SalesPersons).ThenInclude(x => x.SalesPerson)
                                    .Include(x => x.Vehicle)
                                    .Include(x => x.CreatedBy)
                                    .Include(x => x.AssignStocks)
                                    .Where(x => x.Route.SalesPersons.Any(x => x.SalesPersonId == id))
                                    .FirstOrDefault();

                if (transferStock == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, "Transfer Stock") });

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = SuccessMessageConstants.DefaultSuccess, TransferStock = transferStock });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        ///   Get Tranfer Stock based on sale person AxCode.
        /// </summary>
        /// <param name="axCode"></param>
        /// <returns>Transfer stock if AxCode is valid </returns>
        /// <response code="200">Transfer stock found against AxCode provided.</response>
        /// <response code="400">Transfer stock not found against AxCode provided.</response>
        [HttpGet("GetTransferStockBySpAxCode/{axCode}")]
        public IActionResult GetBySpAxCode(string axCode)
        {
            try
            {
                var transferStock = _tranferStockRepo.FindAll(x => x.DeletedAt == null)
                                    .Include(x => x.Route).ThenInclude(x => x.SalesPersons).ThenInclude(x => x.SalesPerson)
                                    .Include(x => x.Vehicle)
                                    .Include(x => x.CreatedBy)
                                    .Include(x => x.AssignStocks)
                                    .Where(x => x.Route.SalesPersons.Any(x => x.SalesPerson.AxCode == axCode))
                                    .FirstOrDefault();

                if (transferStock == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, "Transfer Stock") });

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = SuccessMessageConstants.DefaultSuccess, TransferStock = transferStock });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        /// Post: Add a new transfer stock
        /// </summary>
        /// <param name="transferStockVM"></param>
        /// <returns> Message based on valid Transfer Stock</returns>
        /// <response code="200">If new Transfer stock added successfully</response>
        /// <response code="400">If Transfer stock exist with same name</response>
        [HttpPost]
        [Route("InsertTransferStock")]
        public IActionResult Post([FromBody] AssignStockApiViewModel transferStockVM)
        {
            List<AssignStock> savedAssignStocks = new List<AssignStock>();
            try
            {
                var existingRoute = _routeRepo.FindBy(x => x.AxCode == transferStockVM.RouteAxCode && x.DeletedAt == null);
                if(existingRoute == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotValid, "Route AxCode") });

                var existingVehicle = _vehicleRepo.FindBy(x => x.AXCode == transferStockVM.VehicleAxCode && x.DeletedAt == null);
                if (existingVehicle == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotValid, "Vehicle AxCode") });

                var existingStock = _tranferStockRepo.FindAll(x => x.RouteId == existingRoute.Id && x.CreatedAt == DateTime.Now.Date).FirstOrDefault();
                if (existingStock == null)
                {
                    var routeId = existingRoute.Id;
                    var vehicleId = existingVehicle.Id;

                    TransferStock transferStock = new TransferStock();
                    transferStock = _mapper.Map<TransferStock>(transferStockVM);

                    transferStock.CreatedAt = DateTime.Now.Date;
                    transferStock.Status = true;
                    transferStock.CreatedById = AppConstants.AdminUser;
                    transferStock.RouteId = existingRoute.Id;
                    transferStock.VehicleId = existingVehicle.Id;

                    var saved = _tranferStockRepo.Insert(transferStock);
                    if(saved)
                    {
                        foreach (var stock in transferStockVM.AssignStocks)
                        {
                            var existingProduct = _productRepo.FindBy(x => x.AxCode == stock.ProductAxCode && x.DeletedAt == null);
                            if (existingProduct == null)
                            {
                                RollBackSavedChanges(transferStock, savedAssignStocks);
                                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotValid, "Product AxCode") });
                            }

                            var existingAssignStock = _assignRepo.FindBy(x => x.AXCode == stock.AssignStockAXCode && x.DeletedAt == null && x.TransferId == transferStock.Id);
                            if (existingAssignStock != null)
                            {
                                RollBackSavedChanges(transferStock, savedAssignStocks);
                                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.AlreadyExists, "Assign Stock with same AxCode") });
                            }

                            var assignStock = new AssignStock
                            {
                                ProductId = (Guid)existingProduct.Id,
                                Quantity = stock.ProductQuantity,
                                AXCode = stock.AssignStockAXCode,
                                TransferId = transferStock.Id
                            };
                            _assignRepo.Insert(assignStock);

                            savedAssignStocks.Add(assignStock);
                        }

                        return Ok(new { Status = ApiStatus.Success.ToString(), Message = SuccessMessageConstants.DefaultSuccess, TransferStock = transferStock });
                    }
                    else
                    {
                        RollBackSavedChanges(transferStock, savedAssignStocks);
                        return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
                    }
                }
                else
                {
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.StockAssigned });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        /// Insert multiple Transfer stocks
        /// </summary>
        [HttpPost]
        [Route("InsertMultipleStocks")]
        [ProducesResponseType(typeof(AssignStockViewModel), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [Produces("application/json", "application/xml")]
        public IActionResult InsertMultipleStocks([FromBody] IEnumerable<AssignStockApiViewModel> transferStocks)
        {
            try
            {

                List<AssignStock> savedAssignStocks;
                if (!ModelState.IsValid)
                    throw new Exception();

                List<object> responseMessages = new List<object>();
                var count = 0;
                foreach (var transferStockVM in transferStocks)
                {
                    savedAssignStocks = new List<AssignStock>();
                    count++;

                    var existingRoute = _routeRepo.FindBy(x => x.AxCode == transferStockVM.RouteAxCode && x.DeletedAt == null);
                    if (existingRoute == null)
                        return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotValid, "Route AxCode") });

                    var existingVehicle = _vehicleRepo.FindBy(x => x.AXCode == transferStockVM.VehicleAxCode && x.DeletedAt == null);
                    if (existingVehicle == null)
                        return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotValid, "Vehicle AxCode") });

                    var existingStock = _tranferStockRepo.FindBy(x => x.RouteId == existingRoute.Id && x.CreatedAt == DateTime.Now.Date);
                    if (existingStock == null)
                    {
                        var routeId = existingRoute.Id;
                        var vehicleId = existingRoute.Id;

                        TransferStock transferStock = new TransferStock();
                        transferStock = _mapper.Map<TransferStock>(transferStockVM);
                        transferStock.CreatedById = AppConstants.AdminUser;
                        transferStock.CreatedAt = DateTime.Now.Date;
                        transferStock.RouteId = existingRoute.Id;
                        transferStock.VehicleId = existingVehicle.Id;
                        _tranferStockRepo.Insert(transferStock);
                        foreach (var stock in transferStockVM.AssignStocks)
                        {
                            var existingProduct = _productRepo.FindBy(x => x.AxCode == stock.ProductAxCode && x.DeletedAt == null);
                            if (existingProduct == null)
                            {
                                responseMessages.Add(new { RecordNumber = count, Status = ApiStatus.Error, Message = string.Format(ErrorMessageConstants.NotValid, "Product AxCode") });
                                RollBackSavedChanges(transferStock, savedAssignStocks);
                            }

                            var existingAssignStock = _assignRepo.FindBy(x => x.AXCode == stock.AssignStockAXCode && x.DeletedAt == null && x.TransferId == transferStock.Id);
                            if (existingAssignStock != null)
                            {
                                RollBackSavedChanges(transferStock, savedAssignStocks);
                                responseMessages.Add(new { RecordNumber = count, Status = ApiStatus.Error, Message = string.Format(ErrorMessageConstants.AlreadyExists, "Assign Stock AxCode") });
                            }

                            var assignStock = new AssignStock
                            {
                                ProductId = (Guid)existingProduct.Id,
                                Quantity = stock.ProductQuantity,
                                AXCode = stock.AssignStockAXCode,
                                TransferId = transferStock.Id
                            };
                            _assignRepo.Insert(assignStock);

                            savedAssignStocks.Add(assignStock);
                        }

                        responseMessages.Add(new { RecordNumber = count, Status = ApiStatus.Success, Message = string.Format(SuccessMessageConstants.DefaultSuccess), TransferStock = transferStock });
                        continue;
                    }
                    else
                    {
                        responseMessages.Add(new { RecordNumber = count, Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.StockAssigned) });
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

        /// <summary>
        /// Update a transfer stock.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="transferStockVm"></param>
        /// <returns> Message based on valid updated transfer stock</returns>
        /// <response code="200">If transfer stock updated successfully</response>
        /// <response code="400">If transfer stock already exist with same name</response>
        [HttpPut("UpdateTransferStock/{id}")]
        public IActionResult Put(Guid id, [FromBody] AssignStockApiViewModel transferStockVm)
        {
            try
            {
                List<AssignStock> savedAssignStocks = new List<AssignStock>();

                var existingRoute = _routeRepo.FindBy(x => x.AxCode == transferStockVm.RouteAxCode && x.DeletedAt == null);
                if (existingRoute == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotValid, "Route AxCode") });

                var existingVehicle = _vehicleRepo.FindBy(x => x.AXCode == transferStockVm.VehicleAxCode && x.DeletedAt == null);
                if (existingVehicle == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotValid, "Vehicle AxCode") });

                var transferStock = _tranferStockRepo.FindBy(x => x.Id == id);
                if (transferStock == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotValid, "Transfer Stock Id") });

                var spAlreadyAssigned = _tranferStockRepo.FindAll(x => x.RouteId == existingRoute.Id && x.Id != transferStock.Id && x.CreatedAt == DateTime.Today).FirstOrDefault();
                if (spAlreadyAssigned == null)
                {
                    transferStock.RouteId = existingRoute.Id;
                    transferStock.VehicleId = existingVehicle.Id;
                    transferStock.DriverName = transferStockVm.DriverName;

                    _tranferStockRepo.Update(transferStock);

                    var existingStocks = _assignRepo.FindAll(x => x.TransferId == transferStockVm.Id).ToList();
                    _assignRepo.DeleteRange(existingStocks);

                    foreach (var stock in transferStockVm.AssignStocks)
                    {
                        var existingProduct = _productRepo.FindBy(x => x.AxCode == stock.ProductAxCode && x.DeletedAt == null);
                        if (existingProduct == null)
                        {
                            RollBackSavedChanges(transferStock, savedAssignStocks);
                            return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotValid, "Product AxCode") });
                        }

                        var existingAssignStock = _assignRepo.FindBy(x => x.AXCode == stock.AssignStockAXCode && x.DeletedAt == null && x.TransferId == transferStock.Id);
                        if (existingAssignStock != null)
                        {
                            RollBackSavedChanges(transferStock, savedAssignStocks);
                            return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.AlreadyExists, "Assign Stock with same AxCode") });
                        }

                        var assignStock = new AssignStock
                        {
                            ProductId = (Guid)existingProduct.Id,
                            Quantity = stock.ProductQuantity,
                            AXCode = stock.AssignStockAXCode,
                            TransferId = transferStock.Id
                        };
                        _assignRepo.Update(assignStock);
                        savedAssignStocks.Add(assignStock);
                    }

                    return Ok(new { Status = ApiStatus.Success.ToString(), Message = SuccessMessageConstants.DefaultSuccess, TransferStock = transferStock });
                }
                else
                {
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.StockAssigned });
                }
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        ///   Delete Transfer Stock based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">If Transfer stock deleted successfully</response>
        /// <response code="400">If Transfer stock not found against id provided.</response>
        [HttpDelete("DeleteTransferStockById/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var transferStock = _tranferStockRepo.FindBy(x => x.Id == id);
                if (transferStock == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotValid, "Transfer Stock") });

                var assignedStocks = await _assignRepo.FindAll(x => x.TransferId == transferStock.Id).ToListAsync();

                foreach (var stock in assignedStocks)
                {
                    stock.DeletedAt = DateTime.Now;
                    _assignRepo.Update(stock);
                }

                transferStock.DeletedAt = DateTime.Now;
                _tranferStockRepo.Update(transferStock);

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = string.Format(SuccessMessageConstants.DeleteSuccess, "Transfer Stock") });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        ///// <summary>
        /////   Delete Transfer Stock based on code.
        ///// </summary>
        ///// <param name="code"></param>
        ///// <returns></returns>
        ///// <response code="200">If Transfer stock deleted successfully</response>
        ///// <response code="400">If Transfer stock not found against code provided.</response>
        //[HttpDelete("DeleteTransferStockByAx/{code}")]
        //public async Task<IActionResult> DeleteByAx(string code)
        //{
        //    try
        //    {
        //        var transferStock = _tranferStockRepo.FindBy(x => x.AXCode == code);
        //        if (transferStock == null)
        //            return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotValid, "Transfer Stock") });

        //        var assignedStocks = await _assignRepo.FindAll(x => x.TransferId == transferStock.Id).ToListAsync();

        //        foreach (var stock in assignedStocks)
        //        {
        //            stock.DeletedAt = DateTime.Now;
        //            _assignRepo.Update(stock);
        //        }

        //        transferStock.DeletedAt = DateTime.Now;
        //        _tranferStockRepo.Update(transferStock);

        //        return Ok(new { Status = ApiStatus.Success.ToString(), Message = string.Format(SuccessMessageConstants.DeleteSuccess, "Transfer Stock") });
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
        //    }
        //}

        private void RollBackSavedChanges(TransferStock transferStock, List<AssignStock> assignStocks)
        {
            _tranferStockRepo.Delete(transferStock);

            foreach (var assignStock in assignStocks)
            {
                _assignRepo.Delete(assignStock);
            }
        }
    }
}
