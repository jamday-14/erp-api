using System.Linq;
using Contracts;
using Entities.Models;

namespace Services
{
    public class BillDetailRepository : RepositoryBase<TblBillDetails>, IBillDetailRepository
    {
        public BillDetailRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }

        public IQueryable<TblBillDetails> GetAvailableByBillId(int id)
        {
            return RepositoryContext.TblBillDetails.Where(x => x.BillId == id && x.Qty > x.QtyReturn)
               .OrderBy(x => x.RrdetailId).ThenBy(x => x.Id);
        }

        public IQueryable<TblBillDetails> GetByBillId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
