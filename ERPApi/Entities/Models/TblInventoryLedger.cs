using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblInventoryLedger
    {
        public int CompanyId { get; set; }
        public int ItemId { get; set; }
        public DateTime Date { get; set; }
        public double TotalIn { get; set; }
        public double TotalOut { get; set; }
        public double EndQty { get; set; }
        public decimal TotalInCost { get; set; }
        public decimal TotalOutCost { get; set; }
        public decimal EndTotalCost { get; set; }

        public TblItems Item { get; set; }
    }
}
