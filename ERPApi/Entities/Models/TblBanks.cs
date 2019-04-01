using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblBanks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? Active { get; set; }
    }
}
