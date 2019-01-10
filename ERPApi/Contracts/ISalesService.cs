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
        
    }
}
