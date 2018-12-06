using Contracts;
using Entities.Models;

namespace Services
{
    public class ItemRepository : RepositoryBase<TblItem>, IItemRepository
    {
        public ItemRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
