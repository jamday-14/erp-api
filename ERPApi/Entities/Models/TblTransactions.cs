using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblTransactions
    {
        public int CompanyId { get; set; }
        public int TypeId { get; set; }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int LineNo { get; set; }
        public string Number { get; set; }
    }
}
