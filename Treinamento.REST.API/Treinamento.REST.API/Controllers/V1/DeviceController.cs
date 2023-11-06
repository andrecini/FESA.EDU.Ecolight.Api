using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.ComponentModel.DataAnnotations;
using Treinamento.REST.API.Responses;
using Treinamento.REST.Domain.Entities.Devices;
using Treinamento.REST.Domain.Entities.EndpointsModel;
using Treinamento.REST.Domain.Interfaces.Services;
using Treinamento.REST.Services.Services;

namespace Treinamento.REST.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v1/devices")]
    public class DeviceController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IDeviceService _service;
        private readonly IMemoryCache _cache;

        public DeviceController(ILogger<UsersController> logger, IDeviceService service, IMemoryCache cache)
        {
            _logger = logger;
            _service = service;
            _cache = cache;
        }

        /// <summary>
        /// Retrieves a list of devices.
        /// </summary>
        /// <param name="page">Page number, greater than or equal to 1.</param>
        /// <param name="pageSize">Page size, greater than or equal to 5.</param>
        /// <returns>Returns a list of Devices.</returns>
        [HttpGet]
        [Authorize]
        public IActionResult GetDevices([Required] int page, [Required] int pageSize, [Required] int companyId)
        {
            if (page <= 0) return BadRequest("The page value must be greater than 0.");
            if (pageSize < 5) return BadRequest("The page size value must be grater or equal than 0.");

            var devices = CacheHelper.GetOrSet(_cache, $"devices_{page}_{pageSize}",
                () => _service.GetDevices(page, pageSize), TimeSpan.FromMinutes(5));

            if (devices == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while communicating with the database.");
            }

            return StatusCode(StatusCodes.Status200OK, new GetResponse<Device>()
            {
                Page = page,
                PageSize = pageSize,
                TotalAmount = _service.GetTotalAmountOfDevices(companyId),
                Success = true,
                Message = $"{devices.Count()} devices found",
                Result = devices
            });
        }

        /// <summary>
        /// Retrieve a device by their unique ID.
        /// </summary>
        /// <remarks>
        /// This endpoint allows you to retrieve a devices's information by providing their unique ID.
        /// </remarks>
        /// <param name="id">The unique ID of the device to retrieve.</param>
        /// <returns>Returns the device information based on the provided ID.</returns>
        /// <response code="200">Returns the device information if found.</response>
        /// <response code="400">Returns an error message if no device with the specified ID is found.</response>
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetDeviceById([Required] int id)
        {
            var device = CacheHelper.GetOrSet(_cache, $"device_{id}",
                () => _service.GetDeviceById(id), TimeSpan.FromMinutes(5));

            if (device == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new GetByIdResponse<Device>()
                {
                    Success = false,
                    Message = $"No device with id '{id}' was found",
                    Result = device
                });
            }

            return StatusCode(StatusCodes.Status200OK, new GetByIdResponse<Device>()
            {
                Success = true,
                Message = $"A device with id '{id}' was found",
                Result = device
            });
        }

        /// <summary>
        /// Create a new device.
        /// </summary>
        /// <remarks>
        /// This endpoint allows you to create a new device by providing their basic information.
        /// </remarks>
        /// <param name="user">The basic information of the device to be created.</param>
        /// <returns>Returns the result of device creation.</returns>
        /// <response code="201">Returns a successful device creation result.</response>
        /// <response code="400">Returns an error message if the data provided is invalid.</response>
        [HttpPost]
        public IActionResult AddDevice([FromBody] DeviceInput device) 
        {
            var newDevice = _service.AddDevice(device);

            if (newDevice == null)
            {
                return BadRequest("Unable to Add device. Check the data entered and try again.");
            }

            return StatusCode(StatusCodes.Status201Created, new PostResponse<Device>()
            {
                Success = true,
                Message = "Device successfully created.",
                URI = @$"{Request.Scheme}://{Request.Host.Value}/v1/devices/{newDevice.Id}",
                CreatedEntity = newDevice
            });
        }

        /// <summary>
        /// Update an existing device.
        /// </summary>
        /// <remarks>
        /// This endpoint allows you to update an existing device's information by providing their ID and new data.
        /// </remarks>
        /// <param name="id">The ID of the device to be updated.</param>
        /// <param name="user">The updated device information.</param>
        /// <returns>Returns the result of device update.</returns>
        /// <response code="200">Returns a successful device update result.</response>
        /// <response code="400">Returns an error message if the data provided is invalid.</response>
        [HttpPut]
        [Authorize]
        public IActionResult UpdateDevice([Required] int id, [FromBody] DeviceInput device)
        {
            var deviceUpdated = _service.UpdateDevice(id, device);

            if (deviceUpdated == null)
            {
                return BadRequest("Unable to Update device. Check the data entered and try again.");
            }

            return StatusCode(StatusCodes.Status200OK, new PutResponse<Device>()
            {
                Success = true,
                Message = "Device updated successfully.",
                URI = @$"{Request.Scheme}://{Request.Host.Value}/v1/devices/{id}",
                UpdatedEntity = deviceUpdated
            });
        }

        [HttpGet("Teste")]
        public IActionResult Teste()
        {
            var deviceTeste = _service.GetAllDevicesCarbonTax(1);

            return Ok(deviceTeste);
        }
    }
}