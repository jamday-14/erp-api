using AutoMapper;
using Contracts;
using Entities.ExtendedModels;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ERPApi.Controllers
{
    [Route("api/maintenance")]
    [ApiController]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    public class MaintenanceController : ControllerBase
    {
        private ILoggerManager _logger;
        private IMaintenanceService _service;
        private IMapper _mapper;
        public MaintenanceController(ILoggerManager logger, IMaintenanceService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        [HttpGet, Route("customer")]
        [ActionName("Maintenance.Customer")]
        [Authorize]
        [Produces(typeof(IList<Customer>))]
        public ActionResult GetCustomers()
        {
            var customers = _service.GetCustomers();

            return Ok(customers);
        }

        [HttpGet, Route("customer/{id:int}")]
        [ActionName("Customer.Open")]
        [Authorize]
        [Produces(typeof(Customer))]
        public ActionResult GetCustomer(int id)
        {
            CustomerDetail customer = _mapper.Map<CustomerDetail>(_service.Customer.FindById(id));
            return Ok();
        }

        [HttpPost, Route("customer")]
        [ActionName("Customer.New")]
        [Authorize]
        [ProducesResponseType(201)]
        public ActionResult PostCustomer(CustomerDetail request)
        {
            var customer = _mapper.Map<TblCustomers>(request);

            _service.Customer.Create(customer);
            _service.Save();

            return CreatedAtRoute("Customer.Open", new { id = customer.Id });
        }

        [HttpPatch, Route("customer/{id:int}")]
        [ActionName("Customer.Edit")]
        [Authorize]
        [ProducesResponseType(204)]
        public ActionResult PatchCustomer(int id, Customer request)
        {
            return NoContent();
        }
    }
}