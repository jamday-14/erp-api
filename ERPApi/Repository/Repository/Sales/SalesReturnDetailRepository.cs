using Contracts;
using Entities.Models;
using System.Linq;

namespace Services
{
    public class SalesReturnDetailRepository : RepositoryBase<TblSalesReturnDetails>, ISalesReturnDetailRepository
    {
        public SalesReturnDetailRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
            
        }

        public IQueryable<TblSalesReturnDetails> GetBySalesReturnId(int id)
        {
            return RepositoryContext.TblSalesReturnDetails.Where(x => x.SalesReturnId == id);
        }
    }
}
