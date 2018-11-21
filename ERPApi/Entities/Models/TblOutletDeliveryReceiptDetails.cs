using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblOutletDeliveryReceiptDetails
    {
        public int Id { get; set; }
        public int OutletDeliveryReceiptId { get; set; }
        public int ItemId { get; set; }
        public double Qty { get; set; }
        public double QtyInvoice { get; set; }
        public double QtyOnHand { get; set; }
        public double QtyReturn { get; set; }
        public decimal UnitPrice { get; set; }
        public int? UnitId { get; set; }
        public decimal Discount { get; set; }
        public double? SubTotal { get; set; }
        public int WarehouseId { get; set; }
        public string Remarks { get; set; }
        public int? Soid { get; set; }
        public int? SodetailId { get; set; }
        public string SorefNo { get; set; }
        public bool Closed { get; set; }
        public double? QtyOutletOnHand { get; set; }
    }
}
