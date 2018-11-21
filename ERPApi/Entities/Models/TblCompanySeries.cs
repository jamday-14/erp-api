using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblCompanySeries
    {
        public int CompanyId { get; set; }
        public string Code { get; set; }
        public int NextNumber { get; set; }
    }
}
