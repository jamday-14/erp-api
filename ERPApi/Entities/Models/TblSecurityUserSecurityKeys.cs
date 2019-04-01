using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblSecurityUserSecurityKeys
    {
        public int Id { get; set; }
        public int SecurityUserId { get; set; }
        public int SecurityKeyId { get; set; }

        public TblSecurityKeys SecurityKey { get; set; }
        public TblSecurityUsers SecurityUser { get; set; }
    }
}
