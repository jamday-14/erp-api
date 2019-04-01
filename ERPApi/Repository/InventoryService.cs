using AutoMapper;
using Contracts;
using Entities.Models;
using System;
using System.Linq;

namespace Services
{
    public class InventoryService : IInventoryService
    {
        private ERPContext _repoContext;
        private readonly IMapper _mapper;

        public InventoryService(ERPContext repositoryContext, IMapper mapper)
        {
            _repoContext = repositoryContext;
            _mapper = mapper;
        }

        #region PRIVATE REPOSITORY INTERFACES
        private IGoodsTransferReceiveRepository _goodsTransferReceivedRepo;
        private IGoodsTransferRepository _goodsTransferRepo;
        private IItemEntryRepository _itemEntryRepo;
        private IItemReleaseRepository _itemReleaseRepo;
        private IInventoryRepository _inventoryRepo;
        private IInventoryLedgerRepository _inventoryLedgerRepo;
        private IItemEntryDetailRepository _itemEntryDetailRepo;
        private IItemReleaseDetailRepository _itemReleaseDetailRepo;
        private IGoodsTransferDetailRepository _goodsTransferDetailRepo;
        private IGoodsTransferReceivedDetailRepository _goodsTransferReceivedDetailRepo;
        #endregion

        #region REPOSITORY GETTERS
        public IGoodsTransferReceiveRepository GoodsTransferReceivedRepo
        {
            get
            {
                if (_goodsTransferReceivedRepo == null)
                {
                    _goodsTransferReceivedRepo = new GoodsTransferReceiveRepository(_repoContext);
                }
                return _goodsTransferReceivedRepo;
            }
        }

        public IGoodsTransferRepository GoodsTransferRepo
        {
            get
            {
                if (_goodsTransferRepo == null)
                {
                    _goodsTransferRepo = new GoodsTransferRepository(_repoContext);
                }
                return _goodsTransferRepo;
            }
        }

        public IItemEntryRepository ItemEntryRepo
        {
            get
            {
                if (_itemEntryRepo == null)
                {
                    _itemEntryRepo = new ItemEntryRepository(_repoContext);
                }
                return _itemEntryRepo;
            }
        }

        public IItemReleaseRepository ItemReleaseRepo
        {
            get
            {
                if (_itemReleaseRepo == null)
                {
                    _itemReleaseRepo = new ItemReleaseRepository(_repoContext);
                }
                return _itemReleaseRepo;
            }
        }

        public IInventoryRepository InventoryRepo
        {
            get
            {
                if (_inventoryRepo == null)
                {
                    _inventoryRepo = new InventoryRepository(_repoContext);
                }
                return _inventoryRepo;
            }
        }

        public IInventoryLedgerRepository InventoryLedgerRepo
        {
            get
            {
                if (_inventoryLedgerRepo == null)
                {
                    _inventoryLedgerRepo = new InventoryLedgerRepository(_repoContext);
                }
                return _inventoryLedgerRepo;
            }
        }

        public IItemEntryDetailRepository ItemEntryDetailRepo
        {
            get
            {
                if (_itemEntryDetailRepo == null)
                {
                    _itemEntryDetailRepo = new ItemEntryDetailRepository(_repoContext);
                }
                return _itemEntryDetailRepo;
            }
        }

        public IItemReleaseDetailRepository ItemReleaseDetailRepo
        {
            get
            {
                if (_itemReleaseDetailRepo == null)
                {
                    _itemReleaseDetailRepo = new ItemReleaseDetailRepository(_repoContext);
                }
                return _itemReleaseDetailRepo;
            }
        }

        public IGoodsTransferDetailRepository GoodsTransferDetailRepo
        {
            get
            {
                if (_goodsTransferDetailRepo == null)
                {
                    _goodsTransferDetailRepo = new GoodsTransferDetailRepository(_repoContext);
                }
                return _goodsTransferDetailRepo;
            }
        }

        public IGoodsTransferReceivedDetailRepository GoodsTransferReceivedDetailRepo
        {
            get
            {
                if (_goodsTransferReceivedDetailRepo == null)
                {
                    _goodsTransferReceivedDetailRepo = new GoodsTransferReceivedDetailRepository(_repoContext);
                }
                return _goodsTransferReceivedDetailRepo;
            }
        }


        public void Save()
        {
            _repoContext.SaveChanges();
        }

        public void PostInventory(int warehouseId, int itemId, double qty, decimal unitPrice, bool isDeduction = false)
        {
            TblInventory inventory = null;
            TblInventoryLedger ledger = null;
            int companyId = 1;

            inventory = InventoryRepo.FindByCondition(x => x.WareHouseId == warehouseId && x.ItemId == itemId).FirstOrDefault();
            ledger = InventoryLedgerRepo.FindByCondition(x => x.CompanyId == companyId && x.ItemId == itemId && x.Date == DateTime.Today).FirstOrDefault();

            if (inventory == null)
            {
                inventory = new TblInventory { WareHouseId = warehouseId, ItemId = itemId, CompanyId = companyId, Quantity = 0 };
                InventoryRepo.Create(inventory);
            }
                
            if (ledger == null)
            {
                ledger = new TblInventoryLedger { CompanyId = companyId, Date = DateTime.Today, ItemId = itemId, TotalIn = 0, TotalOut = 0 };
                InventoryLedgerRepo.Create(ledger);
            }

            if (isDeduction)
            {
                inventory.Quantity -= qty;
                ledger.TotalOut += qty;
            }
            else
            {
                inventory.Quantity += qty;
                ledger.TotalIn += qty;
            }

            ledger.EndQty = ledger.TotalIn - ledger.TotalOut;

            var previousLedger = InventoryLedgerRepo.FindByCondition(x => x.CompanyId == companyId && x.ItemId == itemId && x.Date != DateTime.Today)
                .OrderByDescending(x => x.Date).FirstOrDefault();

            if (previousLedger != null)
                ledger.EndQty += previousLedger.EndQty;
        }
        #endregion
    }
}
