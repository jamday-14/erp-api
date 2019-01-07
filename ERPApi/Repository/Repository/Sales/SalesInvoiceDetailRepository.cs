using Contracts;
using Entities.Models;

namespace Services
{
    public class SalesInvoiceDetailRepository : RepositoryBase<TblSalesInvoiceDetails>, ISalesInvoiceDetailRepository
    {
        public SalesInvoiceDetailRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
