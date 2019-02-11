using System.Linq;
using Contracts;
using Entities.Models;

namespace Services
{
    class SalesInvoicePaymentDetailRepository : RepositoryBase<TblSalesInvoicePaymentDetails>, ISalesInvoicePaymentDetailRepository
    {
        public SalesInvoicePaymentDetailRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }

        public IQueryable<TblSalesInvoicePaymentDetails> GetBySalesInvoicePaymentId(int id)
        {
            return RepositoryContext.TblSalesInvoicePaymentDetails.Where(x => x.SalesInvoicePaymentId == id)
                .OrderBy(x => x.Id);
        }
    }
}
