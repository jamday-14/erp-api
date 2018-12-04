using Entities.Response;
using System.Collections.Generic;

namespace Contracts
{
    public interface IUserService
    {
        ICompanyRepository CompanyRepo { get; }
        IUserRepository UserRepo { get; }
        LoginResponse Login(string userName, string password);
        IList<string> GetSystemKeys(string username);
    }
}
