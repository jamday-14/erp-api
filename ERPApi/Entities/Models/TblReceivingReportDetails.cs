using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblReceivingReportDetails
    {
        public int Id { get; set; }
        public int ReceivingReportId { get; set; }
        public int ItemId { get; set; }
        public double Qty { get; set; }
        public double QtyOnHand { get; set; }
        public double QtyReturn { get; set; }
        public double QtyBill { get; set; }
        public int? UnitId { get; set; }
        public int WarehouseId { get; set; }
        public int? Poid { get; set; }
        public int? PodetailId { get; set; }
        public string PorefNo { get; set; }
        public string Remarks { get; set; }
        public bool Closed { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? Discount { get; set; }
        public double? SubTotal { get; set; }
    }
}
