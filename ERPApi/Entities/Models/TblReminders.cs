using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblReminders
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public int? FlagId { get; set; }
        public int? Companyid { get; set; }
        public string UserById { get; set; }
        public string ReadById { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? ModifiedById { get; set; }
        public DateTime? ModificationDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
