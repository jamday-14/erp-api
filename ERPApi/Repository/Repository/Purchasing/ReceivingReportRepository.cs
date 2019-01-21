using Contracts;
using Entities.Models;
using System.Linq;

namespace Services
{
    class ReceivingReportRepository : RepositoryBase<TblReceivingReport>, IReceivingReportRepository
    {
        public ReceivingReportRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }

        public object GetByVendor(int vendorId)
        {
            var query = from receipts in RepositoryContext.TblReceivingReports
                        join details in RepositoryContext.TblReceivingReportDetails on receipts.Id equals details.ReceivingReportId
                        where receipts.VendorId == vendorId
                        && !receipts.Closed && !details.Closed
                        select receipts;

            return query.Distinct().OrderByDescending(x => x.Date);
        }

        public object GetPendingByVendor(int vendorId)
        {
            var query = from receipts in RepositoryContext.TblReceivingReports
                        join details in RepositoryContext.TblReceivingReportDetails on receipts.Id equals details.ReceivingReportId
                        where receipts.VendorId == vendorId && details.QtyBill < (details.Qty - details.QtyReturn)
                        && !receipts.Closed && !details.Closed
                        select receipts;

            return query.Distinct().OrderByDescending(x => x.Date);
        }
    }
}
