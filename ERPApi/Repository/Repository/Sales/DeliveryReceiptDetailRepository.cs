using Contracts;
using Entities.Models;

namespace Services
{
    public class DeliveryReceiptDetailRepository : RepositoryBase<TblDeliveryReceiptDetails>, IDeliveryReceiptDetailRepository
    {
        public DeliveryReceiptDetailRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
