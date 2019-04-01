using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblPurchaseOrders
    {
        public int Id { get; set; }
        public string SystemNo { get; set; }
        public string RefNo { get; set; }
        public DateTime Date { get; set; }
        public int VendorId { get; set; }
        public string Address { get; set; }
        public string TelNo { get; set; }
        public string FaxNo { get; set; }
        public string ContactPerson { get; set; }
        public int? TermId { get; set; }
        public int? PreparedById { get; set; }
        public int? OrderById { get; set; }
        public int? ApprovedById { get; set; }
        public bool Closed { get; set; }
        public bool IsReceived { get; set; }
        public bool Void { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? LastEditedById { get; set; }
        public DateTime? LastEditedDate { get; set; }
        public int? CompanyId { get; set; }
        public bool? IsBilled { get; set; }
        public decimal? Amount { get; set; }
        public decimal? AmountPaid { get; set; }
        public decimal? AmountDue { get; set; }
        public int? CurrencyId { get; set; }
    }
}
