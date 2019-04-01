using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Contracts;
using Entities.ExtendedModels;
using Entities.Models;

namespace Services
{
    public class MaintenanceService : IMaintenanceService
    {
        private ERPContext _repoContext;
        private readonly IMapper _mapper;

        #region PRIVATE REPOSITORY INTERFACES
        private IBankRepository _bankRepo;
        private ICompanyRepository _companyRepo;
        private ICurrencyRepository _currencyRepo;
        private ICustomerRepository _customerRepo;
        private ICustomerTypeRepository _customerTypeRepo;
        private IEmployeeRepository _employeeRepo;
        private IItemRepository _itemRepo;
        private IModesOfPaymentRepository _modesOfPaymentRepo;
        private IPriceCategoryRepository _priceCategoryRepo;
        private IReasonForInventoryAdjustmentRepository _reasonForIARepo;
        private ITermsRepository _termsRepo;
        private IUnitRepository _unitRepo;
        private IVendorRepository _vendorRepo;
        private IWarehouseRepository _warehouseRepo;
        private IAccountTypeRepository _accountTypeRepo;
        private IVendorItemRepository _vendorItemRepo;
        #endregion

        public MaintenanceService(ERPContext repositoryContext, IMapper mapper)
        {
            _repoContext = repositoryContext;
            _mapper = mapper;
        }

        #region REPOSITORY GETTERS
        public IBankRepository BankRepo
        {
            get
            {
                if (_bankRepo == null)
                {
                    _bankRepo = new BankRepository(_repoContext);
                }
                return _bankRepo;
            }
        }

        public ICompanyRepository CompanyRepo
        {
            get
            {
                if (_companyRepo == null)
                {
                    _companyRepo = new CompanyRepository(_repoContext);
                }
                return _companyRepo;
            }
        }

        public ICurrencyRepository CurrencyRepo
        {
            get
            {
                if (_currencyRepo == null)
                {
                    _currencyRepo = new CurrencyRepository(_repoContext);
                }
                return _currencyRepo;
            }
        }

        public ICustomerRepository CustomerRepo
        {
            get
            {
                if (_customerRepo == null)
                {
                    _customerRepo = new CustomerRepository(_repoContext);
                }
                return _customerRepo;
            }
        }

        public ICustomerTypeRepository CustomerTypeRepo
        {
            get
            {
                if (_customerTypeRepo == null)
                {
                    _customerTypeRepo = new CustomerTypeRepository(_repoContext);
                }
                return _customerTypeRepo;
            }
        }

        public IEmployeeRepository EmployeeRepo
        {
            get
            {
                if (_employeeRepo == null)
                {
                    _employeeRepo = new EmployeeRepository(_repoContext);
                }
                return _employeeRepo;
            }
        }

        public IItemRepository ItemRepo
        {
            get
            {
                if (_itemRepo == null)
                {
                    _itemRepo = new ItemRepository(_repoContext);
                }
                return _itemRepo;
            }
        }

        public IModesOfPaymentRepository MOPRepo
        {
            get
            {
                if (_modesOfPaymentRepo == null)
                {
                    _modesOfPaymentRepo = new ModesOfPaymentRepository(_repoContext);
                }
                return _modesOfPaymentRepo;
            }
        }

        public IPriceCategoryRepository PriceCategoryRepo
        {
            get
            {
                if (_priceCategoryRepo == null)
                {
                    _priceCategoryRepo = new PriceCategoryRepository(_repoContext);
                }
                return _priceCategoryRepo;
            }
        }

        public IReasonForInventoryAdjustmentRepository RFIARepo
        {
            get
            {
                if (_reasonForIARepo == null)
                {
                    _reasonForIARepo = new ReasonForInventoryAdjustmentRepository(_repoContext);
                }
                return _reasonForIARepo;
            }
        }

        public ITermsRepository TermsRepo
        {
            get
            {
                if (_termsRepo == null)
                {
                    _termsRepo = new TermsRepository(_repoContext);
                }
                return _termsRepo;
            }
        }

        public IUnitRepository UnitRepo
        {
            get
            {
                if (_unitRepo == null)
                {
                    _unitRepo = new UnitRepository(_repoContext);
                }
                return _unitRepo;
            }
        }

        public IVendorRepository VendorRepo
        {
            get
            {
                if (_vendorRepo == null)
                {
                    _vendorRepo = new VendorRepository(_repoContext);
                }
                return _vendorRepo;
            }
        }

        public IWarehouseRepository WarehouseRepo
        {
            get
            {
                if (_warehouseRepo == null)
                {
                    _warehouseRepo = new WarehouseRepository(_repoContext);
                }
                return _warehouseRepo;
            }
        }

        public IAccountTypeRepository AccountTypeRepo
        {
            get
            {
                if (_accountTypeRepo == null)
                {
                    _accountTypeRepo = new AccountTypeRepository(_repoContext);
                }
                return _accountTypeRepo;
            }
        }

        public IVendorItemRepository VendorItemRepo
        {
            get
            {
                if (_vendorItemRepo == null)
                {
                    _vendorItemRepo = new VendorItemRepository(_repoContext);
                }

                return _vendorItemRepo;
            }
        }
        #endregion

        public IList<Customer> GetCustomers()
        {
            var customers = CustomerRepo.GetAllCustomers().ToList();

            return _mapper.Map<List<Customer>>(customers);
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }

        public void SaveVendorItem(int vendorId, int itemId, decimal costPrice)
        {
            var vendorItem = VendorItemRepo.Get(vendorId, itemId);
            if (vendorItem != null)
                vendorItem.CostPrice = costPrice;
            else VendorItemRepo.Create(new TblVendorItems { ItemId = itemId, CostPrice = costPrice, VendorId = vendorId });
        }
    }
}
