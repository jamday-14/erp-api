using Contracts;
using Entities.Models;
using System.Linq;

namespace Services
{
    public class GoodsTransferDetailRepository : RepositoryBase<TblGoodsTransferDetails>, IGoodsTransferDetailRepository
    {
        public GoodsTransferDetailRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }

        public IQueryable<TblGoodsTransferDetails> GetByGoodsTransferId(int id)
        {
            return RepositoryContext.TblGoodsTransferDetails.Where(x => x.GoodsTransferId == id)
                   .OrderBy(x => x.Id);
        }

        public IQueryable<TblGoodsTransferDetails> GetByPendingReceipt(int id)
        {
            return RepositoryContext.TblGoodsTransferDetails
                .Where(x => x.GoodsTransferId == id && x.QtyReceived < x.Qty)
                .OrderBy(x => x.Id);
        }
    }
}
