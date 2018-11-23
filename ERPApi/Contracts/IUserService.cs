using Entities.Response;

namespace Contracts
{
    public interface IUserService
    {
        ICompanyRepository Company { get; }
        IUserRepository User { get; }
        LoginResponse Login(string userName, string password);
    }
}
