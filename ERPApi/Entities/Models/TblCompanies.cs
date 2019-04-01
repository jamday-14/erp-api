using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class TblCompanies
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public byte[] Logo { get; set; }
        public string Address { get; set; }
        public string TelNo { get; set; }
        public string FaxNo { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public int PasswordHistory { get; set; }
        public int PasswordMaxAge { get; set; }
        public int PasswordMinAge { get; set; }
        public int PasswordMinLength { get; set; }
        public bool PasswordComplexity { get; set; }
        public int PasswordWarnDays { get; set; }
        public string Tin { get; set; }
        public int? Rdoid { get; set; }
        public string RegisteredName { get; set; }
        public string TradeName { get; set; }
        public string RegAddSubstreet { get; set; }
        public string RegAddStreet { get; set; }
        public string RegAddBarangay { get; set; }
        public string RegAddDistrict { get; set; }
        public string RegAddCity { get; set; }
        public string RegAddZipCode { get; set; }
        public int FiscalMonthEnd { get; set; }
        public int DefaultVatrate { get; set; }
        public string RegisteredAddress1 { get; set; }
        public string RegisteredAddress2 { get; set; }
        public string RegisteredAddress { get; set; }
        public int? CustomerOverPaymentAccountId { get; set; }
        public int? CustomerCreditMemoAccountId { get; set; }
        public int? VendorCreditMemoAccountId { get; set; }
        public int? IncomeAccountId { get; set; }
        public int? SalesDiscountAccountId { get; set; }
        public int? SalesReturnAccountId { get; set; }
        public int? CostOfSalesAccountId { get; set; }
        public int? PurchaseAccountId { get; set; }
        public int? PurchaseDiscountAccountId { get; set; }
        public int? PurchaseReturnAccountId { get; set; }
    }
}
