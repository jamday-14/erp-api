using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblSecurityGroupSecurityKeys
    {
        public int Id { get; set; }
        public int? SecurityGroupId { get; set; }
        public int? SecurityKeyId { get; set; }
    }
}
