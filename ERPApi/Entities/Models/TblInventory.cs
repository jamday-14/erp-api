using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblInventory
    {
        public int CompanyId { get; set; }
        public int WareHouseId { get; set; }
        public int ItemId { get; set; }
        public double Quantity { get; set; }
        public decimal TotalCost { get; set; }
        public decimal? AvgCost { get; set; }
    }
}
