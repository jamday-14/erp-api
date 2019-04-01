using Contracts;
using Entities.Models;

namespace Services
{
    public class InventoryRepository : RepositoryBase<TblInventory>, IInventoryRepository
    {
        public InventoryRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
