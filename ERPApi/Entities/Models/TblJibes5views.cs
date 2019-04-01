using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblJibes5views
    {
        public int Id { get; set; }
        public int? Jibes5viewId { get; set; }
        public string Name { get; set; }
        public byte[] Template { get; set; }
        public DateTime? Modified { get; set; }
    }
}
