using AutoMapper;
using Contracts;
using Entities;
using Entities.ExtendedModels;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ERPApi.Controllers
{
    [Route("api/maintenance")]
    [ApiController]
    [Authorize]
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

        #region Customer
        [HttpGet, Route("customers")]
        [ActionName("Maintenance.Customer")]
        [Produces(typeof(IList<TblCustomers>))]
        public ActionResult GetCustomers()
        {
            var records = _service.CustomerRepo.FindAll();

            return Ok(records);
        }

        [HttpGet, Route("customers/{id:int}")]
        [ActionName("Customer.Open")]
        [Produces(typeof(TblCustomers))]
        public ActionResult GetCustomer(int id)
        {
            var record = _service.CustomerRepo.FindByCondition(x => x.Id == id).FirstOrDefault();
            return Ok(record);
        }

        [HttpPost, Route("customers")]
        [ActionName("Customer.New")]
        [ProducesResponseType(201)]
        public ActionResult PostCustomer(TblCustomers request)
        {
            request.CreatedById = Statics.LoggedInUser.userId;
            request.LastEditedById = Statics.LoggedInUser.userId;
            request.CreationDate = System.DateTime.UtcNow;
            request.LastEditedDate = System.DateTime.UtcNow;
            request.Active = true;

            _service.CustomerRepo.Create(request);
            _service.Save();

            return Created("maintenance/customers", new { id = request.Id });
        }
        #endregion

        #region Bank
        [HttpGet, Route("banks")]
        [ActionName("Maintenance.Bank")]
        [Produces(typeof(IList<TblBanks>))]
        public ActionResult GetBanks()
        {
            var records = _service.BankRepo.FindAll();

            return Ok(records);
        }

        [HttpGet, Route("banks/{id:int}")]
        [ActionName("Bank.Open")]
        [Produces(typeof(TblBanks))]
        public ActionResult GetBank(int id)
        {
            var record = _service.BankRepo.FindByCondition(x => x.Id == id).FirstOrDefault();
            return Ok(record);
        }

        [HttpPost, Route("banks")]
        [ActionName("Bank.New")]
        [ProducesResponseType(201)]
        public ActionResult PostBank(TblBanks request)
        {
            _service.BankRepo.Create(request);
            _service.Save();

            return CreatedAtRoute("Bank.Open", new { id = request.Id });
        }
        #endregion

        [HttpGet, Route("currencies")]
        [AllowAnonymous]
        [Produces(typeof(IList<TblCurrencies>))]
        public ActionResult GetCurrencies()
        {
            var records = _service.CurrencyRepo.FindAll();

            return Ok(records);
        }

        #region Customer Type
        [HttpGet, Route("customer-types")]
        [ActionName("Maintenance.CustomerType")]
        [Produces(typeof(IList<TblCustomerTypes>))]
        public ActionResult GetCustomerTypes()
        {
            var records = _service.CustomerTypeRepo.FindAll();

            return Ok(records);
        }

        [HttpGet, Route("customer-types/{id:int}")]
        [ActionName("CustomerType.Open")]
        [Produces(typeof(TblCustomerTypes))]
        public ActionResult GetCustomerType(int id)
        {
            var record = _service.CustomerTypeRepo.FindByCondition(x => x.Id == id).FirstOrDefault();
            return Ok(record);
        }

        [HttpPost, Route("customer-types")]
        [ActionName("CustomerType.New")]
        [ProducesResponseType(201)]
        public ActionResult PostCustomerType(TblCustomerTypes request)
        {
            _service.CustomerTypeRepo.Create(request);
            _service.Save();

            return CreatedAtRoute("CustomerType.Open", new { id = request.Id });
        }
        #endregion

        #region Employee
        [HttpGet, Route("employees")]
        [ActionName("Maintenance.Employee")]
        [Produces(typeof(IList<TblEmployees>))]
        public ActionResult GetEmployees()
        {
            var records = _service.EmployeeRepo.FindAll();

            return Ok(records);
        }

        [HttpGet, Route("employees/{id:int}")]
        [ActionName("Employee.Open")]
        [Produces(typeof(TblEmployees))]
        public ActionResult GetEmployee(int id)
        {
            var record = _service.EmployeeRepo.FindByCondition(x => x.Id == id).FirstOrDefault();
            return Ok(record);
        }

        [HttpPost, Route("employees")]
        [ActionName("Employee.New")]
        [ProducesResponseType(201)]
        public ActionResult PostEmployee(TblEmployees request)
        {
            request.CreatedById = Statics.LoggedInUser.userId;
            request.LastEditedById = Statics.LoggedInUser.userId;
            request.CreationDate = System.DateTime.UtcNow;
            request.LastEditedDate = System.DateTime.UtcNow;
            request.Active = true;

            _service.EmployeeRepo.Create(request);
            _service.Save();

            return Created("maintenance/employees", new { id = request.Id });
        }
        #endregion

        #region Item
        [HttpGet, Route("items")]
        [ActionName("Maintenance.Item")]
        [Produces(typeof(IList<Item>))]
        public ActionResult GetItems()
        {
            var records = _service.ItemRepo.FindAll();

            return Ok(_mapper.Map<IList<Item>>(records));
        }

        [HttpGet, Route("items/{id:int}")]
        [ActionName("Item.Open")]
        [Produces(typeof(Item))]
        public ActionResult GetItem(int id)
        {
            var record = _service.ItemRepo.FindByCondition(x => x.Id == id).FirstOrDefault();
            return Ok(_mapper.Map<Item>(record));
        }

        [HttpPost, Route("items")]
        [ActionName("Item.New")]
        [ProducesResponseType(201)]
        public ActionResult PostItem(Item request)
        {
            request.CreatedById = Statics.LoggedInUser.userId;
            request.LastEditedById = Statics.LoggedInUser.userId;
            request.CreationDate = System.DateTime.UtcNow;
            request.LastEditedDate = System.DateTime.UtcNow;
            request.Active = true;

            _service.ItemRepo.Create(_mapper.Map<TblItems>(request));
            _service.Save();

            return Created("maintenance/items", new { id = request.Id });
        }

        [HttpGet, Route("vendors/{vendorId}/items")]
        //[ActionName("Maintenance.Item")]
        [AllowAnonymous]
        [Produces(typeof(IList<VendorItem>))]
        public ActionResult GetVendorItems(int? vendorId)
        {
            var records = _service.ItemRepo.FindByVendor(vendorId.Value);

            return Ok(records);
        }

        [HttpPost, Route("vendors/{id}/items")]
        [ActionName("Maintenance.Item")]
        [ProducesResponseType(201)]
        public ActionResult PostVendorItems(NewVendorItem request)
        {
            _service.VendorItemRepo.Create(_mapper.Map<TblVendorItems>(request));
            _service.Save();

            return Created("maintenance/{id}/items", new { id = request.VendorId });
        }

        [HttpGet, Route("items/category")]
        [ActionName("Maintenance.Item")]
        [AllowAnonymous]
        [Produces(typeof(IList<Item>))]
        public ActionResult GetItemsByCategory(bool? isPurchased, bool? isForSale)
        {
            IEnumerable<TblItems> records = new List<TblItems>();

            if (isPurchased.HasValue && isPurchased.Value)
                records = _service.ItemRepo.FindByCondition(x => x.Ipurchased && x.Active && x.CompanyId == Statics.LoggedInUser.companyId);

            if (isForSale.HasValue && isForSale.Value)
                records = _service.ItemRepo.FindByCondition(x => x.IsForSale && x.Active && x.CompanyId == Statics.LoggedInUser.companyId);

            return Ok(_mapper.Map<IList<Item>>(records));
        }

        #endregion

        #region Mode of Payment
        [HttpGet, Route("payment-modes")]
        [ActionName("Maintenance.ModeOfPayment")]
        [Produces(typeof(IList<TblMop>))]
        public ActionResult GetModeOfPayments()
        {
            var records = _service.MOPRepo.FindAll();

            return Ok(records);
        }

        [HttpGet, Route("payment-modes/{id:int}")]
        [ActionName("ModeOfPayment.Open")]
        [Produces(typeof(TblMop))]
        public ActionResult GetModeOfPayment(int id)
        {
            var record = _service.MOPRepo.FindByCondition(x => x.Id == id).FirstOrDefault();
            return Ok(record);
        }

        [HttpPost, Route("payment-modes")]
        [ActionName("ModeOfPayment.New")]
        [ProducesResponseType(201)]
        public ActionResult PostModeOfPayment(TblMop request)
        {
            _service.MOPRepo.Create(request);
            _service.Save();

            return CreatedAtRoute("ModeOfPayment.Open", new { id = request.Id });
        }
        #endregion

        #region Price Category
        [HttpGet, Route("price-categories")]
        [ActionName("Maintenance.PriceCategory")]
        [Produces(typeof(IList<TblPriceCategory>))]
        public ActionResult GetPriceCategories()
        {
            var records = _service.PriceCategoryRepo.FindAll();

            return Ok(records);
        }

        [HttpGet, Route("price-categories/{id:int}")]
        [ActionName("PriceCategory.Open")]
        [Produces(typeof(TblPriceCategory))]
        public ActionResult GetPriceCategory(int id)
        {
            var record = _service.PriceCategoryRepo.FindByCondition(x => x.Id == id).FirstOrDefault();
            return Ok(record);
        }

        [HttpPost, Route("price-categories")]
        [ActionName("PriceCategory.New")]
        [ProducesResponseType(201)]
        public ActionResult PostPriceCategory(TblPriceCategory request)
        {
            _service.PriceCategoryRepo.Create(request);
            _service.Save();

            return CreatedAtRoute("PriceCategory.Open", new { id = request.Id });
        }
        #endregion

        #region Reason for Inventory Adjustment
        [HttpGet, Route("inventory-adjustment-reason")]
        [ActionName("Maintenance.Reason")]
        [Produces(typeof(IList<TblReasonForInventoryAdjustments>))]
        public ActionResult GetInventoryAdjustmentReasons()
        {
            var records = _service.RFIARepo.FindAll();

            return Ok(records);
        }

        [HttpGet, Route("inventory-adjustment-reason/{id:int}")]
        [ActionName("Reason.Open")]
        [Produces(typeof(TblReasonForInventoryAdjustments))]
        public ActionResult GetInventoryAdjustmentReason(int id)
        {
            var record = _service.RFIARepo.FindByCondition(x => x.Id == id).FirstOrDefault();
            return Ok(record);
        }

        [HttpPost, Route("inventory-adjustment-reason")]
        [ActionName("Reason.New")]
        [ProducesResponseType(201)]
        public ActionResult PostInventoryAdjustmentReason(TblReasonForInventoryAdjustments request)
        {
            _service.RFIARepo.Create(request);
            _service.Save();

            return CreatedAtRoute("Reason.Open", new { id = request.Id });
        }
        #endregion

        #region Terms
        [HttpGet, Route("terms")]
        [ActionName("Maintenance.Terms")]
        [Produces(typeof(IList<TblTerms>))]
        public ActionResult GetTerms()
        {
            var records = _service.TermsRepo.FindAll();

            return Ok(records);
        }

        [HttpGet, Route("terms/{id:int}")]
        [ActionName("Terms.Open")]
        [Produces(typeof(TblTerms))]
        public ActionResult GetTerm(int id)
        {
            var record = _service.TermsRepo.FindByCondition(x => x.Id == id).FirstOrDefault();
            return Ok(record);
        }

        [HttpPost, Route("terms")]
        [ActionName("Terms.New")]
        [ProducesResponseType(201)]
        public ActionResult PostTerm(TblTerms request)
        {
            _service.TermsRepo.Create(request);
            _service.Save();

            return CreatedAtRoute("Terms.Open", new { id = request.Id });
        }
        #endregion

        #region Unit
        [HttpGet, Route("units")]
        [ActionName("Maintenance.Unit")]
        [Produces(typeof(IList<TblUnits>))]
        public ActionResult GetUnits()
        {
            var records = _service.UnitRepo.FindAll();

            return Ok(records);
        }

        [HttpGet, Route("units/{id:int}")]
        [ActionName("Unit.Open")]
        [Produces(typeof(TblUnits))]
        public ActionResult GetUnit(int id)
        {
            var record = _service.UnitRepo.FindByCondition(x => x.Id == id).FirstOrDefault();
            return Ok(record);
        }

        [HttpPost, Route("units")]
        [ActionName("Unit.New")]
        [ProducesResponseType(201)]
        public ActionResult PostUnit(TblUnits request)
        {
            _service.UnitRepo.Create(request);
            _service.Save();

            return CreatedAtRoute("Unit.Open", new { id = request.Id });
        }
        #endregion

        #region Vendor
        [HttpGet, Route("vendors")]
        [ActionName("Maintenance.Vendor")]
        [Produces(typeof(IList<TblVendor>))]
        public ActionResult GetVendors()
        {
            var records = _service.VendorRepo.FindAll();

            return Ok(records);
        }

        [HttpGet, Route("vendors/{id:int}")]
        [ActionName("Vendor.Open")]
        [Produces(typeof(TblVendor))]
        public ActionResult GetVendor(int id)
        {
            var record = _service.VendorRepo.FindByCondition(x => x.Id == id).FirstOrDefault();
            return Ok(record);
        }

        [HttpPost, Route("vendors")]
        [ActionName("Vendor.New")]
        [ProducesResponseType(201)]
        public ActionResult PostVendor(TblVendor request)
        {
            request.CreatedById = Statics.LoggedInUser.userId;
            request.LastEditedById = Statics.LoggedInUser.userId;
            request.CreationDate = System.DateTime.UtcNow;
            request.LastEditedDate = System.DateTime.UtcNow;
            request.Active = true;

            _service.VendorRepo.Create(request);
            _service.Save();

            return Created("maintenance/vendors", new { id = request.Id });
        }
        #endregion

        #region Warehouse
        [HttpGet, Route("warehouses")]
        [ActionName("Maintenance.Warehouse")]
        [Produces(typeof(IList<TblWarehouses>))]
        public ActionResult GetWarehouses()
        {
            var records = _service.WarehouseRepo.FindAll();

            return Ok(records);
        }

        [HttpGet, Route("warehouses/{id:int}")]
        [ActionName("Warehouse.Open")]
        [Produces(typeof(TblWarehouses))]
        public ActionResult GetWarehouse(int id)
        {
            var record = _service.WarehouseRepo.FindByCondition(x => x.Id == id).FirstOrDefault();
            return Ok(record);
        }

        [HttpPost, Route("warehouses")]
        [ActionName("Warehouse.New")]
        [ProducesResponseType(201)]
        public ActionResult PostWarehouse(TblWarehouses request)
        {
            request.CreatedById = Statics.LoggedInUser.userId;
            request.LastEditedById = Statics.LoggedInUser.userId;
            request.CreationDate = System.DateTime.UtcNow;
            request.LastEditedDate = System.DateTime.UtcNow;
            request.Active = true;

            _service.WarehouseRepo.Create(request);
            _service.Save();

            return Created("maintenance/warehouses", new { id = request.Id });
        }
        #endregion

        #region AccountTypes
        [HttpGet, Route("account-types")]
        [AllowAnonymous]
        [Produces(typeof(IList<TblAccountTypes>))]
        public ActionResult GetAccountTypes()
        {
            var records = _service.AccountTypeRepo.FindAll()
                .OrderBy(x => x.Order);

            return Ok(records);
        }
        #endregion
    }
}