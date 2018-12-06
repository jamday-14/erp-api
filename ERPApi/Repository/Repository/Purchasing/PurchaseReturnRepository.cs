using Contracts;
using Entities.Models;

namespace Services
{
    public class PurchaseReturnRepository : RepositoryBase<TblPurchaseReturns>, IPurchaseReturnRepository
    {
        public PurchaseReturnRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
