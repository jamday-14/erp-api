using Entities.Models;
using System.Linq;

namespace Contracts
{
    public interface IPurchaseOrderDetailRepository : IRepositoryBase<TblPurchaseOrderDetails>
    {
        IQueryable<TblPurchaseOrderDetails> GetByOrderId(int id);
        IQueryable<TblPurchaseOrderDetails> GetByPendingReceivingReport(int id);
        TblPurchaseOrderDetails PostBill(int podetailId, int poid, double qty);
        TblPurchaseOrderDetails PostReceipt(int podetailId, int poid, double? newQty, double? originalQty);
    }
}
