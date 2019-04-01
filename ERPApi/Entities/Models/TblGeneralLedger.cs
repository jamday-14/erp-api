using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblGeneralLedger
    {
        public int AccountId { get; set; }
        public DateTime Date { get; set; }
        public int CompanyId { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal EndBalance { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
