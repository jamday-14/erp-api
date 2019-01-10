using System.Linq;
using Contracts;
using Entities.Models;

namespace Services
{
    public class SalesOrderRepository : RepositoryBase<TblSalesOrders>, ISalesOrderRepository
    {
        public SalesOrderRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }

        public IQueryable<TblSalesOrders> GetPendingByCustomer(int customerId)
        {
            var query = from orders in RepositoryContext.TblSalesOrders
                        join details in RepositoryContext.TblSalesOrderDetails on orders.Id equals details.SalesOrderId
                        where orders.CustomerId == customerId && details.QtyDr < details.Qty 
                        && !orders.Closed && !details.Closed
                        select orders;

            return query.Distinct();
        }
    }
}
