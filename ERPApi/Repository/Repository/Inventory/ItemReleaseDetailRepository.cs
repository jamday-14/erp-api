using Contracts;
using Entities.Models;
using System.Linq;

namespace Services
{
    public class ItemReleaseDetailRepository : RepositoryBase<TblItemReleaseDetails>, IItemReleaseDetailRepository
    {
        public ItemReleaseDetailRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }

        public IQueryable<TblItemReleaseDetails> GetByItemReleaseId(int id)
        {
            return RepositoryContext.TblItemReleaseDetails.Where(x => x.ItemReleaseId == id)
                  .OrderBy(x => x.Id);
        }
    }
}
