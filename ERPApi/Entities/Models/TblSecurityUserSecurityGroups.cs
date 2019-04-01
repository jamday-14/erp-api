using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblSecurityUserSecurityGroups
    {
        public int Id { get; set; }
        public int SecurityUserId { get; set; }
        public int SecurityGroupId { get; set; }

        public TblSecurityGroups SecurityGroup { get; set; }
        public TblSecurityUsers SecurityUser { get; set; }
    }
}
