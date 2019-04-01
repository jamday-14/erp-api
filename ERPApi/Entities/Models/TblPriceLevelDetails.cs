using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblPriceLevelDetails
    {
        public int Id { get; set; }
        public int PriceLevelId { get; set; }
        public int ItemId { get; set; }
        public decimal UnitPrice { get; set; }
        public string Remarks { get; set; }
        public int CompanyId { get; set; }
    }
}
