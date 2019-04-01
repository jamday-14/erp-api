using System.Linq;
using Contracts;
using Entities.Models;

namespace Services
{
    public class DeliveryReceiptRepository : RepositoryBase<TblDeliveryReceipts>, IDeliveryReceiptRepository
    {
        public DeliveryReceiptRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }

        public IQueryable<TblDeliveryReceipts> GetPendingByCustomer(int customerId)
        {
            var query = from receipts in RepositoryContext.TblDeliveryReceipts
                        join details in RepositoryContext.TblDeliveryReceiptDetails on receipts.Id equals details.DeliveryReceiptId
                        where receipts.CustomerId == customerId && details.QtyInvoice < (details.Qty - details.QtyReturn)
                        && !receipts.Closed && !details.Closed
                        select receipts;

            return query.Distinct().OrderByDescending(x=> x.Date);
        }

        public IQueryable<TblDeliveryReceipts> GetByCustomer(int customerId)
        {
            var query = from receipts in RepositoryContext.TblDeliveryReceipts
                        join details in RepositoryContext.TblDeliveryReceiptDetails on receipts.Id equals details.DeliveryReceiptId
                        where receipts.CustomerId == customerId
                        && !receipts.Closed && !details.Closed
                        select receipts;

            return query.Distinct().OrderByDescending(x => x.Date);
        }        
    }
}
