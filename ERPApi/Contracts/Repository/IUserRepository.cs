using Entities.Models;
using System.Linq;

namespace Contracts
{
    public interface IUserRepository : IRepositoryBase<TblSecurityUsers>
    {
        IQueryable<TblSecurityUsers> FindByLoginName(string userName);
        IQueryable<TblSecurityKeys> GetKeys(IQueryable<TblSecurityUsers> user);
    }
}
