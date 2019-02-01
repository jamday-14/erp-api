using Entities.Models;
using System.Linq;

namespace Contracts
{
    public interface IGoodsTransferDetailRepository : IRepositoryBase<TblGoodsTransferDetails>
    {
        IQueryable<TblGoodsTransferDetails> GetByGoodsTransferId(int id);
    }
}
