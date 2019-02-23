using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblVendorCreditMemo
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int? BranchId { get; set; }
        public string SystemNo { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime Date { get; set; }
        public int VendorId { get; set; }
        public int? ReferenceTypeId { get; set; }
        public int? ReferenceId { get; set; }
        public string SourceSystemNo { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountApplied { get; set; }
        public decimal? AmountAvailable { get; set; }
        public bool Forfeit { get; set; }
        public DateTime? DateForfeited { get; set; }
        public int? ForfeitedById { get; set; }
        public int? ForfeitAccountId { get; set; }
        public int? JournalId { get; set; }
        public int? ForfeitJournalId { get; set; }
        public string Remarks { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? LastEditedById { get; set; }
        public DateTime? LastEditedDate { get; set; }
    }
}
