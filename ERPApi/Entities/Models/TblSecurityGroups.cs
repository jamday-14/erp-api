﻿using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblSecurityGroups
    {
        public TblSecurityGroups()
        {
            TblSecurityGroupSecurityKeys = new HashSet<TblSecurityGroupSecurityKeys>();
            TblSecurityUserSecurityGroups = new HashSet<TblSecurityUserSecurityGroups>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? ModifiedById { get; set; }
        public DateTime? ModificationDate { get; set; }

        public ICollection<TblSecurityGroupSecurityKeys> TblSecurityGroupSecurityKeys { get; set; }
        public ICollection<TblSecurityUserSecurityGroups> TblSecurityUserSecurityGroups { get; set; }
    }
}
