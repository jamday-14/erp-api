using System.Linq;
using Contracts;
using Entities.Models;

namespace Services
{
    public class ItemEntryDetailRepository : RepositoryBase<TblItemEntryDetails>, IItemEntryDetailRepository
    {
        public ItemEntryDetailRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }

        public IQueryable<TblItemEntryDetails> GetByItemEntryId(int id)
        {
            return RepositoryContext.TblItemEntryDetails.Where(x => x.ItemEntryId == id)
                   .OrderBy(x => x.Id);
        }
    }
}
