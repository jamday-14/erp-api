using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblBillDetails
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public int ItemId { get; set; }
        public double Quantity { get; set; }
        public double QtyOnHand { get; set; }
        public int? UnitId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal SubTotal { get; set; }
        public string Remarks { get; set; }
        public bool Closed { get; set; }
        public int? Rrid { get; set; }
        public int? RrdetailId { get; set; }
        public string RrrefNo { get; set; }
    }
}
