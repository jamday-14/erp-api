using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblVendorItems
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public int ItemId { get; set; }
        public decimal CostPrice { get; set; }
        public string Remarks { get; set; }
    }
}
