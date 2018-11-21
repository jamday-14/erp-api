using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblGoodsTransferDetails
    {
        public int Id { get; set; }
        public int GoodsTransferId { get; set; }
        public int ItemId { get; set; }
        public double Qty { get; set; }
        public double QtyOnHand { get; set; }
        public double QtyReceived { get; set; }
        public double QtyLeft { get; set; }
        public int? UnitId { get; set; }
        public int? ReasonId { get; set; }
        public string Remarks { get; set; }
    }
}
