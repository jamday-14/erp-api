﻿using Entities.Models;
using System.Linq;

namespace Contracts
{
    public interface IBillRepository : IRepositoryBase<TblBills>
    {
        IQueryable<TblBills> GetByVendor(int vendorId);
        IQueryable<TblBills> GetAvailableByVendor(int vendorId);
    }
}
