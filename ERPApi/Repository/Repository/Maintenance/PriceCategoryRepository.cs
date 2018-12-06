using Contracts;
using Entities.Models;

namespace Services
{
    public class PriceCategoryRepository : RepositoryBase<TblPriceCategory>, IPriceCategoryRepository
    {
        public PriceCategoryRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
