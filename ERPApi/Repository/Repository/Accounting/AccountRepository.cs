using Contracts;
using Entities.Models;

namespace Services
{
    public class AccountRepository : RepositoryBase<TblAccounts>, IAccountRepository
    {
        public AccountRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
