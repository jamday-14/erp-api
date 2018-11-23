using Entities.Models;
using System.Linq;

namespace Contracts
{
    public interface ICustomerRepository : IRepositoryBase<TblCustomers>
    {
        IQueryable<TblCustomers> GetAllCustomers();
    }
}
