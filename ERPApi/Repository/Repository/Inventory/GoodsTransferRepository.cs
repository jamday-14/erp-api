using System.Linq;
using Contracts;
using Entities.Models;

namespace Services
{
    public class GoodsTransferRepository : RepositoryBase<TblGoodsTransfers>, IGoodsTransferRepository
    {
        public GoodsTransferRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }

        public IQueryable<TblGoodsTransfers> GetPendingByWarehouse(int warehouseId)
        {
            var query = from receipts in RepositoryContext.TblGoodsTransfers
                        join details in RepositoryContext.TblGoodsTransferDetails on receipts.Id equals details.GoodsTransferId
                        where receipts.ToWarehouseId == warehouseId && details.QtyReceived < details.Qty
                        select receipts;

            return query.Distinct().OrderByDescending(x => x.Date);
        }
    }
}
