using Entities.Models;
using System.Linq;

namespace Contracts
{
    public interface IGoodsTransferReceivedDetailRepository : IRepositoryBase<TblGoodsTransferReceivedDetails>
    {
        IQueryable<TblGoodsTransferReceivedDetails> GetByGoodsTransferReceivedId(int id);
    }
}
