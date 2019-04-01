using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblPurchaseReturns
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string SystemNo { get; set; }
        public string RefNo { get; set; }
        public int VendorId { get; set; }
        public int WarehouseId { get; set; }
        public string Remarks { get; set; }
        public bool Void { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? LastEditedById { get; set; }
        public DateTime? LastEditedDate { get; set; }
        public int? CompanyId { get; set; }
        public int? PreparedById { get; set; }
        public int? ApprovedById { get; set; }
        public int? CurrencyId { get; set; }
        public DateTime? DateVoided { get; set; }
        public int? VoidedById { get; set; }
        public int? BranchId { get; set; }
        public int? JournalId { get; set; }
        public int? Vatid { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Vatamount { get; set; }
        public decimal? GrossAmount { get; set; }
        public decimal? DiscountAmount { get; set; }
    }
}
