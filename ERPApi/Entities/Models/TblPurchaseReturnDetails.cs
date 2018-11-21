using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblPurchaseReturnDetails
    {
        public int Id { get; set; }
        public int PurchaseReturnId { get; set; }
        public int ItemId { get; set; }
        public double Qty { get; set; }
        public double QtyOnHand { get; set; }
        public int WarehouseId { get; set; }
        public int? UnitId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public double? SubTotal { get; set; }
        public string Remarks { get; set; }
        public int? Rrid { get; set; }
        public int? RrdetailId { get; set; }
        public string RrrefNo { get; set; }
    }
}
