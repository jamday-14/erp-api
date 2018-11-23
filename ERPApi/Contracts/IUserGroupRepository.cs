using Entities.Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface IUserGroupRepository : IRepositoryBase<TblSecurityGroups>
    {
        IEnumerable<TblSecurityGroups> GetByUserId(int userId);
    }
}
