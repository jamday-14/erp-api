using Contracts;
using Entities.Models;

namespace Repository
{
    public class CompanyRepository : RepositoryBase<TblCompanies>, ICompanyRepository
    {
        public CompanyRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
