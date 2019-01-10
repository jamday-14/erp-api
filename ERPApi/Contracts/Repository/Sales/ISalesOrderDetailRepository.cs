using Entities.Models;
using System.Linq;

namespace Contracts
{
    public interface ISalesOrderDetailRepository : IRepositoryBase<TblSalesOrderDetails>
    {
        IQueryable<TblSalesOrderDetails> GetByOrderId(int id);
        IQueryable<TblSalesOrderDetails> GetByPendingDeliveryReceipt(int id);
    }
}
