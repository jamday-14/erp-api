using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblSalesInvoicePaymentDetails
    {
        public int Id { get; set; }
        public int SalesInvoicePaymentId { get; set; }
        public int Siid { get; set; }
        public int SitypeId { get; set; }
        public decimal Siamount { get; set; }
        public decimal SiamountPaid { get; set; }
        public decimal SiamountDue { get; set; }
        public decimal Amount { get; set; }
        public DateTime? AppliedDate { get; set; }
        public int? AppliedById { get; set; }
        public string Remarks { get; set; }
    }
}
