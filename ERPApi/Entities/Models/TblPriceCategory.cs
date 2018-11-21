using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblPriceCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Percent { get; set; }
        public bool? Active { get; set; }
    }
}
