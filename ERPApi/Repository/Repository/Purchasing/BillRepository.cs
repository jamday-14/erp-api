using System.Linq;
using Contracts;
using Entities.Models;

namespace Services
{
    public class BillRepository : RepositoryBase<TblBills>, IBillRepository
    {
        public BillRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }

        public IQueryable<TblBills> GetAvailableByVendor(int vendorId)
        {
            var query = from invoices in RepositoryContext.TblBills
                        join details in RepositoryContext.TblBillDetails on invoices.Id equals details.BillId
                        where invoices.VendorId == vendorId && details.Qty > details.QtyReturn
                        && !invoices.Closed && !details.Closed
                        select invoices;

            return query.Distinct().OrderByDescending(x => x.Date);
        }

        public IQueryable<TblBills> GetByVendor(int vendorId)
        {
            var query = from invoices in RepositoryContext.TblBills
                        join details in RepositoryContext.TblBillDetails on invoices.Id equals details.BillId
                        where invoices.VendorId == vendorId
                        && !invoices.Closed && !details.Closed
                        select invoices;

            return query.Distinct().OrderByDescending(x => x.Date);
        }

        public IQueryable<TblBills> GetForPaymentByVendor(int vendorId)
        {
            var query = from invoices in RepositoryContext.TblBills
                        where invoices.VendorId == vendorId && invoices.AmountDue > 0
                        && !invoices.Closed
                        select invoices;

            return query.Distinct().OrderByDescending(x => x.Date);
        }

        public void DeductAmount(int referenceId, decimal subTotal)
        {
            var data = RepositoryContext.TblBills.FirstOrDefault(x => x.Id == referenceId);

            data.ReturnAmount += subTotal;

        }
    }
}
