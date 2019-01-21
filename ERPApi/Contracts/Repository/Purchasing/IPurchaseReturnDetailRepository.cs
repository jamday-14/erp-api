using Entities.Models;
using System.Linq;

namespace Contracts
{
    public interface IPurchaseReturnDetailRepository : IRepositoryBase<TblPurchaseReturnDetails>
    {
        IQueryable<TblPurchaseReturnDetails> GetByPurchaseReturnId(int id);
    }
}
