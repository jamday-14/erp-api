using Contracts;
using Entities.Models;

namespace Services
{
    public class ItemReleaseRepository : RepositoryBase<TblItemReleases>, IItemReleaseRepository
    {
        public ItemReleaseRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
