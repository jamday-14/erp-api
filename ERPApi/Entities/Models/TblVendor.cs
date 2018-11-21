using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblVendor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string TelNo { get; set; }
        public string FaxNo { get; set; }
        public string ContactPerson { get; set; }
        public bool? Active { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? LastEditedById { get; set; }
        public DateTime? LastEditedDate { get; set; }
        public int? CompanyId { get; set; }
        public int? CurrencyId { get; set; }
    }
}
