using Entities.Models;

namespace Contracts
{
    public interface IUserRepository : IRepositoryBase<TblSecurityUsers>
    {
        TblSecurityUsers FindByLoginName(string userName);
    }
}
