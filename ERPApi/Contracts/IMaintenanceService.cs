using Entities.ExtendedModels;
using System.Collections.Generic;

namespace Contracts
{
    public interface IMaintenanceService
    {
        IBankRepository BankRepo { get; }
        ICompanyRepository CompanyRepo { get; }
        ICurrencyRepository CurrencyRepo { get; }
        ICustomerRepository CustomerRepo { get; }
        ICustomerTypeRepository CustomerTypeRepo { get; }
        IEmployeeRepository EmployeeRepo { get; }
        IItemRepository ItemRepo { get; }
        IModesOfPaymentRepository MOPRepo { get; }
        IPriceCategoryRepository PriceCategoryRepo { get; }
        IReasonForInventoryAdjustmentRepository RFIARepo { get; }
        ITermsRepository TermsRepo { get; }
        IUnitRepository UnitRepo { get; }
        IVendorRepository VendorRepo { get; }
        IWarehouseRepository WarehouseRepo { get; }
        IAccountTypeRepository AccountTypeRepo { get; }
        IVendorItemRepository VendorItemRepo { get; }

        IList<Customer> GetCustomers();

        void Save();
        void SaveVendorItem(int vendorId, int itemId, decimal costPrice);
    }
}
