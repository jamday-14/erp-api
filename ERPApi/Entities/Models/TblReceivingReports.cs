using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblReceivingReports
    {
        public int Id { get; set; }
        public string SystemNo { get; set; }
        public string RefNo { get; set; }
        public DateTime Date { get; set; }
        public int VendorId { get; set; }
        public int WarehouseId { get; set; }
        public string Comments { get; set; }
        public int? PreparedById { get; set; }
        public int? ReceivedById { get; set; }
        public int? ApprovedById { get; set; }
        public bool IsBill { get; set; }
        public bool IsReturn { get; set; }
        public bool Closed { get; set; }
        public bool Void { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? LastEditedById { get; set; }
        public DateTime? LastEditedDate { get; set; }
        public int? CompanyId { get; set; }
        public decimal? Amount { get; set; }
        public decimal? AmountPaid { get; set; }
        public decimal? AmountDue { get; set; }
        public int? CurrencyId { get; set; }
        public DateTime? DateVoided { get; set; }
        public int? VoidedById { get; set; }
    }
}
