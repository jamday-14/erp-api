using AutoMapper;
using Contracts;
using Entities.Models;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ERPContext _repoContext;
        private readonly IMapper _mapper;

        private ICompanyRepository _company;
        private IUserRepository _user;

        public RepositoryWrapper(ERPContext repositoryContext, IMapper mapper)
        {
            _repoContext = repositoryContext;
            _mapper = mapper;
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

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext, _mapper);
                }
                return _user;
            }
        }
    }
}
