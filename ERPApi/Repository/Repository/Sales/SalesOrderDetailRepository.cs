using Contracts;
using Entities.Models;
using System.Linq;

namespace Services
{
    public class SalesOrderDetailRepository : RepositoryBase<TblSalesOrderDetails>, ISalesOrderDetailRepository
    {
        public SalesOrderDetailRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }

        public IQueryable<TblSalesOrderDetails> GetByOrderId(int id)
        {
            return RepositoryContext.TblSalesOrderDetails.Where(x => x.SalesOrderId == id);
        }

        public IQueryable<TblSalesOrderDetails> GetByPendingDeliveryReceipt(int id)
        {
            return RepositoryContext.TblSalesOrderDetails.Where(x => x.SalesOrderId == id && x.QtyDr < x.Qty && !x.Closed);
        }
    }
}
