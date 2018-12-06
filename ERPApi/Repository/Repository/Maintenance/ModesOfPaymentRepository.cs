using Contracts;
using Entities.Models;

namespace Services
{
    public class ModesOfPaymentRepository : RepositoryBase<TblMop>, IModesOfPaymentRepository
    {
        public ModesOfPaymentRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
