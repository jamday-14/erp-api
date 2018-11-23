using System.Linq;
using Contracts;
using Entities.Models;

namespace Services
{
    public class CustomerRepository : RepositoryBase<TblCustomers>, ICustomerRepository
    {
        public CustomerRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }

        public IQueryable<TblCustomers> GetAllCustomers()
        {
            return RepositoryContext.TblCustomers.Where(x => x.Active);
        }
    }
}
