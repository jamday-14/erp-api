using Contracts;
using Entities.Models;

namespace Services
{
    public class SalesOrderDetailRepository : RepositoryBase<TblSalesOrderDetails>, ISalesOrderDetailRepository
    {
        public SalesOrderDetailRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
