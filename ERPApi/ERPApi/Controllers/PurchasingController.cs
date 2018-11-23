using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ERPApi.Controllers
{
    [Route("api/purchasing")]
    [ApiController]
    public class PurchasingController : ControllerBase
    {
        private ILoggerManager _logger;
        private IPurchasingService _service;

        public PurchasingController(ILoggerManager logger, IPurchasingService service)
        {
            _logger = logger;
            _service = service;
        }
    }
}