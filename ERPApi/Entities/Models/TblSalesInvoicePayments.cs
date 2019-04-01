using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblSalesInvoicePayments
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string SystemNo { get; set; }
        public string RefNo { get; set; }
        public int? CustomerId { get; set; }
        public int Mopid { get; set; }
        public int? BankId { get; set; }
        public DateTime? CheckDate { get; set; }
        public string CheckRefNo { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountApplied { get; set; }
        public decimal UiamountApplied { get; set; }
        public decimal? AmountAvailable { get; set; }
        public bool Deposited { get; set; }
        public bool Cleared { get; set; }
        public bool Bounced { get; set; }
        public int? PreparedById { get; set; }
        public int? ApprovedById { get; set; }
        public bool Void { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? LastEditedById { get; set; }
        public DateTime? LastEditedDate { get; set; }
        public int? CompanyId { get; set; }
        public DateTime? DateVoided { get; set; }
        public int? VoidedById { get; set; }
        public int? EntryBalanceAsId { get; set; }
    }
}
