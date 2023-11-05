using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.ComponentModel.DataAnnotations;
using Treinamento.REST.API.Responses;
using Treinamento.REST.Domain.Entities.Devices;
using Treinamento.REST.Domain.Entities.EndpointsModel;
using Treinamento.REST.Domain.Entities.Users;
using Treinamento.REST.Domain.Enums;
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
        public IActionResult GetDevices([Required] int page, [Required] int pageSize)
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
                TotalAmount = _service.GetTotalAmountOfDevices(),
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
            //var user = CacheHelper.GetOrSet(_cache, $"users_{id}",
            //    () => _service.GetUserById(id), TimeSpan.FromMinutes(5));

            //if (user == null)
            //{
            //    return StatusCode(StatusCodes.Status404NotFound, new GetByIdResponse<User>()
            //    {
            //        Success = false,
            //        Message = $"No user with id '{id}' was found",
            //        User = user
            //    });
            //}

            //return StatusCode(StatusCodes.Status200OK, new GetByIdResponse<User>()
            //{
            //    Success = true,
            //    Message = $"A user with id '{id}' was found",
            //    User = user
            //});

            return Ok(); //Remover depois de inserir a lógica
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
            //var newUser = _service.AddUser(user);

            //if (newUser == null)
            //{
            //    return BadRequest("Unable to Add user. Check the data entered and try again.");
            //}

            //return StatusCode(StatusCodes.Status201Created, new PostResponse<User>()
            //{
            //    Success = true,
            //    Message = "User successfully created.",
            //    URI = @$"{Request.Scheme}://{Request.Host.Value}/v1/users/{newUser.Id}",
            //    CreatedUser = newUser
            //});

            return Ok(); //Remover depois de inserir a lógica
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
            //var userUpdated = _service.UpdateUser(id, user);

            //if (userUpdated == null)
            //{
            //    return BadRequest("Unable to Update user. Check the data entered and try again.");
            //}

            //return StatusCode(StatusCodes.Status200OK, new PutResponse<User>()
            //{
            //    Success = true,
            //    Message = "User updated successfully.",
            //    URI = @$"{Request.Scheme}://{Request.Host.Value}/v1/users/{id}",
            //    UpdatedUser = userUpdated
            //});

            return Ok(); //Remover depois de inserir a lógica
        }
    }
}