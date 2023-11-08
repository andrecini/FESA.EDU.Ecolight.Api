using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.ComponentModel.DataAnnotations;
using Treinamento.REST.API.Responses;
using Treinamento.REST.Domain.Entities.Devices;
using Treinamento.REST.Domain.Entities.Devices.Output;
using Treinamento.REST.Domain.Entities.EndpointsModel;
using Treinamento.REST.Domain.Interfaces.Services;
using Treinamento.REST.Services.Services;

namespace Treinamento.REST.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v1/dashboards")]
    public class DashboardController : ControllerBase
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly IDeviceService _service;
        private readonly IMemoryCache _cache;

        public DashboardController(ILogger<DashboardController> logger, IDeviceService service, IMemoryCache cache)
        {
            _logger = logger;
            _service = service;
            _cache = cache;
        }

        /// <summary>
        /// Retrieves a Dashboard Data.
        /// </summary>
        /// <param name="companyId">Company Id, greater than or equal to 1.</param>
        /// <returns>Returns a list of Devices.</returns>
        [HttpGet()]
        [Authorize]
        public IActionResult GetDashboard([Required] int companyId)
        {
            var dashboard = _service.GetDashboard(companyId);

            if (dashboard == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while communicating with the database.");
            }

            return StatusCode(StatusCodes.Status200OK, new GetByIdResponse<Dashboard>()
            {
                Success = true,
                Message = $"Dashboard data was found",
                Result = dashboard
            });
        }

        /// <summary>
        /// Retrieves a Report Data.
        /// </summary>
        /// <param name="companyId">Company Id, greater than or equal to 1.</param>
        /// <returns>Returns a list of Devices.</returns>
        [HttpGet("report")]
        [Authorize]
        public IActionResult GetReport([Required] int companyId)
        {
            var report = _service.GetDeviceReport(companyId);

            if (report == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while communicating with the database.");
            }

            return StatusCode(StatusCodes.Status200OK, new GetByIdResponse<DeviceReport>()
            {
                Success = true,
                Message = $"Report data was found",
                Result = report
            });
        }

        [HttpGet("Teste")]
        public IActionResult Teste([Required] int companyId)
        {
            var report = _service.GetDashboard(companyId);

            if (report == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while communicating with the database.");
            }

            return StatusCode(StatusCodes.Status200OK, new GetByIdResponse<Dashboard>()
            {
                Success = true,
                Message = $"Report data was found",
                Result = report
            });
        }

        [HttpGet("Teste2")]
        public IActionResult Teste2([Required] int companyId)
        {
            var report = _service.GetDeviceReport(companyId);

            if (report == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while communicating with the database.");
            }

            return StatusCode(StatusCodes.Status200OK, new GetByIdResponse<DeviceReport>()
            {
                Success = true,
                Message = $"Report data was found",
                Result = report
            });
        }
    }
}