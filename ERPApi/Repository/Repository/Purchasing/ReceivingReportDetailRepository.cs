using System.Linq;
using Contracts;
using Entities.Models;

namespace Services
{
    public class ReceivingReportDetailRepository : RepositoryBase<TblReceivingReportDetails>, IReceivingReportDetailRepository
    {
        public ReceivingReportDetailRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }

        public IQueryable<TblReceivingReportDetails> GetByPendingInvoice(int id)
        {
            return RepositoryContext.TblReceivingReportDetails
                .Where(x => x.ReceivingReportId == id && x.QtyBill < (x.Qty - x.QtyReturn) && !x.Closed)
                .OrderBy(x => x.PodetailId).ThenBy(x => x.Id);
        }

        public IQueryable<TblReceivingReportDetails> GetByReceivingReportId(int id)
        {
            return RepositoryContext.TblReceivingReportDetails.Where(x => x.ReceivingReportId == id)
                .OrderBy(x => x.PodetailId).ThenBy(x => x.Id);
        }
    }
}
