using System.Linq;
using Contracts;
using Entities.Models;

namespace Services
{
    public class PurchaseOrderRepository : RepositoryBase<TblPurchaseOrders>, IPurchaseOrderRepository
    {
        public PurchaseOrderRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }

        public IQueryable<TblPurchaseOrders> GetPendingByVendor(int vendorId)
        {
            var query = from orders in RepositoryContext.TblPurchaseOrders
                        join details in RepositoryContext.TblPurchaseOrderDetails on orders.Id equals details.PurchaseOrderId
                        where orders.VendorId == vendorId && details.QtyReceived < details.Qty
                        && !orders.Closed && !details.Closed
                        select orders;

            return query.Distinct().OrderByDescending(x => x.Date);
        }
    }
}
