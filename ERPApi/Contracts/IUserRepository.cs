using Entities.Models;
using Entities.Response;

namespace Contracts
{
    public interface IUserRepository : IRepositoryBase<TblSecurityUsers>
    {
        LoginResponse Login(string userName, string password);
    }
}
