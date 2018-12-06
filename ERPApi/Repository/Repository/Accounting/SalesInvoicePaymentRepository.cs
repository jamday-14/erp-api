using Contracts;
using Entities.Models;

namespace Services
{
    public class SalesInvoicePaymentRepository : RepositoryBase<TblSalesInvoicePayments>, ISalesInvoicePaymentRepository
    {
        public SalesInvoicePaymentRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
