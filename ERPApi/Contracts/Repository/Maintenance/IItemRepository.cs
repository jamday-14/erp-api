using Entities.ExtendedModels;
using Entities.Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface IItemRepository : IRepositoryBase<TblItems>
    {
        IEnumerable<VendorItem> FindByVendor(int vendorId);
    }
}
