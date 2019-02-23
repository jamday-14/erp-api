using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblItems
    {
        public int Id { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal CostPrice { get; set; }
        public int? UnitId { get; set; }
        public bool Ipurchased { get; set; }
        public bool IsForSale { get; set; }
        public bool IsInventory { get; set; }
        public bool Active { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? LastEditedById { get; set; }
        public DateTime? LastEditedDate { get; set; }
        public int? CompanyId { get; set; }
        public double? Quantity { get; set; }
        public bool? IsImported { get; set; }
        public decimal? RmbcostPrice { get; set; }
        public decimal? UsdcostPrice { get; set; }
    }
}
