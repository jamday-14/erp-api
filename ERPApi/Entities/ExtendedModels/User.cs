namespace Entities.ExtendedModels
{
    public class User
    {
        public int Id { get; set; }
        public string LoginName { get; set; }
        public bool UserCantChangePassword { get; set; }
        public bool? PasswordNeverExpires { get; set; }
        public bool UserChangePasswordNextLogon { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string UserName { get; set; }
    }
}
