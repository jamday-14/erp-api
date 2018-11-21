using Contracts;
using Entities.Models;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ERPContext _repoContext;
        private ICompanyRepository _company;

        public RepositoryWrapper(ERPContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public ICompanyRepository Company
        {
            get
            {
                if (_company == null)
                {
                    _company = new CompanyRepository(_repoContext);
                }
                return _company;
            }
        }
    }
}
