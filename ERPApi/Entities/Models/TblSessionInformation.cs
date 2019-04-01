using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblSessionInformation
    {
        public int Id { get; set; }
        public int Spid { get; set; }
        public int SecurityUserId { get; set; }
        public DateTime Date { get; set; }
        public DateTime LogIn { get; set; }
    }
}
