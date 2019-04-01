using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblAccountTypes
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool? IsIncome { get; set; }
        public string Name2 { get; set; }
        public int? Order { get; set; }
    }
}
