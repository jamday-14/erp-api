using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblSeries
    {
        public string Code { get; set; }
        public int NextNumber { get; set; }
        public string NumberFormat { get; set; }
    }
}
