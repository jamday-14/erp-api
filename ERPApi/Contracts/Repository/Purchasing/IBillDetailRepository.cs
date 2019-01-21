using Entities.Models;
using System.Linq;

namespace Contracts
{
    public interface IBillDetailRepository : IRepositoryBase<TblBillDetails>
    {
        IQueryable<TblBillDetails> GetAvailableByBillId(int id);
        IQueryable<TblBillDetails> GetByBillId(int id);
    }
}
