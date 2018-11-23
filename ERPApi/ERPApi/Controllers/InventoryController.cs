using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ERPApi.Controllers
{
    [Route("api/inventory")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private ILoggerManager _logger;
        private IInventoryService _service;

        public InventoryController(ILoggerManager logger, IInventoryService service)
        {
            _logger = logger;
            _service = service;
        }
    }
}