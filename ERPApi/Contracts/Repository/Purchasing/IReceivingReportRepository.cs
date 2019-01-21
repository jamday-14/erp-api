using Entities.Models;

namespace Contracts
{
    public interface IReceivingReportRepository : IRepositoryBase<TblReceivingReports>
    {
        object GetPendingByVendor(int vendorId);
        object GetByVendor(int vendorId);
    }
}
