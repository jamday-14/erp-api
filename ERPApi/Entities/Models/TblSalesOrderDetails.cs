using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblSalesOrderDetails
    {
        public int Id { get; set; }
        public int SalesOrderId { get; set; }
        public int ItemId { get; set; }
        public double Qty { get; set; }
        public double QtyDr { get; set; }
        public double QtyInvoice { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public double? SubTotal { get; set; }
        public int? UnitId { get; set; }
        public string Remarks { get; set; }
        public bool Closed { get; set; }
        public double? QtyOnHand { get; set; }
    }
}
