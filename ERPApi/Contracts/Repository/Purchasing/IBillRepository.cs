using Entities.Models;
using System.Linq;

namespace Contracts
{
    public interface IBillRepository : IRepositoryBase<TblBills>
    {
        IQueryable<TblBills> GetByVendor(int vendorId);
        IQueryable<TblBills> GetAvailableByVendor(int vendorId);
        IQueryable<TblBills> GetForPaymentByVendor(int vendorId);
        void DeductAmount(int referenceId, decimal subTotal);
    }
}
