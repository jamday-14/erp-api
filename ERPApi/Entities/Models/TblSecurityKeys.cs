using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblSecurityKeys
    {
        public TblSecurityKeys()
        {
            TblSecurityGroupSecurityKeys = new HashSet<TblSecurityGroupSecurityKeys>();
            TblSecurityUserSecurityKeys = new HashSet<TblSecurityUserSecurityKeys>();
        }

        public int Id { get; set; }
        public string SecurityKey { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
        public int EditionId { get; set; }
        public int? CheckSum { get; set; }
        public bool? Active { get; set; }
        public double? Order { get; set; }

        public ICollection<TblSecurityGroupSecurityKeys> TblSecurityGroupSecurityKeys { get; set; }
        public ICollection<TblSecurityUserSecurityKeys> TblSecurityUserSecurityKeys { get; set; }
    }
}
