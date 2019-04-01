using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblExternalTools
    {
        public int Id { get; set; }
        public byte[] Icon { get; set; }
        public byte[] SmallIcon { get; set; }
        public string Name { get; set; }
        public string Command { get; set; }
        public string Parameters { get; set; }
        public byte[] Stream { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool? Active { get; set; }
    }
}
