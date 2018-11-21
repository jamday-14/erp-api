using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblJournals
    {
        public int Id { get; set; }
        public int JournalTypeId { get; set; }
        public int CompanyId { get; set; }
        public int? SubsidiaryId { get; set; }
        public int? AccountId { get; set; }
        public string TransactionNo { get; set; }
        public string ReferenceNo { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string CheckNo { get; set; }
        public DateTime? CheckDate { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? ModifiedById { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool IsPosted { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountPaid { get; set; }
        public bool Void { get; set; }
        public decimal? AmountDue { get; set; }
        public bool IsClosingEntries { get; set; }
        public int? TermsId { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsPayrollJournal { get; set; }
        public bool? HasDeferred { get; set; }
        public string Orno { get; set; }
        public DateTime? Ordate { get; set; }
        public bool? IsReleased { get; set; }
        public DateTime? DateReleased { get; set; }
        public bool? IsCleared { get; set; }
        public DateTime? DateCleared { get; set; }
        public bool? IsFunded { get; set; }
        public DateTime? DateFunded { get; set; }
        public bool? IsDeposited { get; set; }
        public DateTime? DateDeposited { get; set; }
        public string DepositSlipNo { get; set; }
        public DateTime? DateReceived { get; set; }
        public int? BranchId { get; set; }
        public int? LineNo { get; set; }
        public int? AncRefTypeId { get; set; }
        public int? AncRefId { get; set; }
        public string AncRefNo { get; set; }
        public DateTime? SearchFromDate { get; set; }
        public DateTime? SearchToDate { get; set; }
        public double? AdminFeePercentage { get; set; }
        public string ContactPerson { get; set; }
    }
}
