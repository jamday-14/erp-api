using Entities.ExtendedModels;
using System.Collections.Generic;

namespace Contracts
{
    public interface IMaintenanceService
    {
        ICustomerRepository Customer { get; }

        IList<Customer> GetCustomers();
    }
}
