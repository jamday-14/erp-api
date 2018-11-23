using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblSecurityUsers
    {
        public TblSecurityUsers()
        {
            TblSecurityUserSecurityGroups = new HashSet<TblSecurityUserSecurityGroups>();
            TblSecurityUserSecurityKeys = new HashSet<TblSecurityUserSecurityKeys>();
        }

        public int Id { get; set; }
        public string LoginName { get; set; }
        public string PasswordHash { get; set; }
        public bool? Active { get; set; }
        public bool UserCantChangePassword { get; set; }
        public bool? PasswordNeverExpires { get; set; }
        public bool UserChangePasswordNextLogon { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? ModifiedById { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string UserName { get; set; }
        public int? SecurityUserLevelId { get; set; }
        public int? SecurityUserGroupId { get; set; }
        public DateTime? PasswordDate { get; set; }
        public int? BranchId { get; set; }

        public ICollection<TblSecurityUserSecurityGroups> TblSecurityUserSecurityGroups { get; set; }
        public ICollection<TblSecurityUserSecurityKeys> TblSecurityUserSecurityKeys { get; set; }
    }
}
