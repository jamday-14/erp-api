using Entities.Models;
using System.Linq;

namespace Contracts
{
    public interface ISalesInvoiceRepository : IRepositoryBase<TblSalesInvoices>
    {
        IQueryable<TblSalesInvoices> GetByCustomer(int customerId);
        IQueryable<TblSalesInvoices> GetAvailableByCustomer(int customerId);
    }
}
