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
    [Route("v1/settings")]
    public class SettingsController : ControllerBase
    {
        private readonly ILogger<SettingsController> _logger;
        private readonly ISettingsService _service;
        private readonly IMemoryCache _cache;

        public SettingsController(ILogger<SettingsController> logger, ISettingsService service, IMemoryCache cache)
        {
            _logger = logger;
            _service = service;
            _cache = cache;
        }

        /// <summary>
        /// Retrieves a list of settings.
        /// </summary>
        /// <param name="page">Page number, greater than or equal to 1.</param>
        /// <param name="pageSize">Page size, greater than or equal to 5.</param>
        /// <returns>Returns a list of Settings.</returns>
        [HttpGet]
        [Authorize]
        public IActionResult GetSettings([Required] int page, [Required] int pageSize)
        {
            if (page <= 0) return BadRequest("The page value must be greater than 0.");
            if (pageSize < 5) return BadRequest("The page size value must be grater or equal than 0.");

            var settings = CacheHelper.GetOrSet(_cache, $"settings_{page}_{pageSize}",
                () => _service.GetSettings(page, pageSize), TimeSpan.FromMinutes(5));

            if (settings == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while communicating with the database.");
            }

            return StatusCode(StatusCodes.Status200OK, new GetResponse<Settings>()
            {
                Page = page,
                PageSize = pageSize,
                TotalAmount = _service.GetTotalAmountOfSettings(),
                Success = true,
                Message = $"{settings.Count()} settings found",
                Result = settings
            });
        }

        /// <summary>
        /// Retrieve a settings by their unique ID.
        /// </summary>
        /// <remarks>
        /// This endpoint allows you to retrieve a settings's information by providing their unique ID.
        /// </remarks>
        /// <param name="id">The unique ID of the settings to retrieve.</param>
        /// <returns>Returns the settings information based on the provided ID.</returns>
        /// <response code="200">Returns the settings information if found.</response>
        /// <response code="400">Returns an error message if no settings with the specified ID is found.</response>
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetSettingsById([Required] int id)
        {
            var settings = CacheHelper.GetOrSet(_cache, $"settings_{id}",
                () => _service.GetSettingsById(id), TimeSpan.FromMinutes(5));

            if (settings == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new GetByIdResponse<Settings>()
                {
                    Success = false,
                    Message = $"No settings with id '{id}' was found",
                    Result = settings
                });
            }

            return StatusCode(StatusCodes.Status200OK, new GetByIdResponse<Settings>()
            {
                Success = true,
                Message = $"A settings with id '{id}' was found",
                Result = settings
            });
        }

        /// <summary>
        /// Create a new settings.
        /// </summary>
        /// <remarks>
        /// This endpoint allows you to create a new settings by providing their basic information.
        /// </remarks>
        /// <param name="user">The basic information of the settings to be created.</param>
        /// <returns>Returns the result of settings creation.</returns>
        /// <response code="201">Returns a successful settings creation result.</response>
        /// <response code="400">Returns an error message if the data provided is invalid.</response>
        [HttpPost]
        public IActionResult AddSettings([FromBody] SettingsInput settings) 
        {
            var newSettings = _service.AddSettings(settings);

            if (newSettings == null)
            {
                return BadRequest("Unable to Add settings. Check the data entered and try again.");
            }

            return StatusCode(StatusCodes.Status201Created, new PostResponse<Settings>()
            {
                Success = true,
                Message = "Settings successfully created.",
                URI = @$"{Request.Scheme}://{Request.Host.Value}/v1/settings/{newSettings.Id}",
                CreatedEntity = newSettings
            });
        }

        /// <summary>
        /// Update an existing settings.
        /// </summary>
        /// <remarks>
        /// This endpoint allows you to update an existing settings's information by providing their ID and new data.
        /// </remarks>
        /// <param name="id">The ID of the settings to be updated.</param>
        /// <param name="user">The updated settings information.</param>
        /// <returns>Returns the result of settings update.</returns>
        /// <response code="200">Returns a successful settings update result.</response>
        /// <response code="400">Returns an error message if the data provided is invalid.</response>
        [HttpPut]
        [Authorize]
        public IActionResult UpdateDevice([Required] int id, [FromBody] SettingsInput settings)
        {
            var settingsUpdated = _service.UpdateSettings(id, settings);

            if (settingsUpdated == null)
            {
                return BadRequest("Unable to settings device. Check the data entered and try again.");
            }

            return StatusCode(StatusCodes.Status200OK, new PutResponse<Settings>()
            {
                Success = true,
                Message = "Settings updated successfully.",
                URI = @$"{Request.Scheme}://{Request.Host.Value}/v1/settings/{id}",
                UpdatedEntity = settingsUpdated
            });
        }
    }
}