using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblOutletReturns
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string SystemNo { get; set; }
        public string RefNo { get; set; }
        public int CustomerId { get; set; }
        public string Remarks { get; set; }
        public int? PreparedById { get; set; }
        public int? ApprovedById { get; set; }
        public bool Void { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? LastEditedById { get; set; }
        public DateTime? LastEditedDate { get; set; }
        public int? CompanyId { get; set; }
        public int? Categoryid { get; set; }
        public double? Percent { get; set; }
    }
}
