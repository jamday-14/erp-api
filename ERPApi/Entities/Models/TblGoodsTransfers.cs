using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblGoodsTransfers
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string SystemNo { get; set; }
        public string RefNo { get; set; }
        public int FromWarehouseId { get; set; }
        public int ToWarehouseId { get; set; }
        public string Description { get; set; }
        public int? PreparedById { get; set; }
        public int? ApprovedById { get; set; }
        public bool Received { get; set; }
        public bool Void { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? LastEditedById { get; set; }
        public DateTime? LastEditedDate { get; set; }
        public int? CompanyId { get; set; }
        public DateTime? DateVoided { get; set; }
        public int? VoidedById { get; set; }
        public double Closed { get; set; }
    }
}
