using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblOutletReturnDetails
    {
        public int Id { get; set; }
        public int OutletReturnId { get; set; }
        public int ItemId { get; set; }
        public double Qty { get; set; }
        public double QtyOnHand { get; set; }
        public double QtyOutletOnHand { get; set; }
        public int WarehouseId { get; set; }
        public int? UnitId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public double? SubTotal { get; set; }
        public int? Drid { get; set; }
        public int? DrdetailId { get; set; }
        public string DrrefNo { get; set; }
        public string Remarks { get; set; }
    }
}
