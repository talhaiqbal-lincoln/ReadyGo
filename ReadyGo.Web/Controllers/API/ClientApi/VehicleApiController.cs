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
    [ApiController]
    [ApiVersion("2.0")]
    [ApiExplorerSettings(GroupName = "client")]
    [Route("api/v{version:apiVersion}/Vehicle/")]
    [SwaggerTag("Create, Read, Update and Delete Vehicles based on Vehicle Id Or AxCode")]
    public class VehicleApiController : ControllerBase
    {
        #region Properties

        private readonly IMapper _mapper;
        private readonly IGenericRepository<Vehicle> _vehicleRepo;

        #endregion Properties

        #region Constructor

        public VehicleApiController(IGenericRepository<Vehicle> vehicleRepo, IMapper mapper)
        {
            _mapper = mapper;
            _vehicleRepo = vehicleRepo;
        }

        #endregion Constructor

        #region Action Methods

        /// <summary>
        /// Get all Registered Vehicles
        /// </summary>
        /// <returns>Vehicles</returns>
        [HttpGet]
        [Route("GetVehicles")]
        public IActionResult GetAll()
        {
            try
            {
                var vehicles = _vehicleRepo.FindAll(x => x.DeletedAt == null);

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = SuccessMessageConstants.DefaultSuccess, Vehicles = vehicles });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        ///   Get Registered Vehicle based on Vehicle Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Vehicle if id is valid </returns>
        /// <response code="200">Vehicle found against id provided.</response>
        /// <response code="400">Vehicle not found against id provided.</response>
        [HttpGet("GetVehicleById/{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var vehicle = _vehicleRepo.FindBy(x => x.Id == id && x.DeletedAt == null);
                if (vehicle == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, "Vehicle") });

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = SuccessMessageConstants.DefaultSuccess, Vehicle = vehicle });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        ///   Get Registered Vehicle based on Vehicle AxCode.
        /// </summary>
        /// <param name="axCode"></param>
        /// <returns>Vehicle if AxCode is valid </returns>
        /// <response code="200">Vehicle found against AxCode provided.</response>
        /// <response code="400">Vehicle not found against AxCode provided.</response>
        [HttpGet("GetVehicleByAxCode/{axCode}")]
        public IActionResult GetByAxCode(string axCode)
        {
            try
            {
                var vehicle = _vehicleRepo.FindBy(x => x.AXCode == axCode && x.DeletedAt == null);
                if (vehicle == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, "Vehicle") });

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = SuccessMessageConstants.DefaultSuccess, Vehicle = vehicle });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        ///  Register a new Vehicle
        /// </summary>
        /// <param name="vehicleVM"></param>
        /// <response code="200">If new Vehicle added successfully</response>
        /// <response code="400">If  Vehicle exist with same name</response>
        [HttpPost]
        [Route("InsertVehicle")]
        public IActionResult Post([FromBody] VehicleViewModel vehicleVM)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception();

                if (_vehicleRepo.FindBy(x => x.VehicleNumber.ToLower() == vehicleVM.VehicleNumber.ToLower()) != null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.AlreadyExists, "Vehicle " + vehicleVM.VehicleNumber) });

                var vehicle = _mapper.Map<Vehicle>(vehicleVM);
                _vehicleRepo.Insert(vehicle);

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = string.Format(SuccessMessageConstants.CreateSuccess, "Vehicle"), Vehicle = vehicle });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        /// Register multiple vehicles at a time
        /// </summary>
        [HttpPost]
        [Route("InsertMultipleVehicles")]
        [ProducesResponseType(typeof(VehicleViewModel), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult InsertMultipleVehicles([FromBody] IEnumerable<VehicleViewModel> vehicles)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception();

                List<object> responseMessages = new List<object>();
                var count = 0;
                foreach (var vehicle in vehicles)
                {
                    count++;
                    var existingVehicle = _vehicleRepo.FindBy(x => (x.VehicleNumber.ToLower() == vehicle.VehicleNumber.ToLower()) && x.DeletedAt == null);
                    if (existingVehicle != null)
                    {
                        responseMessages.Add(new { RecordNumber = count, Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.AlreadyExists, "Vehicle " + vehicle.VehicleNumber) });
                        continue;
                    }

                    var newVehicle = _mapper.Map<Vehicle>(vehicle);

                    if (_vehicleRepo.Insert(newVehicle))
                    {
                        responseMessages.Add(new { RecordNumber = count, Status = ApiStatus.Success, Message = string.Format(SuccessMessageConstants.CreateSuccess, "Vehicle") });
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

        /// <summary>
        /// Update existing Registered Vehicle.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="vehicleVM"></param>
        /// <response code="200">If Vehicle updated successfully</response>
        /// <response code="400">If Vehicle already exist with same name</response>
        [HttpPut("UpdateVehicle/{id}")]
        public IActionResult Put(Guid id, [FromBody] VehicleViewModel vehicleVM)
        {
            try
            {
                var vehicle = _vehicleRepo.FindBy(x => x.Id == id && x.DeletedAt == null);
                if (vehicle == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, "Vehicle") });

                if (_vehicleRepo.FindBy(x => x.VehicleNumber.ToLower() == vehicleVM.VehicleNumber.ToLower() && x.DeletedAt == null) != null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.AlreadyExists, "Vehicle " + vehicleVM.VehicleNumber) });

                vehicle.VehicleNumber = vehicleVM.VehicleNumber;
                vehicle.DriverName = vehicleVM.DriverName;
                vehicle.Model = vehicleVM.Model;
                vehicle.Type = vehicleVM.Type;

                _vehicleRepo.Update(vehicle);

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = string.Format(SuccessMessageConstants.UpdateSuccess, "Vehicle " + vehicleVM.VehicleNumber), Vehicle = vehicle });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        ///   Delete Vehicle based on Vehicle Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">If Vehicle deleted successfully</response>
        /// <response code="400">If Vehicle not found against id provided.</response>
        [HttpDelete("DeleteVehicleById/{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var vehicle = _vehicleRepo.FindBy(x => x.Id == id && x.DeletedAt == null);
                if (vehicle == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, "Vehicle") });

                vehicle.DeletedAt = DateTime.Now;
                _vehicleRepo.Update(vehicle);

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = string.Format(SuccessMessageConstants.DeleteSuccess, "Vehicle " + vehicle.VehicleNumber), Vehicle = vehicle });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        /// <summary>
        ///   Delete Vehicle based on Vehicle AxCode.
        /// </summary>
        /// <param name="code"></param>
        /// <response code="200">If Vehicle deleted successfully</response>
        /// <response code="400">If Vehicle not found against id provided.</response>
        [HttpDelete("DeleteVehicleByAx/{code}")]
        public IActionResult DeleteByAx(string code)
        {
            try
            {
                var vehicle = _vehicleRepo.FindBy(x => x.AXCode == code && x.DeletedAt == null);
                if (vehicle == null)
                    return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = string.Format(ErrorMessageConstants.NotFound, "Vehicle") });

                vehicle.DeletedAt = DateTime.Now;
                _vehicleRepo.Update(vehicle);

                return Ok(new { Status = ApiStatus.Success.ToString(), Message = string.Format(SuccessMessageConstants.DeleteSuccess, "Vehicle" + " " + vehicle.VehicleNumber), Vehicle = vehicle });
            }
            catch (Exception)
            {
                return BadRequest(new { Status = ApiStatus.Error.ToString(), Message = ErrorMessageConstants.Error });
            }
        }

        #endregion Action Methods
    }
}
