using Entities.Models;
using System.Linq;

namespace Contracts
{
    public interface IPurchaseOrderDetailRepository : IRepositoryBase<TblPurchaseOrderDetails>
    {
        IQueryable<TblPurchaseOrderDetails> GetByOrderId(int id);
        IQueryable<TblPurchaseOrderDetails> GetByPendingReceivingReport(int id);
    }
}
