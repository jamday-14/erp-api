using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblAccounts
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int AccountTypeId { get; set; }
        public int? SubsidiaryTypeId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }
        public bool IsPostable { get; set; }
        public int Level { get; set; }
        public int? CreatedById { get; set; }
        public int? ModifiedById { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int? AccountPurposeId { get; set; }
        public bool? IsBankAccount { get; set; }
    }
}
