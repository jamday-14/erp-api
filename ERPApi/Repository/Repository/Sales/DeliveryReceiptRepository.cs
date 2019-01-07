﻿using System.Linq;
using Contracts;
using Entities.Models;

namespace Services
{
    public class DeliveryReceiptRepository : RepositoryBase<TblDeliveryReceipts>, IDeliveryReceiptRepository
    {
        public DeliveryReceiptRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }

        public IQueryable<TblDeliveryReceiptDetails> GetDetails(int id)
        {
            return RepositoryContext.TblDeliveryReceiptDetails.Where(x => x.DeliveryReceiptId == id && x.QtyInvoice < x.Qty && !x.Closed);
        }

        public IQueryable<TblDeliveryReceipts> GetPendingByCustomer(int customerId)
        {
            var query = from receipts in RepositoryContext.TblDeliveryReceipts
                        join details in RepositoryContext.TblDeliveryReceiptDetails on receipts.Id equals details.DeliveryReceiptId
                        where receipts.CustomerId == customerId && details.QtyInvoice < details.Qty
                        && !receipts.Closed && !details.Closed
                        select receipts;

            return query.Distinct();
        }
    }
}
