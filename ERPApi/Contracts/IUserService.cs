using Entities.Response;
using System.Collections.Generic;

namespace Contracts
{
    public interface IUserService
    {
        ICompanyRepository Company { get; }
        IUserRepository User { get; }
        LoginResponse Login(string userName, string password);
        IList<string> GetSystemKeys(string username);
    }
}
