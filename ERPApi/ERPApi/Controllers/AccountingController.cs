using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ERPApi.Controllers
{
    [Route("api/accounting")]
    [ApiController]
    public class AccountingController : ControllerBase
    {
        private ILoggerManager _logger;
        private IAccountingService _service;

        public AccountingController(ILoggerManager logger, IAccountingService service)
        {
            _logger = logger;
            _service = service;
        }
    }
}