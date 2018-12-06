namespace Contracts
{
    public interface IPurchasingService
    {
        IPurchaseOrderRepository PurchaseOrderRepo { get; }
        IPurchaseReturnRepository PurchaseReturnRepo { get; }
        IBillRepository BillRepo { get; }
        IReceivingReportRepository ReceivingReportRepo { get; }
        void Save();
    }
}
