using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ERPApi.Controllers
{
    [Route("api/reports")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private ILoggerManager _logger;
        private IReportService _service;

        public ReportsController(ILoggerManager logger, IReportService service)
        {
            _logger = logger;
            _service = service;
        }
    }
}