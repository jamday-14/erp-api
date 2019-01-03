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

        public IQueryable<TblSalesOrderDetails> GetDetails(int id)
        {
            return RepositoryContext.TblSalesOrderDetails.Where(x => x.SalesOrderId == id);
        }

        public IQueryable<TblSalesOrders> GetPendingByCustomer(int customerId)
        {
            return RepositoryContext.TblSalesOrders.Where(x => x.CustomerId == customerId && !x.Closed);
        }
    }
}
