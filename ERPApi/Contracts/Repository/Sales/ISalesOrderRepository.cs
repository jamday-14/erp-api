using Entities.Models;
using System.Linq;

namespace Contracts
{
    public interface ISalesOrderRepository : IRepositoryBase<TblSalesOrders>
    {
        IQueryable<TblSalesOrders> GetPendingByCustomer(int customerId);
        IQueryable<TblSalesOrderDetails> GetDetails(int id);
    }
}
