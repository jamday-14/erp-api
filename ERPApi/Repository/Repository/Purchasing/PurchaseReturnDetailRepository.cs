using System.Linq;
using Contracts;
using Entities.Models;

namespace Services
{
    public class PurchaseReturnDetailRepository : RepositoryBase<TblPurchaseReturnDetails>, IPurchaseReturnDetailRepository
    {
        public PurchaseReturnDetailRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }

        public IQueryable<TblPurchaseReturnDetails> GetByPurchaseReturnId(int id)
        {
            return RepositoryContext.TblPurchaseReturnDetails.Where(x => x.PurchaseReturnId == id)
                .OrderBy(x => x.ReferenceDetailId).ThenBy(x => x.Id);
        }
    }
}
