using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblSecurityUserCompanies
    {
        public int Id { get; set; }
        public int? SecurityUserId { get; set; }
        public int? CompanyId { get; set; }
    }
}
