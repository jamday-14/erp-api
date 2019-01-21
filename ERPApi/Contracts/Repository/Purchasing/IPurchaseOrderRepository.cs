using Entities.Models;
using System.Linq;

namespace Contracts
{
    public interface IPurchaseOrderRepository : IRepositoryBase<TblPurchaseOrders>
    {
        IQueryable<TblPurchaseOrders> GetPendingByVendor(int vendorId);
    }
}
