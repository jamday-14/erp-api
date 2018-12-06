using Contracts;
using Entities.Models;

namespace Services
{
    public class PurchaseOrderRepository : RepositoryBase<TblPurchaseOrders>, IPurchaseOrderRepository
    {
        public PurchaseOrderRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
