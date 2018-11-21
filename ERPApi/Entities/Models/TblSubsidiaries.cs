using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblSubsidiaries
    {
        public int Id { get; set; }
        public int SubsidiaryTypeId { get; set; }
        public int CompanyId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }
        public int? CreatedById { get; set; }
        public int? ModifiedById { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string RegisteredName { get; set; }
        public string Tin { get; set; }
        public string RegisteredAddress1 { get; set; }
        public string RegisteredAddress2 { get; set; }
        public string RegisteredAddress { get; set; }
        public string NameTemp { get; set; }
        public double? AdminFeePercentage { get; set; }
        public string ContactPerson { get; set; }
    }
}
