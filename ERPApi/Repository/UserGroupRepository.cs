using System.Collections.Generic;
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

        public IEnumerable<TblSecurityGroups> GetByUserId(int userId)
        {
            return RepositoryContext.TblSecurityUserSecurityGroups
                .Where(x => x.SecurityUserId == userId)
                .Select(x => x.SecurityGroup).AsEnumerable();

        }
    }
}
