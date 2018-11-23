using AutoMapper;
using Contracts;
using Entities.ExtendedModels;
using Entities.Models;
using Entities.Response;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class UserRepository : RepositoryBase<TblSecurityUsers>, IUserRepository
    {
        private readonly IMapper _mapper;
        public UserRepository(ERPContext repositoryContext, IMapper mapper) : base(repositoryContext)
        {
            _mapper = mapper;
        }

        public LoginResponse Login(string userName, string password)
        {
            password = $"{userName}{password}";

            var user = RepositoryContext.TblSecurityUsers
                .Where(x => x.LoginName == userName && x.Active == true)
                .DefaultIfEmpty(new TblSecurityUsers())
                .FirstOrDefault();

            if (!CryptoHelper.Crypto.VerifyHashedPassword(user.PasswordHash, password))
            {
                //Wrong Password
                user = new TblSecurityUsers();
            }

            var groups = RepositoryContext.TblSecurityUserSecurityGroups
                .Where(x => x.SecurityUserId == user.Id)
                .Select(x => x.SecurityGroup);

            return new LoginResponse
            {
                User = _mapper.Map<User>(user),
                UserGroups = _mapper.Map<List<UserGroup>>(groups.ToList())
            };
        }
    }
}
