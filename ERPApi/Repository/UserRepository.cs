using AutoMapper;
using Contracts;
using Entities.Models;
using System.Linq;

namespace Repository
{
    public class UserRepository : RepositoryBase<TblSecurityUsers>, IUserRepository
    {
        public UserRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
            
        }

        public TblSecurityUsers FindByLoginName(string userName)
        {
            return RepositoryContext.TblSecurityUsers.Where(x => x.LoginName == userName && x.Active == true)
                .DefaultIfEmpty(new TblSecurityUsers())
                .FirstOrDefault();
        }
    }
}
