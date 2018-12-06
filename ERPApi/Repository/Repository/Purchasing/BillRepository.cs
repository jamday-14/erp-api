using Contracts;
using Entities.Models;

namespace Services
{
    public class BillRepository : RepositoryBase<TblBills>, IBillRepository
    {
        public BillRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
