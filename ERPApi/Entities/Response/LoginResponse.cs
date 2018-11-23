using Entities.ExtendedModels;
using System.Collections.Generic;

namespace Entities.Response
{
    public class LoginResponse
    {
        public User User { get; set; }
        public List<UserGroup> UserGroups { get; set; }

    }
}
