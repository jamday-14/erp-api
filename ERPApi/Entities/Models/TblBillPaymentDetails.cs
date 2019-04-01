using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblBillPaymentDetails
    {
        public int Id { get; set; }
        public int BillPaymentId { get; set; }
        public int BillId { get; set; }
        public int BillTypeId { get; set; }
        public decimal BillAmount { get; set; }
        public decimal BillAmountPaid { get; set; }
        public decimal BillAmountDue { get; set; }
        public decimal Amount { get; set; }
        public DateTime? AppliedDate { get; set; }
        public int? AppliedById { get; set; }
        public string Remarks { get; set; }
    }
}
