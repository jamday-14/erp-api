using System.Linq;
using Contracts;
using Entities.Models;

namespace Repository
{
    public class UserGroupRepository : RepositoryBase<TblSecurityGroups>, IUserGroupRepository
    {
        public UserGroupRepository(ERPContext repositoryContext) : base(repositoryContext)
        {

        }

        public IQueryable<TblSecurityGroups> GetByUserId(int userId)
        {
            return RepositoryContext.TblSecurityUserSecurityGroups
                .Where(x => x.SecurityUserId == userId)
                .Select(x => x.SecurityGroup);

        }

        public IQueryable<TblSecurityKeys> GetKeys(IQueryable<TblSecurityGroups> queryable)
        {
            return queryable.SelectMany(x => x.TblSecurityGroupSecurityKeys.Select(y => y.SecurityKey));
        }
    }
}
