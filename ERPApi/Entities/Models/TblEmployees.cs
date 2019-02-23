using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblEmployees
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string OtherName { get; set; }
        public DateTime? Bday { get; set; }
        public string Address { get; set; }
        public string TelNo { get; set; }
        public string Sssno { get; set; }
        public string PhilHealthNo { get; set; }
        public string PagibigNo { get; set; }
        public string Tinno { get; set; }
        public DateTime? DateHired { get; set; }
        public DateTime? DateSeperated { get; set; }
        public bool IsRegular { get; set; }
        public bool IsContract { get; set; }
        public bool IsExtendContract { get; set; }
        public DateTime? ContractEndDate { get; set; }
        public bool Active { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? LastEditedById { get; set; }
        public DateTime? LastEditedDate { get; set; }
        public int? CompanyId { get; set; }
        public bool IsSalesPerson { get; set; }
        public int? SubsidiaryId { get; set; }
    }
}
