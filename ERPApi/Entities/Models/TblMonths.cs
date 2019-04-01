using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblMonths
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Quarter { get; set; }
        public int? Qmorder { get; set; }
        public string Code { get; set; }
    }
}
