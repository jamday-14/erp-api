using Entities.Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface ISalesService
    {
        ISalesOrderRepository SalesOrderRepo { get;  }
        ISalesInvoiceRepository SalesInvoiceRepo { get; }
        ISalesReturnRepository SalesReturnRepo { get; }
        IDeliveryReceiptRepository DeliveryReceiptRepo { get; }

        ISalesOrderDetailRepository SalesOrderDetailRepo { get; }
        IDeliveryReceiptDetailRepository DeliveryReceiptDetailRepo { get; }
        ISalesInvoiceDetailRepository SalesInvoiceDetailRepo { get; }
        ISalesReturnDetailRepository SalesReturnDetailRepo { get; }
        

        void Save();
        
        List<TblSalesOrders> GetPendingSalesOrdersByCustomer(int customerId);
        List<TblSalesOrderDetails> GetSalesOrderDetails(int id);

        List<TblDeliveryReceipts> GetPendingDeliveryReceiptsByCustomer(int customerId);
        List<TblDeliveryReceipts> GetDeliveryReceiptsByCustomer(int customerId);
        List<TblDeliveryReceiptDetails> GetDeliveryReceiptDetails(int id);
        List<TblDeliveryReceiptDetails> GetDeliveryReceiptDetailsPendingInvoice(int id);
    }
}
