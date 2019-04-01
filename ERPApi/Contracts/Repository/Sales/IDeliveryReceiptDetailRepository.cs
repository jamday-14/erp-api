using Entities.Models;
using System.Linq;

namespace Contracts
{
    public interface IDeliveryReceiptDetailRepository : IRepositoryBase<TblDeliveryReceiptDetails>
    {
        IQueryable<TblDeliveryReceiptDetails> GetByDeliveryReceiptId(int id);
        IQueryable<TblDeliveryReceiptDetails> GetByPendingInvoice(int id);
    }
}
