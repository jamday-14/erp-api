using Contracts;
using Entities.Models;

namespace Services
{
    public class EmployeeRepository : RepositoryBase<TblEmployees>, IEmployeeRepository
    {
        public EmployeeRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
