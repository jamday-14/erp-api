using Contracts;
using Entities.Models;

namespace Services
{
    public class InventoryLedgerRepository : RepositoryBase<TblInventoryLedger>, IInventoryLedgerRepository
    {
        public InventoryLedgerRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
