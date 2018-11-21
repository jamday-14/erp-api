using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblCurrencies
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double ForexRate { get; set; }
        public bool Active { get; set; }
    }
}
