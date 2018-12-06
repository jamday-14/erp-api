using Contracts;
using Entities.Models;

namespace Services
{
    public class GoodsTransferRepository : RepositoryBase<TblGoodsTransfers>, IGoodsTransferRepository
    {
        public GoodsTransferRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
