using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblPaymentAdjustmentTypes
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? AccountId { get; set; }
        public bool? Active { get; set; }
        public bool ForAr { get; set; }
        public bool ForAp { get; set; }
        public string Remarks { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? LastEditedById { get; set; }
        public DateTime? LastEditedDate { get; set; }
    }
}
