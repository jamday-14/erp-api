using Entities.Models;
using System.Linq;

namespace Contracts
{
    public interface IReceivingReportDetailRepository : IRepositoryBase<TblReceivingReportDetails>
    {
        IQueryable<TblReceivingReportDetails> GetByReceivingReportId(int id);
        IQueryable<TblReceivingReportDetails> GetByPendingInvoice(int id);
        TblReceivingReportDetails Return(int rrdetailId, int rrid, double qty);
        TblReceivingReportDetails PostBill(int rrdetailId, int rrid, double? newQty, double? originalQty);

    }
}
