using System.Linq;
using Contracts;
using Entities.Models;

namespace Services
{
    public class DeliveryReceiptRepository : RepositoryBase<TblDeliveryReceipts>, IDeliveryReceiptRepository
    {
        public DeliveryReceiptRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }

        public IQueryable<TblDeliveryReceiptDetails> GetDetails(int id)
        {
            return RepositoryContext.TblDeliveryReceiptDetails.Where(x => x.DeliveryReceiptId == id);
        }

        public IQueryable<TblDeliveryReceipts> GetPendingByCustomer(int customerId)
        {
            return RepositoryContext.TblDeliveryReceipts.Where(x => x.CustomerId == customerId && !x.Closed);
        }
    }
}
