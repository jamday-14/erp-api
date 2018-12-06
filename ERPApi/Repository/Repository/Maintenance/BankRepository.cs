using Contracts;
using Entities.Models;

namespace Services
{
    public class BankRepository : RepositoryBase<TblBanks>, IBankRepository
    {
        public BankRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
