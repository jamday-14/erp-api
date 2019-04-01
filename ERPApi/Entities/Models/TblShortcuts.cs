using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblShortcuts
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Name { get; set; }
        public int? Tag { get; set; }
        public int? ImageIndex { get; set; }
        public int? ImageSelectedIndex { get; set; }
        public string ViewName { get; set; }
    }
}
