using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblExecutables
    {
        public string Version { get; set; }
        public string Name { get; set; }
        public byte[] Stream { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Url { get; set; }
    }
}
