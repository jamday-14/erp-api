namespace Contracts
{
    public interface IPurchasingService
    {
        IPurchaseOrderRepository PurchaseOrderRepo { get; }
        IPurchaseReturnRepository PurchaseReturnRepo { get; }
        IBillRepository BillRepo { get; }
        IReceivingReportRepository ReceivingReportRepo { get; }

        IPurchaseOrderDetailRepository PurchaseOrderDetailRepo { get; }
        IPurchaseReturnDetailRepository PurchaseReturnDetailRepo { get; }
        IBillDetailRepository BillDetailRepo { get; }
        IReceivingReportDetailRepository ReceivingReportDetailRepo { get; }
        void Save();
    }
}
