using System.Linq;
using Contracts;
using Entities.Models;

namespace Services
{
    public class SalesInvoiceRepository : RepositoryBase<TblSalesInvoices>, ISalesInvoiceRepository
    {
        public SalesInvoiceRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }

        public IQueryable<TblSalesInvoices> GetAvailableByCustomer(int customerId)
        {
            var query = from invoices in RepositoryContext.TblSalesInvoices
                        join details in RepositoryContext.TblSalesInvoiceDetails on invoices.Id equals details.SalesInvoiceId
                        where invoices.CustomerId == customerId && details.Qty > details.QtyReturn
                        && !invoices.Closed && !details.Closed
                        select invoices;

            return query.Distinct().OrderByDescending(x => x.Date);
        }

        public IQueryable<TblSalesInvoices> GetByCustomer(int customerId)
        {
            var query = from invoices in RepositoryContext.TblSalesInvoices
                        join details in RepositoryContext.TblSalesInvoiceDetails on invoices.Id equals details.SalesInvoiceId
                        where invoices.CustomerId == customerId
                        && !invoices.Closed && !details.Closed
                        select invoices;

            return query.Distinct().OrderByDescending(x => x.Date);
        }
    }
}
