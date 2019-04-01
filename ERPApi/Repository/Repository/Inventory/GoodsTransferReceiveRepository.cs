using Contracts;
using Entities.Models;

namespace Services
{
    public class GoodsTransferReceiveRepository : RepositoryBase<TblGoodsTransferReceived>, IGoodsTransferReceiveRepository
    {
        public GoodsTransferReceiveRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
