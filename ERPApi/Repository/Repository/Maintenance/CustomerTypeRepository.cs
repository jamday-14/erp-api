using Contracts;
using Entities.Models;

namespace Services
{
    public class CustomerTypeRepository : RepositoryBase<TblCustomerTypes>, ICustomerTypeRepository
    {
        public CustomerTypeRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
