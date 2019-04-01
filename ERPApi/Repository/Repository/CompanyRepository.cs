using Contracts;
using Entities.Models;

namespace Services
{
    public class CompanyRepository : RepositoryBase<TblCompanies>, ICompanyRepository
    {
        public CompanyRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
