using Entities.Models;
using System.Linq;

namespace Contracts
{
    public interface ISalesReturnDetailRepository : IRepositoryBase<TblSalesReturnDetails>
    {
        IQueryable<TblSalesReturnDetails> GetBySalesReturnId(int id);
    }
}
