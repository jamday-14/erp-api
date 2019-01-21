using Entities.Models;

namespace Contracts
{
    public interface IReceivingReportRepository : IRepositoryBase<TblReceivingReport>
    {
        object GetPendingByVendor(int vendorId);
        object GetByVendor(int vendorId);
    }
}
