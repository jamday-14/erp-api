namespace Contracts
{
    public interface IInventoryService
    {
        IGoodsTransferReceiveRepository GoodsTransferReceivedRepo { get; }
        IGoodsTransferRepository GoodsTransferRepo { get; }
        IItemEntryRepository ItemEntryRepo { get; }

        IItemReleaseRepository ItemReleaseRepo { get; }

        void Save();
    }
}
