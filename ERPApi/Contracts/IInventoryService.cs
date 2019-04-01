namespace Contracts
{
    public interface IInventoryService
    {
        IGoodsTransferReceiveRepository GoodsTransferReceivedRepo { get; }
        IGoodsTransferRepository GoodsTransferRepo { get; }
        IItemEntryRepository ItemEntryRepo { get; }

        IItemReleaseRepository ItemReleaseRepo { get; }
        IInventoryRepository InventoryRepo { get; }
        IInventoryLedgerRepository InventoryLedgerRepo { get; }

        IItemEntryDetailRepository ItemEntryDetailRepo { get; }
        IItemReleaseDetailRepository ItemReleaseDetailRepo { get; }
        IGoodsTransferDetailRepository GoodsTransferDetailRepo { get; }
        IGoodsTransferReceivedDetailRepository GoodsTransferReceivedDetailRepo { get; }

        void Save();
        void PostInventory(int warehouseId, int itemId, double qty, decimal unitPrice, bool isDeduction = false);
    }
}
