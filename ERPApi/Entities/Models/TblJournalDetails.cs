using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblJournalDetails
    {
        public int Id { get; set; }
        public int JournalId { get; set; }
        public int AccountId { get; set; }
        public int? SubsidiaryId { get; set; }
        public int? ClassId { get; set; }
        public int? ExpandedWithholdingTaxId { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? ModifiedById { get; set; }
        public DateTime? ModificationDate { get; set; }
        public decimal? Debit { get; set; }
        public decimal? Credit { get; set; }
        public decimal? GlendBalance { get; set; }
        public decimal? GlbegBalance { get; set; }
        public decimal? SlendBalance { get; set; }
        public decimal? SlbegBalance { get; set; }
        public decimal? BranchGlendBalance { get; set; }
        public decimal? BranchGlbegBalance { get; set; }
        public decimal? BranchSlendBalance { get; set; }
        public decimal? BranchSlbegBalance { get; set; }
        public int? BranchId { get; set; }
        public bool Hidden { get; set; }
        public double? Vatrate { get; set; }
        public decimal? GrossTaxable { get; set; }
        public double? ExpandedWithholdingTaxRate { get; set; }
        public int? VattypeId { get; set; }
        public decimal? TaxBase { get; set; }
        public bool Recon { get; set; }
        public string Shipper { get; set; }
        public string DispatchDate { get; set; }
        public string Rpsno { get; set; }
        public string ContainerNo { get; set; }
        public string InvoiceNo { get; set; }
        public int? HeadCount { get; set; }
        public decimal? RetentionFee { get; set; }
    }
}
