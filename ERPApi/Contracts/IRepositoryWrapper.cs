using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        ICompanyRepository Company { get; }
        IUserRepository User { get; }
    }
}
