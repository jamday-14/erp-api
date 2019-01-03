using System;
using System.Collections.Generic;

namespace Entities
{
    public class NewSalesOrderRequest
    {
        public DateTime Date { get; set; }
        public string SystemNo { get; set; }
        public string RefNo { get; set; }
        public int CustomerId { get; set; }
        public string Address { get; set; }
        public string TelNo { get; set; }
        public string FaxNo { get; set; }
        public string ContactPerson { get; set; }
        public int? TermId { get; set; }
        public int? PreparedById { get; set; }
        public int? ApprovedById { get; set; }
        public bool IsDr { get; set; }
        public bool IsInvoice { get; set; }
        public bool Closed { get; set; }
        public bool Void { get; set; }
        public int? CompanyId { get; set; }
        public decimal? Amount { get; set; }
        public string Comments { get; set; }
        public decimal? AmountPaid { get; set; }
        public int? Categoryid { get; set; }
        public double? Percent { get; set; }

        public List<SalesOrderDetailRequest> Details { get; set; }
    }
}
