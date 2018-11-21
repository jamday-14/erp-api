using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblJournalTypes
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string FormName { get; set; }
        public bool? Active { get; set; }
        public int? OrderNo { get; set; }
        public bool? IsReverse { get; set; }
    }
}
