using Entities.Models;
using System.Linq;

namespace Contracts
{
    public interface IUserGroupRepository : IRepositoryBase<TblSecurityGroups>
    {
        IQueryable<TblSecurityGroups> GetByUserId(int userId);
        IQueryable<TblSecurityKeys> GetKeys(IQueryable<TblSecurityGroups> queryable);
    }
}
