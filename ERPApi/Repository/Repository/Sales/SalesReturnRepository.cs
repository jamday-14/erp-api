using Contracts;
using Entities.Models;

namespace Services
{
    public class SalesReturnRepository : RepositoryBase<TblSalesReturns>, ISalesReturnRepository
    {
        public SalesReturnRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
