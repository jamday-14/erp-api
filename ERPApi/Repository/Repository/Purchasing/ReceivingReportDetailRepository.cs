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

        public TblReceivingReportDetails PostBill(int rrdetailId, int rrid, double? newQty, double? originalQty)
        {
            TblReceivingReportDetails detail = Find(rrdetailId, rrid);

            if (originalQty.HasValue)
                detail.QtyBill -= originalQty.Value;
            if (newQty.HasValue)
                detail.QtyBill += newQty.Value;

            detail.Closed = detail.Qty - (detail.QtyBill + detail.QtyReturn) == 0;

            return detail;
        }

        public TblReceivingReportDetails Return(int rrdetailId, int rrid, double qty)
        {
            TblReceivingReportDetails detail = Find(rrdetailId, rrid);
            detail.QtyReturn += qty;
            detail.Closed = detail.Qty - (detail.QtyBill + detail.QtyReturn) == 0;

            return detail;
        }

        private TblReceivingReportDetails Find(int rrdetailId, int rrid)
        {
            return RepositoryContext.TblReceivingReportDetails.Where(x => x.Id == rrdetailId && x.ReceivingReportId == rrid).FirstOrDefault();
        }
    }
}
