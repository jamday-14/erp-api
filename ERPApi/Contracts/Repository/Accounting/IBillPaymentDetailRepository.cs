using Entities.Models;
using System.Linq;

namespace Contracts
{
    public interface IBillPaymentDetailRepository : IRepositoryBase<TblBillPaymentDetails>
    {
        IQueryable<TblBillPaymentDetails> GetByBillPaymentId(int id);
    }
}
