using Contracts;
using Entities.Models;

namespace Services
{
    public class DeliveryReceiptRepository : RepositoryBase<TblDeliveryReceiptDetails>, IDeliveryReceiptRepository
    {
        public DeliveryReceiptRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
