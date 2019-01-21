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
        public int? ReferenceId { get; set; }
        public int? ReferenceDetailId { get; set; }
        public string ReferenceNo { get; set; }
        public int? ReferenceTypeId { get; set; }
    }
}
