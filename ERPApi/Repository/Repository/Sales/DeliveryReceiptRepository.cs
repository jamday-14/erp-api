using Contracts;
using Entities.Models;

namespace Services
{
    public class DeliveryReceiptRepository : RepositoryBase<TblDeliveryReceipts>, IDeliveryReceiptRepository
    {
        public DeliveryReceiptRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
