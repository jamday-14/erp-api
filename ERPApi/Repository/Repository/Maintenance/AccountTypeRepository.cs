using Contracts;
using Entities.Models;

namespace Services
{
    public class AccountTypeRepository : RepositoryBase<TblAccountTypes>, IAccountTypeRepository
    {
        public AccountTypeRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
