using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblTransactionDetails
    {
        public int CompanyId { get; set; }
        public int TypeId { get; set; }
        public int Id { get; set; }
        public int DetailId { get; set; }
        public int WarehouseId { get; set; }
        public int ItemId { get; set; }
        public double Quantity { get; set; }
        public double EndQty { get; set; }
        public double BegQty { get; set; }
        public double QtyIn { get; set; }
        public double? QtyOut { get; set; }
        public double? WarehouseEndQty { get; set; }
        public double? WarehouseBegQty { get; set; }
    }
}
