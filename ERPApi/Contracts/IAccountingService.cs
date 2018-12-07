namespace Contracts
{
    public interface IAccountingService
    {
        IBillPaymentRepository BillPaymentRepo { get; }
        ISalesInvoicePaymentRepository SalesInvoicePaymentRepo { get; }

        void Save();
    }
}
