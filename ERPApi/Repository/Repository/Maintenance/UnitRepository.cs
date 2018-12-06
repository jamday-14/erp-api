using Contracts;
using Entities.Models;

namespace Services
{
    public class UnitRepository : RepositoryBase<TblUnits>, IUnitRepository
    {
        public UnitRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
