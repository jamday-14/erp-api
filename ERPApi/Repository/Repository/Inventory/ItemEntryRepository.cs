using Contracts;
using Entities.Models;

namespace Services
{
    public class ItemEntryRepository : RepositoryBase<TblItemEntries>, IItemEntryRepository
    {
        public ItemEntryRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
