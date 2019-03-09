using Entities.Models;

namespace Entities.ExtendedModels
{
    public class VendorItem
    {
        public int Id { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal CostPrice { get; set; }
        public int? UnitId { get; set; }
        public double? QtyOnHand { get; set; }
    }
}
