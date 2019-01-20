using Contracts;
using Entities.Models;

namespace Services
{
    class ReceivingReportRepository : RepositoryBase<TblReceivingReport>, IReceivingReportRepository
    {
        public ReceivingReportRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
