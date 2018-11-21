using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblSecurityKeys
    {
        public int Id { get; set; }
        public string SecurityKey { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
        public int EditionId { get; set; }
        public int? CheckSum { get; set; }
        public bool? Active { get; set; }
        public double? Order { get; set; }
    }
}
