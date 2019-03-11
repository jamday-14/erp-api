using Contracts;
using Entities.Models;

namespace Services
{
    public class VendorItemRepository : RepositoryBase<TblVendorItems>, IVendorItemRepository
    {
        public VendorItemRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
