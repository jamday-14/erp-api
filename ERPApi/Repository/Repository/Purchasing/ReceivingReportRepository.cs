using Contracts;
using Entities.Models;

namespace Services
{
    class ReceivingReportRepository : RepositoryBase<TblReceivingReportDetails>, IReceivingReportRepository
    {
        public ReceivingReportRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
