using AutoMapper;
using Contracts;
using Entities.ExtendedModels;
using Entities.Models;
using Entities.Response;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class UserService : IUserService
    {
        private ERPContext _repoContext;
        private readonly IMapper _mapper;

        private ICompanyRepository _companyRepo;
        private IUserRepository _userRepo;
        private IUserGroupRepository _usergroupRepo;

        public UserService(ERPContext repositoryContext, IMapper mapper)
        {
            _repoContext = repositoryContext;
            _mapper = mapper;
        }

        public ICompanyRepository CompanyRepo
        {
            get
            {
                if (_companyRepo == null)
                {
                    _companyRepo = new CompanyRepository(_repoContext);
                }
                return _companyRepo;
            }
        }

        public IUserRepository UserRepo
        {
            get
            {
                if (_userRepo == null)
                {
                    _userRepo = new UserRepository(_repoContext);
                }
                return _userRepo;
            }
        }

        public IUserGroupRepository UserGroupRepo
        {
            get
            {
                if (_usergroupRepo == null)
                {
                    _usergroupRepo = new UserGroupRepository(_repoContext);
                }
                return _usergroupRepo;
            }
        }

        public LoginResponse Login(string userName, string password)
        {
            password = $"{userName}{password}";

            var user = UserRepo.FindByLoginName(userName).FirstOrDefault();

            if (!CryptoHelper.Crypto.VerifyHashedPassword(user.PasswordHash, password))
            {
                //Wrong Password
                user = new TblSecurityUsers();
            }

            var groups = UserGroupRepo.GetByUserId(user.Id);

            return new LoginResponse
            {
                User = _mapper.Map<User>(user),
                UserGroups = _mapper.Map<List<UserGroup>>(groups.ToList())
            };
        }

        public IList<string> GetSystemKeys(string username)
        {
            var user = UserRepo.FindByLoginName(username);

            var userGroups = UserGroupRepo.GetByUserId(user.FirstOrDefault().Id);

            var groupKeys = UserGroupRepo.GetKeys(userGroups).Select(x => x.SecurityKey).ToList();

            var userKeys = UserRepo.GetKeys(user).Select(x => x.SecurityKey).ToList();

            groupKeys.AddRange(userKeys);

            return groupKeys.Distinct().ToList();
        }
    }
}
