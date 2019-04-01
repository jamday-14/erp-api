using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblLogs
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string Message { get; set; }
        public int? UserId { get; set; }
    }
}
