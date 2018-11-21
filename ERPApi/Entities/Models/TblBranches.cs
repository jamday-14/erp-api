using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblBranches
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public int? CreatedById { get; set; }
        public int? ModifiedById { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int? ParentId { get; set; }
    }
}
