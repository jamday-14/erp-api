using Entities.Models;
using System.Linq;

namespace Contracts
{
    public interface IReceivingReportDetailRepository : IRepositoryBase<TblReceivingReportDetails>
    {
        IQueryable<TblReceivingReportDetails> GetByReceivingReportId(int id);
        IQueryable<TblReceivingReportDetails> GetByPendingInvoice(int id);
    }
}
