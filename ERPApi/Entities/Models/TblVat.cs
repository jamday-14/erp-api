using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblVat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Rate { get; set; }
        public bool? Active { get; set; }
    }
}
