using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities.Models
{
    public partial class ERPContext : DbContext
    {
        public ERPContext()
        {
        }

        public ERPContext(DbContextOptions<ERPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAccounts> TblAccounts { get; set; }
        public virtual DbSet<TblAccountTypes> TblAccountTypes { get; set; }
        public virtual DbSet<TblAreas> TblAreas { get; set; }
        public virtual DbSet<TblAuditTrailUserLogs> TblAuditTrailUserLogs { get; set; }
        public virtual DbSet<TblBanks> TblBanks { get; set; }
        public virtual DbSet<TblBillDetails> TblBillDetails { get; set; }
        public virtual DbSet<TblBillPaymentDetails> TblBillPaymentDetails { get; set; }
        public virtual DbSet<TblBillPayments> TblBillPayments { get; set; }
        public virtual DbSet<TblBills> TblBills { get; set; }
        public virtual DbSet<TblBillsPaymentAdjustments> TblBillsPaymentAdjustments { get; set; }
        public virtual DbSet<TblBranches> TblBranches { get; set; }
        public virtual DbSet<TblCompanies> TblCompanies { get; set; }
        public virtual DbSet<TblCompanySeries> TblCompanySeries { get; set; }
        public virtual DbSet<TblCurrencies> TblCurrencies { get; set; }
        public virtual DbSet<TblCustomerCreditMemo> TblCustomerCreditMemo { get; set; }
        public virtual DbSet<TblCustomers> TblCustomers { get; set; }
        public virtual DbSet<TblCustomerStatementofAccountDetails> TblCustomerStatementofAccountDetails { get; set; }
        public virtual DbSet<TblCustomerStatementofAccounts> TblCustomerStatementofAccounts { get; set; }
        public virtual DbSet<TblCustomerTypes> TblCustomerTypes { get; set; }
        public virtual DbSet<TblDeliveryReceiptDetails> TblDeliveryReceiptDetails { get; set; }
        public virtual DbSet<TblDeliveryReceipts> TblDeliveryReceipts { get; set; }
        public virtual DbSet<TblEditions> TblEditions { get; set; }
        public virtual DbSet<TblEmployees> TblEmployees { get; set; }
        public virtual DbSet<TblGeneralLedger> TblGeneralLedger { get; set; }
        public virtual DbSet<TblGoodsTransferDetails> TblGoodsTransferDetails { get; set; }
        public virtual DbSet<TblGoodsTransferReceived> TblGoodsTransferReceived { get; set; }
        public virtual DbSet<TblGoodsTransferReceivedDetails> TblGoodsTransferReceivedDetails { get; set; }
        public virtual DbSet<TblGoodsTransfers> TblGoodsTransfers { get; set; }
        public virtual DbSet<TblInventory> TblInventory { get; set; }
        public virtual DbSet<TblInventoryLedger> TblInventoryLedger { get; set; }
        public virtual DbSet<TblItemEntries> TblItemEntries { get; set; }
        public virtual DbSet<TblItemEntryDetails> TblItemEntryDetails { get; set; }
        public virtual DbSet<TblItemReleaseDetails> TblItemReleaseDetails { get; set; }
        public virtual DbSet<TblItemReleases> TblItemReleases { get; set; }
        public virtual DbSet<TblItems> TblItems { get; set; }
        public virtual DbSet<TblJournalDetails> TblJournalDetails { get; set; }
        public virtual DbSet<TblJournals> TblJournals { get; set; }
        public virtual DbSet<TblJournalTypes> TblJournalTypes { get; set; }
        public virtual DbSet<TblMonths> TblMonths { get; set; }
        public virtual DbSet<TblMop> TblMop { get; set; }
        public virtual DbSet<TblOutletDeliveryReceiptDetails> TblOutletDeliveryReceiptDetails { get; set; }
        public virtual DbSet<TblOutletDeliveryReceipts> TblOutletDeliveryReceipts { get; set; }
        public virtual DbSet<TblOutletReturnDetails> TblOutletReturnDetails { get; set; }
        public virtual DbSet<TblOutletReturns> TblOutletReturns { get; set; }
        public virtual DbSet<TblOutletSalesInvoiceDetails> TblOutletSalesInvoiceDetails { get; set; }
        public virtual DbSet<TblOutletSalesInvoices> TblOutletSalesInvoices { get; set; }
        public virtual DbSet<TblOutletTypes> TblOutletTypes { get; set; }
        public virtual DbSet<TblPaymentAdjustmentTypes> TblPaymentAdjustmentTypes { get; set; }
        public virtual DbSet<TblPriceLevelDetails> TblPriceLevelDetails { get; set; }
        public virtual DbSet<TblPriceLevels> TblPriceLevels { get; set; }
        public virtual DbSet<TblPurchaseOrderDetails> TblPurchaseOrderDetails { get; set; }
        public virtual DbSet<TblPurchaseOrders> TblPurchaseOrders { get; set; }
        public virtual DbSet<TblPurchaseReturnDetails> TblPurchaseReturnDetails { get; set; }
        public virtual DbSet<TblPurchaseReturns> TblPurchaseReturns { get; set; }
        public virtual DbSet<TblRdo> TblRdo { get; set; }
        public virtual DbSet<TblReasonForInventoryAdjustments> TblReasonForInventoryAdjustments { get; set; }
        public virtual DbSet<TblReceivingReportDetails> TblReceivingReportDetails { get; set; }
        public virtual DbSet<TblReceivingReports> TblReceivingReports { get; set; }
        public virtual DbSet<TblReferenceTypes> TblReferenceTypes { get; set; }
        public virtual DbSet<TblReminders> TblReminders { get; set; }
        public virtual DbSet<TblSalesInvoiceDetails> TblSalesInvoiceDetails { get; set; }
        public virtual DbSet<TblSalesInvoicePaymentAdjustments> TblSalesInvoicePaymentAdjustments { get; set; }
        public virtual DbSet<TblSalesInvoicePaymentDetails> TblSalesInvoicePaymentDetails { get; set; }
        public virtual DbSet<TblSalesInvoicePayments> TblSalesInvoicePayments { get; set; }
        public virtual DbSet<TblSalesInvoices> TblSalesInvoices { get; set; }
        public virtual DbSet<TblSalesOrderDetails> TblSalesOrderDetails { get; set; }
        public virtual DbSet<TblSalesOrders> TblSalesOrders { get; set; }
        public virtual DbSet<TblSalesReturnDetails> TblSalesReturnDetails { get; set; }
        public virtual DbSet<TblSalesReturns> TblSalesReturns { get; set; }
        public virtual DbSet<TblSecurityGroups> TblSecurityGroups { get; set; }
        public virtual DbSet<TblSecurityGroupSecurityKeys> TblSecurityGroupSecurityKeys { get; set; }
        public virtual DbSet<TblSecurityKeys> TblSecurityKeys { get; set; }
        public virtual DbSet<TblSecurityUserCompanies> TblSecurityUserCompanies { get; set; }
        public virtual DbSet<TblSecurityUserGroups> TblSecurityUserGroups { get; set; }
        public virtual DbSet<TblSecurityUserLevels> TblSecurityUserLevels { get; set; }
        public virtual DbSet<TblSecurityUsers> TblSecurityUsers { get; set; }
        public virtual DbSet<TblSecurityUserSecurityGroups> TblSecurityUserSecurityGroups { get; set; }
        public virtual DbSet<TblSecurityUserSecurityKeys> TblSecurityUserSecurityKeys { get; set; }
        public virtual DbSet<TblSeries> TblSeries { get; set; }
        public virtual DbSet<TblSubAreas> TblSubAreas { get; set; }
        public virtual DbSet<TblSubOutletTypes> TblSubOutletTypes { get; set; }
        public virtual DbSet<TblSubsidiaries> TblSubsidiaries { get; set; }
        public virtual DbSet<TblSubsidiaryLedger> TblSubsidiaryLedger { get; set; }
        public virtual DbSet<TblSubsidiaryTypes> TblSubsidiaryTypes { get; set; }
        public virtual DbSet<TblTerms> TblTerms { get; set; }
        public virtual DbSet<TblTransactionDetails> TblTransactionDetails { get; set; }
        public virtual DbSet<TblTransactions> TblTransactions { get; set; }
        public virtual DbSet<TblTransactionTypes> TblTransactionTypes { get; set; }
        public virtual DbSet<TblUnits> TblUnits { get; set; }
        public virtual DbSet<TblVat> TblVat { get; set; }
        public virtual DbSet<TblVendor> TblVendor { get; set; }
        public virtual DbSet<TblVendorCreditMemo> TblVendorCreditMemo { get; set; }
        public virtual DbSet<TblVendorItems> TblVendorItems { get; set; }
        public virtual DbSet<TblWarehouseInventoryLedger> TblWarehouseInventoryLedger { get; set; }
        public virtual DbSet<TblWarehouses> TblWarehouses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=erp-robinhood.database.windows.net;Database=ERP;User id=robinhood; Password=R0b1nh00D3RP");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblAccounts>(entity =>
            {
                entity.ToTable("tblAccounts");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.IsBankAccount).HasComputedColumnSql("(CONVERT([bit],case when [AccountPurposeId]=(1) then (1) else (0) end,(0)))");

                entity.Property(e => e.ModificationDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblAccountTypes>(entity =>
            {
                entity.ToTable("tblAccountTypes");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name2)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblAreas>(entity =>
            {
                entity.ToTable("tblAreas");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblAuditTrailUserLogs>(entity =>
            {
                entity.ToTable("tblAuditTrailUserLogs");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.LogOut).HasColumnType("datetime");

                entity.Property(e => e.Login).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblBanks>(entity =>
            {
                entity.ToTable("tblBanks");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblBillDetails>(entity =>
            {
                entity.ToTable("tblBillDetails");

                entity.Property(e => e.Discount).HasColumnType("money");

                entity.Property(e => e.GrossAmount).HasColumnType("money");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RrdetailId).HasColumnName("RRDetailId");

                entity.Property(e => e.Rrid).HasColumnName("RRId");

                entity.Property(e => e.RrrefNo)
                    .HasColumnName("RRRefNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubTotal).HasColumnType("money");

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.Property(e => e.Vatamount)
                    .HasColumnName("VATAmount")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<TblBillPaymentDetails>(entity =>
            {
                entity.ToTable("tblBillPaymentDetails");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.AppliedDate).HasColumnType("datetime");

                entity.Property(e => e.BillAmount).HasColumnType("money");

                entity.Property(e => e.BillAmountDue).HasColumnType("money");

                entity.Property(e => e.BillAmountPaid).HasColumnType("money");

                entity.Property(e => e.BillTypeId).HasDefaultValueSql("((1))");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblBillPayments>(entity =>
            {
                entity.ToTable("tblBillPayments");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.CheckDate).HasColumnType("datetime");

                entity.Property(e => e.CheckRefNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedById).HasColumnName("CreatedByID");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DateVoided).HasColumnType("datetime");

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.Mopid).HasColumnName("MOPId");

                entity.Property(e => e.PreparedById).HasColumnName("PreparedByID");

                entity.Property(e => e.RefNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SystemNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblBills>(entity =>
            {
                entity.ToTable("tblBills");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.AmountDue)
                    .HasColumnType("money")
                    .HasComputedColumnSql("(isnull([Amount],(0))-(isnull([AmountPaid],(0))+isnull([ReturnAmount],(0))))");

                entity.Property(e => e.AmountPaid).HasColumnType("money");

                entity.Property(e => e.Comments)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DateVoided).HasColumnType("datetime");

                entity.Property(e => e.DiscountAmount).HasColumnType("money");

                entity.Property(e => e.FaxNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GrossAmount).HasColumnType("money");

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.Mopid).HasColumnName("MOPId");

                entity.Property(e => e.RefNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReturnAmount)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SystemNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TermId).HasColumnName("TermID");

                entity.Property(e => e.Vatamount)
                    .HasColumnName("VATAmount")
                    .HasColumnType("money");

                entity.Property(e => e.Vatid).HasColumnName("VATId");
            });

            modelBuilder.Entity<TblBillsPaymentAdjustments>(entity =>
            {
                entity.ToTable("tblBillsPaymentAdjustments");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.CreditMemoSourceNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreditMemoSystemNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblBranches>(entity =>
            {
                entity.ToTable("tblBranches");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.ModificationDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblCompanies>(entity =>
            {
                entity.ToTable("tblCompanies");

                entity.Property(e => e.Address)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DefaultVatrate)
                    .HasColumnName("DefaultVATRate")
                    .HasDefaultValueSql("((12))");

                entity.Property(e => e.Email)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FaxNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FiscalMonthEnd).HasDefaultValueSql("((12))");

                entity.Property(e => e.Logo).HasColumnType("image");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordMaxAge).HasDefaultValueSql("((30))");

                entity.Property(e => e.PasswordWarnDays).HasDefaultValueSql("((7))");

                entity.Property(e => e.Rdoid).HasColumnName("RDOId");

                entity.Property(e => e.RegAddBarangay)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegAddCity)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegAddDistrict)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegAddStreet)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegAddSubstreet)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegAddZipCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RegisteredAddress)
                    .HasMaxLength(305)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(((((((((([RegAddSubstreet]+case when [RegAddStreet] IS NULL then '' else ' ' end)+[RegAddStreet])+case when [RegAddBarangay] IS NULL then '' else ' ' end)+[RegAddBarangay])+case when [RegAddDistrict] IS NULL then '' else ' ' end)+[RegAddDistrict])+case when [RegAddCity] IS NULL then '' else ' ' end)+[RegAddCity])+case when [RegAddZipCode] IS NULL then '' else ' ' end)+[RegAddZipCode])");

                entity.Property(e => e.RegisteredAddress1)
                    .HasMaxLength(152)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(((([RegAddSubstreet]+case when [RegAddStreet] IS NULL then '' else ' ' end)+[RegAddStreet])+case when [RegAddBarangay] IS NULL then '' else ' ' end)+[RegAddBarangay])");

                entity.Property(e => e.RegisteredAddress2)
                    .HasMaxLength(152)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(((([RegAddDistrict]+case when [RegAddCity] IS NULL then '' else ' ' end)+[RegAddCity])+case when [RegAddZipCode] IS NULL then '' else ' ' end)+[RegAddZipCode])");

                entity.Property(e => e.RegisteredName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TelNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tin)
                    .HasColumnName("TIN")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TradeName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Website)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblCompanySeries>(entity =>
            {
                entity.HasKey(e => new { e.CompanyId, e.Code });

                entity.ToTable("tblCompanySeries");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NextNumber).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<TblCurrencies>(entity =>
            {
                entity.ToTable("tblCurrencies");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblCustomerCreditMemo>(entity =>
            {
                entity.ToTable("tblCustomerCreditMemo");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.AmountApplied).HasColumnType("money");

                entity.Property(e => e.AmountAvailable)
                    .HasColumnType("money")
                    .HasComputedColumnSql("([Amount]-[AmountApplied])");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateForfeited).HasColumnType("datetime");

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.ReferenceNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SourceSystemNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SystemNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblCustomers>(entity =>
            {
                entity.ToTable("tblCustomers");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.BusinessStyle)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DateJoined).HasColumnType("date");

                entity.Property(e => e.FaxNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RegisteredName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RegisteredOwner)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.TelNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tinno)
                    .HasColumnName("TINNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblCustomerStatementofAccountDetails>(entity =>
            {
                entity.ToTable("tblCustomerStatementofAccountDetails");

                entity.Property(e => e.Siamount)
                    .HasColumnName("SIAmount")
                    .HasColumnType("money");

                entity.Property(e => e.SiamountDue)
                    .HasColumnName("SIAmountDue")
                    .HasColumnType("money");

                entity.Property(e => e.SiamountPaid)
                    .HasColumnName("SIAmountPaid")
                    .HasColumnType("money");

                entity.Property(e => e.Sidate)
                    .HasColumnName("SIDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Siid).HasColumnName("SIId");

                entity.Property(e => e.SirefNo)
                    .HasColumnName("SIRefNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SisystemNo)
                    .IsRequired()
                    .HasColumnName("SISystemNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblCustomerStatementofAccounts>(entity =>
            {
                entity.ToTable("tblCustomerStatementofAccounts");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.RefNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SystemNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblCustomerTypes>(entity =>
            {
                entity.ToTable("tblCustomerTypes");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblDeliveryReceiptDetails>(entity =>
            {
                entity.ToTable("tblDeliveryReceiptDetails");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DeliveryReceiptId).HasColumnName("DeliveryReceiptID");

                entity.Property(e => e.Discount).HasColumnType("money");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SodetailId).HasColumnName("SODetailId");

                entity.Property(e => e.Soid).HasColumnName("SOId");

                entity.Property(e => e.SorefNo)
                    .HasColumnName("SORefNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubTotal).HasComputedColumnSql("([Qty]*[UnitPrice]-[Discount])");

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");
            });

            modelBuilder.Entity<TblDeliveryReceipts>(entity =>
            {
                entity.ToTable("tblDeliveryReceipts");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Amount)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AmountDue)
                    .HasColumnType("money")
                    .HasComputedColumnSql("([Amount]-[AmountPaid])");

                entity.Property(e => e.AmountPaid)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Comments)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedById).HasColumnName("CreatedByID");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DateVoided).HasColumnType("datetime");

                entity.Property(e => e.FaxNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsReturn).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastEditedById).HasColumnName("LastEditedByID");

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.PreparedById).HasColumnName("PreparedByID");

                entity.Property(e => e.RefNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SystemNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalAmount).HasColumnType("money");
            });

            modelBuilder.Entity<TblEditions>(entity =>
            {
                entity.ToTable("tblEditions");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblEmployees>(entity =>
            {
                entity.ToTable("tblEmployees");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Bday).HasColumnType("datetime");

                entity.Property(e => e.ContractEndDate).HasColumnType("datetime");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.DateHired).HasColumnType("datetime");

                entity.Property(e => e.DateSeperated).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastEditedById).HasColumnName("LastEditedByID");

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OtherName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PagibigNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhilHealthNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sssno)
                    .HasColumnName("SSSNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tinno)
                    .HasColumnName("TINNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblGeneralLedger>(entity =>
            {
                entity.HasKey(e => new { e.AccountId, e.Date, e.CompanyId });

                entity.ToTable("tblGeneralLedger");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Credit).HasColumnType("money");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Debit).HasColumnType("money");

                entity.Property(e => e.EndBalance).HasColumnType("money");
            });

            modelBuilder.Entity<TblGoodsTransferDetails>(entity =>
            {
                entity.ToTable("tblGoodsTransferDetails");

                entity.Property(e => e.QtyLeft).HasComputedColumnSql("([Qty]-[QtyReceived])");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblGoodsTransferReceived>(entity =>
            {
                entity.ToTable("tblGoodsTransferReceived");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DateVoided).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.RefNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SystemNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblGoodsTransferReceivedDetails>(entity =>
            {
                entity.ToTable("tblGoodsTransferReceivedDetails");

                entity.Property(e => e.GtdetailId).HasColumnName("GTDetailId");

                entity.Property(e => e.Gtid).HasColumnName("GTId");

                entity.Property(e => e.GtrefNo)
                    .IsRequired()
                    .HasColumnName("GTRefNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblGoodsTransfers>(entity =>
            {
                entity.ToTable("tblGoodsTransfers");

                entity.Property(e => e.CreatedById).HasColumnName("CreatedByID");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DateVoided).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.RefNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SystemNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblInventory>(entity =>
            {
                entity.HasKey(e => new { e.CompanyId, e.WareHouseId, e.ItemId });

                entity.ToTable("tblInventory");

                entity.Property(e => e.AvgCost)
                    .HasColumnType("money")
                    .HasComputedColumnSql("(CONVERT([money],case when [Quantity]=(0) then (0) else round([TotalCost]/[Quantity],(2)) end,(0)))");

                entity.Property(e => e.TotalCost).HasColumnType("money");
            });

            modelBuilder.Entity<TblInventoryLedger>(entity =>
            {
                entity.HasKey(e => new { e.CompanyId, e.ItemId, e.Date });

                entity.ToTable("tblInventoryLedger");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.EndTotalCost).HasColumnType("money");

                entity.Property(e => e.TotalInCost).HasColumnType("money");

                entity.Property(e => e.TotalOutCost).HasColumnType("money");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TblInventoryLedger)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblInventoryLedger_tblItems");
            });

            modelBuilder.Entity<TblItemEntries>(entity =>
            {
                entity.ToTable("tblItemEntries");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DateVoided).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.PreparedById).HasColumnName("PreparedByID");

                entity.Property(e => e.RefNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SystemNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblItemEntryDetails>(entity =>
            {
                entity.ToTable("tblItemEntryDetails");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UnitId).HasColumnName("UnitID");
            });

            modelBuilder.Entity<TblItemReleaseDetails>(entity =>
            {
                entity.ToTable("tblItemReleaseDetails");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblItemReleases>(entity =>
            {
                entity.ToTable("tblItemReleases");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DateVoided).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LastEditedById).HasColumnName("LastEditedByID");

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.RefNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SystemNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblItems>(entity =>
            {
                entity.ToTable("tblItems");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CostPrice).HasColumnType("money");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Ipurchased).HasColumnName("IPurchased");

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.Quantity).HasDefaultValueSql("((0))");

                entity.Property(e => e.RmbcostPrice)
                    .HasColumnName("RMBCostPrice")
                    .HasColumnType("money");

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.Property(e => e.UsdcostPrice)
                    .HasColumnName("USDCostPrice")
                    .HasColumnType("money");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.InverseIdNavigation)
                    .HasForeignKey<TblItems>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblItems_tblItems");
            });

            modelBuilder.Entity<TblJournalDetails>(entity =>
            {
                entity.ToTable("tblJournalDetails");

                entity.Property(e => e.BranchGlbegBalance)
                    .HasColumnName("BranchGLBegBalance")
                    .HasColumnType("money")
                    .HasComputedColumnSql("(([BranchGLEndBalance]-isnull([Debit],(0)))+isnull([Credit],(0)))");

                entity.Property(e => e.BranchGlendBalance)
                    .HasColumnName("BranchGLEndBalance")
                    .HasColumnType("money");

                entity.Property(e => e.BranchSlbegBalance)
                    .HasColumnName("BranchSLBegBalance")
                    .HasColumnType("money")
                    .HasComputedColumnSql("(([BranchSLEndBalance]-isnull([Debit],(0)))+isnull([Credit],(0)))");

                entity.Property(e => e.BranchSlendBalance)
                    .HasColumnName("BranchSLEndBalance")
                    .HasColumnType("money");

                entity.Property(e => e.ContainerNo)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Credit).HasColumnType("money");

                entity.Property(e => e.Debit).HasColumnType("money");

                entity.Property(e => e.DispatchDate)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.GlbegBalance)
                    .HasColumnName("GLBegBalance")
                    .HasColumnType("money")
                    .HasComputedColumnSql("(([GLEndBalance]-isnull([Debit],(0)))+isnull([Credit],(0)))");

                entity.Property(e => e.GlendBalance)
                    .HasColumnName("GLEndBalance")
                    .HasColumnType("money");

                entity.Property(e => e.GrossTaxable).HasColumnType("money");

                entity.Property(e => e.InvoiceNo)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModificationDate).HasColumnType("datetime");

                entity.Property(e => e.RetentionFee).HasColumnType("money");

                entity.Property(e => e.Rpsno)
                    .HasColumnName("RPSNo")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Shipper)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SlbegBalance)
                    .HasColumnName("SLBegBalance")
                    .HasColumnType("money")
                    .HasComputedColumnSql("(([SLEndBalance]-isnull([Debit],(0)))+isnull([Credit],(0)))");

                entity.Property(e => e.SlendBalance)
                    .HasColumnName("SLEndBalance")
                    .HasColumnType("money");

                entity.Property(e => e.TaxBase).HasColumnType("money");

                entity.Property(e => e.Vatrate).HasColumnName("VATRate");

                entity.Property(e => e.VattypeId).HasColumnName("VATTypeId");
            });

            modelBuilder.Entity<TblJournals>(entity =>
            {
                entity.ToTable("tblJournals");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.AmountDue)
                    .HasColumnType("money")
                    .HasComputedColumnSql("([Amount]-[AmountPaid])");

                entity.Property(e => e.AmountPaid).HasColumnType("money");

                entity.Property(e => e.AncRefNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CheckDate).HasColumnType("datetime");

                entity.Property(e => e.CheckNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CheckVoucherTypeId).HasDefaultValueSql("((1))");

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DateCleared).HasColumnType("datetime");

                entity.Property(e => e.DateDeposited).HasColumnType("datetime");

                entity.Property(e => e.DateFunded).HasColumnType("datetime");

                entity.Property(e => e.DateReceived).HasColumnType("datetime");

                entity.Property(e => e.DateReleased).HasColumnType("datetime");

                entity.Property(e => e.DateVoided).HasColumnType("datetime");

                entity.Property(e => e.DepositSlipNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.HasDeferred).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsSystemGenerated)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModificationDate).HasColumnType("datetime");

                entity.Property(e => e.Ordate)
                    .HasColumnName("ORDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Orno)
                    .HasColumnName("ORNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReferenceNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SearchFromDate).HasColumnType("datetime");

                entity.Property(e => e.SearchToDate).HasColumnType("datetime");

                entity.Property(e => e.TransactionNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblJournalTypes>(entity =>
            {
                entity.ToTable("tblJournalTypes");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FormName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblMonths>(entity =>
            {
                entity.ToTable("tblMonths");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Qmorder).HasColumnName("QMOrder");
            });

            modelBuilder.Entity<TblMop>(entity =>
            {
                entity.ToTable("tblMOP");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedById).HasColumnName("CreatedByID");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblOutletDeliveryReceiptDetails>(entity =>
            {
                entity.ToTable("tblOutletDeliveryReceiptDetails");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Discount).HasColumnType("money");

                entity.Property(e => e.OutletDeliveryReceiptId).HasColumnName("OutletDeliveryReceiptID");

                entity.Property(e => e.QtyOutletOnHand).HasDefaultValueSql("((0))");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SodetailId).HasColumnName("SODetailId");

                entity.Property(e => e.Soid).HasColumnName("SOId");

                entity.Property(e => e.SorefNo)
                    .HasColumnName("SORefNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubTotal).HasComputedColumnSql("([Qty]*[UnitPrice]-[Discount])");

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");
            });

            modelBuilder.Entity<TblOutletDeliveryReceipts>(entity =>
            {
                entity.ToTable("tblOutletDeliveryReceipts");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Amount)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AmountDue)
                    .HasColumnType("money")
                    .HasComputedColumnSql("([Amount]-[AmountPaid])");

                entity.Property(e => e.AmountPaid)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Comments)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedById).HasColumnName("CreatedByID");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.FaxNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsReturn).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastEditedById).HasColumnName("LastEditedByID");

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.PreparedById).HasColumnName("PreparedByID");

                entity.Property(e => e.RefNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SystemNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalAmount).HasColumnType("money");
            });

            modelBuilder.Entity<TblOutletReturnDetails>(entity =>
            {
                entity.ToTable("tblOutletReturnDetails");

                entity.Property(e => e.Discount).HasColumnType("money");

                entity.Property(e => e.DrdetailId).HasColumnName("DRDetailId");

                entity.Property(e => e.Drid).HasColumnName("DRId");

                entity.Property(e => e.DrrefNo)
                    .HasColumnName("DRRefNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks).HasMaxLength(100);

                entity.Property(e => e.SubTotal).HasComputedColumnSql("([Qty]*[UnitPrice]-[Discount])");

                entity.Property(e => e.UnitPrice).HasColumnType("money");
            });

            modelBuilder.Entity<TblOutletReturns>(entity =>
            {
                entity.ToTable("tblOutletReturns");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.RefNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SystemNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblOutletSalesInvoiceDetails>(entity =>
            {
                entity.ToTable("tblOutletSalesInvoiceDetails");

                entity.Property(e => e.Discount).HasColumnType("money");

                entity.Property(e => e.DrdetailId).HasColumnName("DRDetailID");

                entity.Property(e => e.Drid).HasColumnName("DRId");

                entity.Property(e => e.DrrefNo)
                    .HasColumnName("DRRefNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.QtyLeft).HasComputedColumnSql("([QtyOnHand]-[Qty])");

                entity.Property(e => e.SubTotal).HasComputedColumnSql("([Qty]*[UnitPrice]-[Discount])");

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");
            });

            modelBuilder.Entity<TblOutletSalesInvoices>(entity =>
            {
                entity.ToTable("tblOutletSalesInvoices");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.AmountDue)
                    .HasColumnType("money")
                    .HasComputedColumnSql("([Amount]-[AmountPaid])");

                entity.Property(e => e.AmountPaid)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Comments)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.FaxNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastEditedById).HasColumnName("LastEditedByID");

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.Mopid).HasColumnName("MOPId");

                entity.Property(e => e.PreparedById).HasColumnName("PreparedByID");

                entity.Property(e => e.RefNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SystemNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TermId).HasColumnName("TermID");

                entity.Property(e => e.Uiselect)
                    .HasColumnName("UISelect")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblOutletTypes>(entity =>
            {
                entity.ToTable("tblOutletTypes");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPaymentAdjustmentTypes>(entity =>
            {
                entity.ToTable("tblPaymentAdjustmentTypes");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.ForAp).HasColumnName("ForAP");

                entity.Property(e => e.ForAr).HasColumnName("ForAR");

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPriceLevelDetails>(entity =>
            {
                entity.ToTable("tblPriceLevelDetails");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UnitPrice).HasColumnType("numeric(19, 8)");
            });

            modelBuilder.Entity<TblPriceLevels>(entity =>
            {
                entity.ToTable("tblPriceLevels");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPurchaseOrderDetails>(entity =>
            {
                entity.ToTable("tblPurchaseOrderDetails");

                entity.Property(e => e.Discount).HasColumnType("money");

                entity.Property(e => e.QtyLeft).HasComputedColumnSql("([Qty]-[QtyReceived])");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SubTotal).HasComputedColumnSql("([Qty]*[UnitPrice]-[Discount])");

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TblPurchaseOrderDetails)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPurchaseOrderDetails_tblItems");
            });

            modelBuilder.Entity<TblPurchaseOrders>(entity =>
            {
                entity.ToTable("tblPurchaseOrders");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Amount)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AmountDue)
                    .HasColumnType("money")
                    .HasComputedColumnSql("([Amount]-[AmountPaid])");

                entity.Property(e => e.AmountPaid)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedById).HasColumnName("CreatedByID");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.FaxNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsBilled).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.RefNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SystemNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPurchaseReturnDetails>(entity =>
            {
                entity.ToTable("tblPurchaseReturnDetails");

                entity.Property(e => e.Discount).HasColumnType("money");

                entity.Property(e => e.GrossAmount)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ReferenceNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SubTotal).HasComputedColumnSql("([Qty]*[UnitPrice]-[Discount])");

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.Property(e => e.Vatamount)
                    .HasColumnName("VATAmount")
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblPurchaseReturns>(entity =>
            {
                entity.ToTable("tblPurchaseReturns");

                entity.Property(e => e.Amount)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DateVoided).HasColumnType("datetime");

                entity.Property(e => e.DiscountAmount)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.GrossAmount)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.RefNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SystemNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Vatamount)
                    .HasColumnName("VATAmount")
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Vatid).HasColumnName("VATId");
            });

            modelBuilder.Entity<TblRdo>(entity =>
            {
                entity.ToTable("tblRDO");

                entity.HasIndex(e => e.Id)
                    .HasName("IX_tblRDO")
                    .IsUnique();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblReasonForInventoryAdjustments>(entity =>
            {
                entity.ToTable("tblReasonForInventoryAdjustments");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblReceivingReportDetails>(entity =>
            {
                entity.ToTable("tblReceivingReportDetails");

                entity.Property(e => e.Discount)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PodetailId).HasColumnName("PODetailId");

                entity.Property(e => e.Poid).HasColumnName("POId");

                entity.Property(e => e.PorefNo)
                    .HasColumnName("PORefNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SubTotal).HasComputedColumnSql("([Qty]*[UnitPrice]-[Discount])");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblReceivingReports>(entity =>
            {
                entity.ToTable("tblReceivingReports");

                entity.Property(e => e.Amount)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AmountDue)
                    .HasColumnType("money")
                    .HasComputedColumnSql("([Amount]-[AmountPaid])");

                entity.Property(e => e.AmountPaid)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Comments)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DateVoided).HasColumnType("datetime");

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.RefNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SystemNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblReferenceTypes>(entity =>
            {
                entity.ToTable("tblReferenceTypes");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblReminders>(entity =>
            {
                entity.ToTable("tblReminders");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.ModificationDate).HasColumnType("datetime");

                entity.Property(e => e.ReadById)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.UserById)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblSalesInvoiceDetails>(entity =>
            {
                entity.ToTable("tblSalesInvoiceDetails");

                entity.Property(e => e.Discount).HasColumnType("money");

                entity.Property(e => e.DrdetailId).HasColumnName("DRDetailID");

                entity.Property(e => e.Drid).HasColumnName("DRId");

                entity.Property(e => e.DrrefNo)
                    .HasColumnName("DRRefNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GrossAmount).HasColumnType("money");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.SalesInvoiceId).HasColumnName("SalesInvoiceID");

                entity.Property(e => e.SubTotal).HasComputedColumnSql("([Qty]*[UnitPrice]-[Discount])");

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.Property(e => e.Vatamount)
                    .HasColumnName("VATAmount")
                    .HasColumnType("money");

                entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");
            });

            modelBuilder.Entity<TblSalesInvoicePaymentAdjustments>(entity =>
            {
                entity.ToTable("tblSalesInvoicePaymentAdjustments");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.CreditMemoSourceNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreditMemoSystemNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblSalesInvoicePaymentDetails>(entity =>
            {
                entity.ToTable("tblSalesInvoicePaymentDetails");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.AppliedDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Siamount)
                    .HasColumnName("SIAmount")
                    .HasColumnType("money");

                entity.Property(e => e.SiamountDue)
                    .HasColumnName("SIAmountDue")
                    .HasColumnType("money");

                entity.Property(e => e.SiamountPaid)
                    .HasColumnName("SIAmountPaid")
                    .HasColumnType("money");

                entity.Property(e => e.Siid).HasColumnName("SIId");

                entity.Property(e => e.SitypeId)
                    .HasColumnName("SITypeId")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<TblSalesInvoicePayments>(entity =>
            {
                entity.ToTable("tblSalesInvoicePayments");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.AmountApplied).HasColumnType("money");

                entity.Property(e => e.AmountAvailable)
                    .HasColumnType("money")
                    .HasComputedColumnSql("([Amount]-[AmountApplied])");

                entity.Property(e => e.CheckDate).HasColumnType("datetime");

                entity.Property(e => e.CheckRefNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedById).HasColumnName("CreatedByID");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DateVoided).HasColumnType("datetime");

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.Mopid).HasColumnName("MOPId");

                entity.Property(e => e.PreparedById).HasColumnName("PreparedByID");

                entity.Property(e => e.RefNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SystemNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UiamountApplied)
                    .HasColumnName("UIAmountApplied")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<TblSalesInvoices>(entity =>
            {
                entity.ToTable("tblSalesInvoices");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.AmountDue)
                    .HasColumnType("money")
                    .HasComputedColumnSql("(isnull([Amount],(0))-(isnull([AmountPaid],(0))+isnull([ReturnAmount],(0))))");

                entity.Property(e => e.AmountPaid)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Comments)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DateVoided).HasColumnType("datetime");

                entity.Property(e => e.DiscountAmount).HasColumnType("money");

                entity.Property(e => e.FaxNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GrossAmount).HasColumnType("money");

                entity.Property(e => e.LastEditedById).HasColumnName("LastEditedByID");

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.Mopid).HasColumnName("MOPId");

                entity.Property(e => e.RefNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReturnAmount).HasColumnType("money");

                entity.Property(e => e.SystemNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TermId).HasColumnName("TermID");

                entity.Property(e => e.Vatamount)
                    .HasColumnName("VATAmount")
                    .HasColumnType("money");

                entity.Property(e => e.Vatid).HasColumnName("VATId");
            });

            modelBuilder.Entity<TblSalesOrderDetails>(entity =>
            {
                entity.ToTable("tblSalesOrderDetails");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Discount).HasColumnType("money");

                entity.Property(e => e.QtyOnHand).HasDefaultValueSql("((0))");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubTotal).HasComputedColumnSql("([Qty]*[UnitPrice]-[Discount])");

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.Property(e => e.UnitPrice).HasColumnType("money");
            });

            modelBuilder.Entity<TblSalesOrders>(entity =>
            {
                entity.ToTable("tblSalesOrders");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Amount)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AmountDue)
                    .HasColumnType("money")
                    .HasComputedColumnSql("([Amount]-[AmountPaid])");

                entity.Property(e => e.AmountPaid)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ApprovedById).HasColumnName("ApprovedByID");

                entity.Property(e => e.Comments)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.FaxNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsDr).HasColumnName("IsDR");

                entity.Property(e => e.LastEditedById).HasColumnName("LastEditedByID");

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.PreparedById).HasColumnName("PreparedByID");

                entity.Property(e => e.RefNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SystemNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TelNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblSalesReturnDetails>(entity =>
            {
                entity.ToTable("tblSalesReturnDetails");

                entity.Property(e => e.Discount).HasColumnType("money");

                entity.Property(e => e.ReferenceNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SubTotal).HasComputedColumnSql("([Qty]*[UnitPrice]-[Discount])");

                entity.Property(e => e.UnitPrice).HasColumnType("money");
            });

            modelBuilder.Entity<TblSalesReturns>(entity =>
            {
                entity.ToTable("tblSalesReturns");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DateVoided).HasColumnType("datetime");

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.RefNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SystemNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblSecurityGroups>(entity =>
            {
                entity.ToTable("tblSecurityGroups");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModificationDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblSecurityGroupSecurityKeys>(entity =>
            {
                entity.ToTable("tblSecurityGroupSecurityKeys");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.SecurityGroup)
                    .WithMany(p => p.TblSecurityGroupSecurityKeys)
                    .HasForeignKey(d => d.SecurityGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSecurityGroupSecurityKeys_tblSecurityGroups");

                entity.HasOne(d => d.SecurityKey)
                    .WithMany(p => p.TblSecurityGroupSecurityKeys)
                    .HasForeignKey(d => d.SecurityKeyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSecurityGroupSecurityKeys_tblSecurityKeys");
            });

            modelBuilder.Entity<TblSecurityKeys>(entity =>
            {
                entity.ToTable("tblSecurityKeys");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Order).HasComputedColumnSql("([dbo].[fnMinFloat]([Id],[ParentId]))");

                entity.Property(e => e.SecurityKey)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblSecurityUserCompanies>(entity =>
            {
                entity.ToTable("tblSecurityUserCompanies");
            });

            modelBuilder.Entity<TblSecurityUserGroups>(entity =>
            {
                entity.ToTable("tblSecurityUserGroups");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblSecurityUserLevels>(entity =>
            {
                entity.ToTable("tblSecurityUserLevels");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblSecurityUsers>(entity =>
            {
                entity.ToTable("tblSecurityUsers");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoginName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModificationDate).HasColumnType("datetime");

                entity.Property(e => e.PasswordDate).HasColumnType("datetime");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordNeverExpires)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(104)
                    .IsUnicode(false)
                    .HasComputedColumnSql("((isnull(rtrim(ltrim([FirstName])),'')+isnull((' '+substring(case when len(rtrim(ltrim([MiddleName])))=(0) then NULL else rtrim(ltrim([MiddleName])) end,(1),(1)))+'.',''))+isnull(' '+rtrim(ltrim([LastName])),''))");
            });

            modelBuilder.Entity<TblSecurityUserSecurityGroups>(entity =>
            {
                entity.ToTable("tblSecurityUserSecurityGroups");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.SecurityGroup)
                    .WithMany(p => p.TblSecurityUserSecurityGroups)
                    .HasForeignKey(d => d.SecurityGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSecurityUserSecurityGroups_tblSecurityGroups");

                entity.HasOne(d => d.SecurityUser)
                    .WithMany(p => p.TblSecurityUserSecurityGroups)
                    .HasForeignKey(d => d.SecurityUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSecurityUserSecurityGroups_tblSecurityUsers");
            });

            modelBuilder.Entity<TblSecurityUserSecurityKeys>(entity =>
            {
                entity.ToTable("tblSecurityUserSecurityKeys");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.SecurityKey)
                    .WithMany(p => p.TblSecurityUserSecurityKeys)
                    .HasForeignKey(d => d.SecurityKeyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSecurityUserSecurityKeys_tblSecurityKeys");

                entity.HasOne(d => d.SecurityUser)
                    .WithMany(p => p.TblSecurityUserSecurityKeys)
                    .HasForeignKey(d => d.SecurityUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSecurityUserSecurityKeys_tblSecurityUsers");
            });

            modelBuilder.Entity<TblSeries>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("tblSeries");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.NumberFormat)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblSubAreas>(entity =>
            {
                entity.ToTable("tblSubAreas");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblSubOutletTypes>(entity =>
            {
                entity.ToTable("tblSubOutletTypes");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblSubsidiaries>(entity =>
            {
                entity.ToTable("tblSubsidiaries");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Code)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.ModificationDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.NameTemp)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RegisteredAddress)
                    .HasMaxLength(401)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(([RegisteredAddress1]+case when [RegisteredAddress2] IS NULL then '' else ' ' end)+[RegisteredAddress2])");

                entity.Property(e => e.RegisteredAddress1)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RegisteredAddress2)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RegisteredName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Tin)
                    .HasColumnName("TIN")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblSubsidiaryLedger>(entity =>
            {
                entity.HasKey(e => new { e.SubsidiaryId, e.AccountId, e.CompanyId, e.Date });

                entity.ToTable("tblSubsidiaryLedger");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Credit).HasColumnType("money");

                entity.Property(e => e.Debit).HasColumnType("money");

                entity.Property(e => e.EndBalance).HasColumnType("money");
            });

            modelBuilder.Entity<TblSubsidiaryTypes>(entity =>
            {
                entity.ToTable("tblSubsidiaryTypes");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name2)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblTerms>(entity =>
            {
                entity.ToTable("tblTerms");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblTransactionDetails>(entity =>
            {
                entity.HasKey(e => new { e.CompanyId, e.TypeId, e.Id, e.DetailId });

                entity.ToTable("tblTransactionDetails");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BegQty).HasComputedColumnSql("([EndQty]-[Quantity])");

                entity.Property(e => e.QtyIn).HasComputedColumnSql("(case when [Quantity]>(0) then [Quantity] else (0) end)");

                entity.Property(e => e.QtyOut).HasComputedColumnSql("(case when [Quantity]<(0) then abs([Quantity]) else (0) end)");

                entity.Property(e => e.WarehouseBegQty).HasComputedColumnSql("([WarehouseEndQty]-[Quantity])");
            });

            modelBuilder.Entity<TblTransactions>(entity =>
            {
                entity.HasKey(e => new { e.CompanyId, e.TypeId, e.Id });

                entity.ToTable("tblTransactions");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblTransactionTypes>(entity =>
            {
                entity.ToTable("tblTransactionTypes");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUnits>(entity =>
            {
                entity.ToTable("tblUnits");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.LastEditedById).HasColumnName("LastEditedByID");

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblVat>(entity =>
            {
                entity.ToTable("tblVAT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblVendor>(entity =>
            {
                entity.ToTable("tblVendor");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.FaxNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TelNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblVendorCreditMemo>(entity =>
            {
                entity.ToTable("tblVendorCreditMemo");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.AmountApplied).HasColumnType("money");

                entity.Property(e => e.AmountAvailable)
                    .HasColumnType("money")
                    .HasComputedColumnSql("([Amount]-[AmountApplied])");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateForfeited).HasColumnType("datetime");

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.ReferenceNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SourceSystemNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SystemNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblVendorItems>(entity =>
            {
                entity.ToTable("tblVendorItems");

                entity.Property(e => e.CostPrice).HasColumnType("money");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VendorId).HasColumnName("VendorID");
            });

            modelBuilder.Entity<TblWarehouseInventoryLedger>(entity =>
            {
                entity.HasKey(e => new { e.CompanyId, e.WarehouseId, e.ItemId, e.Date });

                entity.ToTable("tblWarehouseInventoryLedger");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.BegQty).HasComputedColumnSql("([EndQty]-([TotalIn]-[TotalOut]))");

                entity.Property(e => e.EndTotalCost).HasColumnType("money");

                entity.Property(e => e.TotalInCost).HasColumnType("money");

                entity.Property(e => e.TotalOutCost).HasColumnType("money");
            });

            modelBuilder.Entity<TblWarehouses>(entity =>
            {
                entity.ToTable("tblWarehouses");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.LastEditedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
