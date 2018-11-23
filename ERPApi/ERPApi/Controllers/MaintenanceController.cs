using Contracts;
using Entities.ExtendedModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        [Produces(typeof(IList<Customer>))]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public ActionResult GetCustomers()
        {
            var customers = _service.GetCustomers();

            return Ok(customers);
        }
    }
}