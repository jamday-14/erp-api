using Contracts;
using Entities.Models;

namespace Services
{
    public class ReasonForInventoryAdjustmentRepository : RepositoryBase<TblReasonForInventoryAdjustments>, IReasonForInventoryAdjustmentRepository
    {
        public ReasonForInventoryAdjustmentRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
