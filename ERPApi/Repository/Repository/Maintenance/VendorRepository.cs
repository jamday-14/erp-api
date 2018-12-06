using Contracts;
using Entities.Models;

namespace Services
{
    public class VendorRepository : RepositoryBase<TblVendor>, IVendorRepository
    {
        public VendorRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
