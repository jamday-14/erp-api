using Entities.Models;
using System.Linq;

namespace Contracts
{
    public interface ISalesInvoiceDetailRepository : IRepositoryBase<TblSalesInvoiceDetails>
    {
        IQueryable<TblSalesInvoiceDetails> GetByInvoiceId(int id);
        IQueryable<TblSalesInvoiceDetails> GetAvailableByInvoiceId(int id);
    }
}
