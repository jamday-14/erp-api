using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblSalesInvoicePaymentAdjustments
    {
        public int Id { get; set; }
        public int SalesInvoicePaymentId { get; set; }
        public int PaymentAdjustmentTypeId { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; }
        public int? CreditMemoId { get; set; }
        public string CreditMemoSystemNo { get; set; }
        public string CreditMemoSourceNo { get; set; }
    }
}
