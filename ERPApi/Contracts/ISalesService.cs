namespace Contracts
{
    public interface ISalesService
    {
        ISalesOrderRepository SalesOrderRepo { get;  }
        ISalesInvoiceRepository SalesInvoiceRepo { get; }
        ISalesReturnRepository SalesReturnRepo { get; }
        IDeliveryReceiptRepository DeliveryReceiptRepo { get; }

        void Save();
    }
}
