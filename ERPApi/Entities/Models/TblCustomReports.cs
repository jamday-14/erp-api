using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblCustomReports
    {
        public int Id { get; set; }
        public string JibesviewName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ViewName { get; set; }
        public byte[] GridSetting { get; set; }
        public int? Index { get; set; }
        public bool? Active { get; set; }
        public int? SecurityUserId { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? ModifiedById { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
