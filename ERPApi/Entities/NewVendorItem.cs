using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class NewVendorItem
    {
        [Required()]
        public int VendorId { get; set; }

        [Required()]
        public int ItemId { get; set; }

        [Required()]
        public decimal CostPrice { get; set; }

        public string Remarks { get; set; }
    }
}
