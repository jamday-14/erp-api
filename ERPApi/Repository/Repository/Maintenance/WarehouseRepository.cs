using Contracts;
using Entities.Models;

namespace Services
{
    public class WarehouseRepository : RepositoryBase<TblWarehouses>, IWarehouseRepository
    {
        public WarehouseRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
