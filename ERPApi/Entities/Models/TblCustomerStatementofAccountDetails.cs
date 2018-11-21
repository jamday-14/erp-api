using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblCustomerStatementofAccountDetails
    {
        public int Id { get; set; }
        public int CustomerStatementofAccountId { get; set; }
        public int Siid { get; set; }
        public DateTime Sidate { get; set; }
        public string SisystemNo { get; set; }
        public string SirefNo { get; set; }
        public decimal Siamount { get; set; }
        public decimal SiamountPaid { get; set; }
        public decimal SiamountDue { get; set; }
    }
}
