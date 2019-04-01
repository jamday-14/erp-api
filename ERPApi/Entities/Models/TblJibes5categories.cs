using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblJibes5categories
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Caption { get; set; }
        public int Index { get; set; }
        public string AccessKey { get; set; }
        public bool? Visible { get; set; }
        public DateTime? Modified { get; set; }
    }
}
