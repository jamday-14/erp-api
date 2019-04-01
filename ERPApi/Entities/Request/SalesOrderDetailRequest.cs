namespace Entities
{
    public class SalesOrderDetailRequest
    {
        public int ItemId { get; set; }
        public double Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public int? UnitId { get; set; }
        public string Remarks { get; set; }
        public double? QtyOnHand { get; set; }
    }
}
