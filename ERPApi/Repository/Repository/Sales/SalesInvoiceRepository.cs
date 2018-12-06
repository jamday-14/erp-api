using Contracts;
using Entities.Models;

namespace Services
{
    public class SalesInvoiceRepository : RepositoryBase<TblSalesInvoices>, ISalesInvoiceRepository
    {
        public SalesInvoiceRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
