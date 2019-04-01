using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblSubsidiaryLedger
    {
        public int SubsidiaryId { get; set; }
        public int AccountId { get; set; }
        public int CompanyId { get; set; }
        public DateTime Date { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal EndBalance { get; set; }
    }
}
