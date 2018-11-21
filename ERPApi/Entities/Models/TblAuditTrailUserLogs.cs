using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblAuditTrailUserLogs
    {
        public int Id { get; set; }
        public int SecurityUserId { get; set; }
        public int CompanyId { get; set; }
        public DateTime Date { get; set; }
        public DateTime? Login { get; set; }
        public DateTime? LogOut { get; set; }
    }
}
