namespace Contracts
{
    public interface IAccountingService
    {
        IBillPaymentRepository BillPaymentRepo { get; }
        IBillPaymentDetailRepository BillPaymentDetailRepo { get; }
        ISalesInvoicePaymentRepository SalesInvoicePaymentRepo { get; }
        ISalesInvoicePaymentDetailRepository SalesInvoicePaymentDetailRepo { get; }
        IJournalRepository JournalRepo { get; }
        IJournalDetailRepository JournalDetailRepo { get; }
        IAccountRepository AccountRepo { get; }

        void Save();
    }
}
