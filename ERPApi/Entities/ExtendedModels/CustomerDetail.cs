using System;

namespace Entities.ExtendedModels
{
    public class CustomerDetail
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string TelNo { get; set; }
        public string FaxNo { get; set; }
        public string ContactPerson { get; set; }
        public string Tinno { get; set; }
        public int? CustomerTypeId { get; set; }
        public bool Active { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? LastEditedById { get; set; }
        public DateTime? LastEditedDate { get; set; }
        public int? CompanyId { get; set; }
        public int? CategoryId { get; set; }
        public string RegisteredName { get; set; }
        public string RegisteredOwner { get; set; }
        public int? TermsId { get; set; }
        public string BusinessStyle { get; set; }
        public int? OutletTypeId { get; set; }
        public int? SubOutletTypeId { get; set; }
        public int? AreaId { get; set; }
        public int? SubAreaId { get; set; }
        public int? SalesPersonId { get; set; }
        public int? PriceLevelId { get; set; }
        public DateTime? Date { get; set; }
        public string Remarks { get; set; }
        public DateTime? DateJoined { get; set; }
    }
}
