using Contracts;
using Entities.Models;
using System.Linq;

namespace Services
{
    public class VendorItemRepository : RepositoryBase<TblVendorItems>, IVendorItemRepository
    {
        public VendorItemRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }

        public TblVendorItems Get(int vendorId, int itemId)
        {
            return RepositoryContext.TblVendorItems.Where(x => x.VendorId == vendorId && x.ItemId == itemId).FirstOrDefault();
        }
    }
}
