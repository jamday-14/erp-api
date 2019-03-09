﻿using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.ExtendedModels;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class ItemRepository : RepositoryBase<TblItems>, IItemRepository
    {
        public ItemRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<VendorItem> FindByVendor(int vendorId)
        {

            var result = RepositoryContext.TblItems
                   .Include(x => x.TblInventoryLedger)
                   .ToList()
                   .Select(z => new VendorItem
                   {
                       Id = z.Id,
                       ItemCode = z.ItemCode,
                       QtyOnHand = z.TblInventoryLedger.OrderByDescending(y => y.Date).DefaultIfEmpty(new TblInventoryLedger()).First().EndQty,
                       Description = z.Description,
                       UnitId = z.UnitId,
                       UnitPrice = z.UnitPrice
                   });

            return result;
        }
    }
}
