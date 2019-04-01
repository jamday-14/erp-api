namespace Entities.ExtendedModels
{
    public class PurchaseOrderDetails
    {
        public int Id { get; set; }
        public int PurchaseOrderId { get; set; }
        public int ItemId { get; set; }
        public double Qty { get; set; }
        public double QtyReceived { get; set; }
        public double QtyBilled { get; set; }
        public double QtyOnHand { get; set; }
        public double QtyLeft { get; set; }
        public int? UnitId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public double? SubTotal { get; set; }
        public string Remarks { get; set; }
        public bool Closed { get; set; }
    }
}
