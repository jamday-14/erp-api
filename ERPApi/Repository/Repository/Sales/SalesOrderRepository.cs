using Contracts;
using Entities.Models;

namespace Services
{
    public class SalesOrderRepository : RepositoryBase<TblSalesOrders>, ISalesOrderRepository
    {
        public SalesOrderRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
