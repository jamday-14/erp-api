using Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERPApi.Controllers
{
    [Route("api/maintenance")]
    [ApiController]
    public class MaintenanceController : ControllerBase
    {
        private ILoggerManager _logger;
        private IMaintenanceService _service;

        public MaintenanceController(ILoggerManager logger, IMaintenanceService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet, Route("customer")]
        [ActionName("Maintenance.Customer")]
        [Authorize]
        public ActionResult GetCustomers()
        {
            var customers = _service.GetCustomers();

            return Ok(customers);
        }
    }
}