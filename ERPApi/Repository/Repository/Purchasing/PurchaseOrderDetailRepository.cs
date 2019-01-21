using System.Linq;
using Contracts;
using Entities.Models;

namespace Services
{
    public class PurchaseOrderDetailRepository : RepositoryBase<TblPurchaseOrderDetails>, IPurchaseOrderDetailRepository
    {
        public PurchaseOrderDetailRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }

        public IQueryable<TblPurchaseOrderDetails> GetByOrderId(int id)
        {
            return RepositoryContext.TblPurchaseOrderDetails.Where(x => x.PurchaseOrderId == id)
               .OrderBy(x => x.ItemId).ThenBy(x => x.Id);
        }

        public IQueryable<TblPurchaseOrderDetails> GetByPendingReceivingReport(int id)
        {
            return RepositoryContext.TblPurchaseOrderDetails
                .Where(x => x.PurchaseOrderId == id && x.QtyReceived < x.Qty && !x.Closed)
                .OrderBy(x => x.ItemId).ThenBy(x => x.Id);
        }
    }
}
