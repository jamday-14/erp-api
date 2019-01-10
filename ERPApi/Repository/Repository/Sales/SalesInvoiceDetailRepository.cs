using System.Linq;
using Contracts;
using Entities.Models;

namespace Services
{
    public class SalesInvoiceDetailRepository : RepositoryBase<TblSalesInvoiceDetails>, ISalesInvoiceDetailRepository
    {
        public SalesInvoiceDetailRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }

        public IQueryable<TblSalesInvoiceDetails> GetByInvoiceId(int id)
        {
            return RepositoryContext.TblSalesInvoiceDetails.Where(x => x.SalesInvoiceId == id);
        }
    }
}
