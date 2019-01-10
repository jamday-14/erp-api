﻿using Contracts;
using Entities.Models;
using System.Linq;

namespace Services
{
    public class DeliveryReceiptDetailRepository : RepositoryBase<TblDeliveryReceiptDetails>, IDeliveryReceiptDetailRepository
    {
        public DeliveryReceiptDetailRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
            
        }

        public IQueryable<TblDeliveryReceiptDetails> GetByDeliveryReceiptId(int id)
        {
            return RepositoryContext.TblDeliveryReceiptDetails.Where(x => x.DeliveryReceiptId == id);
        }

        public IQueryable<TblDeliveryReceiptDetails> GetByPendingInvoice(int id)
        {
            return RepositoryContext.TblDeliveryReceiptDetails.Where(x => x.DeliveryReceiptId == id && x.QtyInvoice < (x.Qty - x.QtyReturn) && !x.Closed);
        }
    }
}
