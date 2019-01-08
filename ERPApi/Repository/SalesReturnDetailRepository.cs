using Contracts;
using Entities.Models;

namespace Services
{
    public class SalesReturnDetailRepository : RepositoryBase<TblSalesReturnDetails>, ISalesReturnDetailRepository
    {
        public SalesReturnDetailRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
