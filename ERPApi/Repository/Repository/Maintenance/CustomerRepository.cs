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

        public TblCustomers FindById(int id)
        {
            return RepositoryContext.TblCustomers.Find(id);
        }

        public IQueryable<TblCustomers> GetAllCustomers()
        {
            return RepositoryContext.TblCustomers.Where(x => x.Active);
        }
    }
}
