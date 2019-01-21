using Contracts;
using Entities.Models;

namespace Services
{
    public class BillDetailRepository : RepositoryBase<TblBillDetails>, IBillDetailRepository
    {
        public BillDetailRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
