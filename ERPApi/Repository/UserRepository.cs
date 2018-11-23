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

        public IQueryable<TblSecurityUsers> FindByLoginName(string userName)
        {
            return RepositoryContext.TblSecurityUsers.Where(x => x.LoginName == userName && x.Active == true);
        }

        public IQueryable<TblSecurityKeys> GetKeys(IQueryable<TblSecurityUsers> user)
        {
            return user.SelectMany(x => x.TblSecurityUserSecurityKeys.Select(y => y.SecurityKey));
        }
    }
}
