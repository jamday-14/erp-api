using Contracts;
using Entities.Models;

namespace Services
{
    public class PurchaseReturnDetailRepository : RepositoryBase<TblPurchaseReturnDetails>, IPurchaseReturnDetailRepository
    {
        public PurchaseReturnDetailRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
