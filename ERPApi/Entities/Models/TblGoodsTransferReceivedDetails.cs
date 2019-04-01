using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblGoodsTransferReceivedDetails
    {
        public int Id { get; set; }
        public int GoodTransferReceivedId { get; set; }
        public int ItemId { get; set; }
        public double Qty { get; set; }
        public double QtyOnHand { get; set; }
        public int? UnitId { get; set; }
        public string Remarks { get; set; }
        public int Gtid { get; set; }
        public int GtdetailId { get; set; }
        public string GtrefNo { get; set; }
    }
}
