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

        public TblPurchaseOrderDetails PostBill(int podetailId, int poid, double qty)
        {
            TblPurchaseOrderDetails detail = FindDetail(podetailId, poid);
            detail.QtyBilled += qty;

            return detail;
        }

        public TblPurchaseOrderDetails PostReceipt(int podetailId, int poid, double? newQty, double? originalQty)
        {
            TblPurchaseOrderDetails detail = FindDetail(podetailId, poid);

            if (originalQty.HasValue)
                detail.QtyReceived -= originalQty.Value;

            if (newQty.HasValue)
                detail.QtyReceived += newQty.Value;

            detail.Closed = detail.Qty - detail.QtyReceived == 0;

            return detail;
        }

        private TblPurchaseOrderDetails FindDetail(int podetailId, int poid)
        {
            return RepositoryContext.TblPurchaseOrderDetails.Where(x => x.Id == podetailId && x.PurchaseOrderId == poid).FirstOrDefault();
        }
    }
}
