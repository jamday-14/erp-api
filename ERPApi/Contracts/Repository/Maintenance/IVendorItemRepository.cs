﻿using Entities.Models;

namespace Contracts
{
    public interface IVendorItemRepository : IRepositoryBase<TblVendorItems>
    {
        TblVendorItems Get(int vendorId, int itemId);
    }
}
