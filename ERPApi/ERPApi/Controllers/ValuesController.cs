﻿using System.Collections.Generic;
using Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERPApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private ILoggerManager _logger;
        private IUserService _repo;

        public ValuesController(ILoggerManager logger, IUserService repo)
        {
            _logger = logger;
            _repo = repo;
        }

        // GET api/values
        //Sample Action Name configured in the database
        [HttpGet, ActionName("Maintenance.Customer")]
        [Authorize]
        public ActionResult<IEnumerable<string>> Get()
        {
            var password = CryptoHelper.Crypto.HashPassword("adminPassword1");
            //_logger.LogInfo("Here is info message from our values controller.");
            //_logger.LogDebug("Here is debug message from our values controller.");
            //_logger.LogWarn("Here is warn message from our values controller.");
            //_logger.LogError("Here is error message from our values controller.");

            var companies = _repo.CompanyRepo.FindAll();

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
