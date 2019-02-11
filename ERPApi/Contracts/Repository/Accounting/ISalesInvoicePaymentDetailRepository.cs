using Entities.Models;
using System.Linq;

namespace Contracts
{
    public interface ISalesInvoicePaymentDetailRepository : IRepositoryBase<TblSalesInvoicePaymentDetails>
    {
        IQueryable<TblSalesInvoicePaymentDetails> GetBySalesInvoicePaymentId(int id);
    }
}
