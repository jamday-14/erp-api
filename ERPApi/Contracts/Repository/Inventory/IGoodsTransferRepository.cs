using Entities.Models;
using System.Linq;

namespace Contracts
{
    public interface IGoodsTransferRepository : IRepositoryBase<TblGoodsTransfers>
    {
        IQueryable<TblGoodsTransfers> GetPendingByWarehouse(int warehouseId);
    }
}
