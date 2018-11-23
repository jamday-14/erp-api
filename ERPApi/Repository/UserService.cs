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

        private ICompanyRepository _company;
        private IUserRepository _user;
        private IUserGroupRepository _usergroup;

        public UserService(ERPContext repositoryContext, IMapper mapper)
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
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }

        public IUserGroupRepository UserGroup
        {
            get
            {
                if (_usergroup == null)
                {
                    _usergroup = new UserGroupRepository(_repoContext);
                }
                return _usergroup;
            }
        }

        public LoginResponse Login(string userName, string password)
        {
            password = $"{userName}{password}";

            var user = User.FindByLoginName(userName).FirstOrDefault();

            if (!CryptoHelper.Crypto.VerifyHashedPassword(user.PasswordHash, password))
            {
                //Wrong Password
                user = new TblSecurityUsers();
            }

            var groups = UserGroup.GetByUserId(user.Id);

            return new LoginResponse
            {
                User = _mapper.Map<User>(user),
                UserGroups = _mapper.Map<List<UserGroup>>(groups.ToList())
            };
        }

        public IList<string> GetSystemKeys(string username)
        {
            var user = User.FindByLoginName(username);

            var groupKeys = UserGroup.GetKeys(UserGroup.GetByUserId(user.FirstOrDefault().Id)).Select(x => x.SecurityKey).ToList();

            var userKeys = User.GetKeys(user).Select(x => x.SecurityKey).ToList();

            groupKeys.AddRange(userKeys);

            return groupKeys.Distinct().ToList();
        }
    }
}
