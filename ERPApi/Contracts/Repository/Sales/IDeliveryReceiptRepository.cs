using Entities.Models;
using System.Linq;

namespace Contracts
{
    public interface IDeliveryReceiptRepository : IRepositoryBase<TblDeliveryReceipts>
    {
        IQueryable<TblDeliveryReceipts> GetPendingByCustomer(int customerId);
        IQueryable<TblDeliveryReceipts> GetByCustomer(int customerId);
    }
}
