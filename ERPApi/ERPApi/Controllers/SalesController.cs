using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ERPApi.Controllers
{
    [Route("api/sales")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private ILoggerManager _logger;
        private ISalesService _service;

        public SalesController(ILoggerManager logger, ISalesService service)
        {
            _logger = logger;
            _service = service;
        }
    }
}