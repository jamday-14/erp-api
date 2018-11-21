using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblJibes5reports
    {
        public int Id { get; set; }
        public string Report { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public int? Jibes5viewId { get; set; }
        public bool? Visible { get; set; }
        public byte[] Bitmap { get; set; }
        public string Category { get; set; }
        public int Index { get; set; }
        public DateTime? Modified { get; set; }
    }
}
