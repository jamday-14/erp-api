using Contracts;
using Entities.Models;
using System.Linq;

namespace Services
{
    public class GoodsTransferReceivedDetailRepository : RepositoryBase<TblGoodsTransferReceivedDetails>, IGoodsTransferReceivedDetailRepository
    {
        public GoodsTransferReceivedDetailRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }

        public IQueryable<TblGoodsTransferReceivedDetails> GetByGoodsTransferReceivedId(int id)
        {
            return RepositoryContext.TblGoodsTransferReceivedDetails.Where(x => x.GoodTransferReceivedId == id)
                   .OrderBy(x => x.Id);
        }
    }
}
