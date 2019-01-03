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

        List<TblDeliveryReceipts> GetPendingDeliveryReceiptsByCustomer(int customerId);

        void Save();
        List<TblDeliveryReceiptDetails> GetDeliveryReceiptDetails(int id);
        List<TblSalesOrders> GetPendingSalesOrdersByCustomer(int customerId);
        List<TblSalesOrderDetails> GetSalesOrderDetails(int id);
    }
}
