using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblTerms
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberofDays { get; set; }
        public bool? Active { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? LastEditedById { get; set; }
        public DateTime? LastEditedDate { get; set; }
        public int? CompanyId { get; set; }
    }
}
