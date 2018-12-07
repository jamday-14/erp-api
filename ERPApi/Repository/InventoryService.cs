using AutoMapper;
using Contracts;
using Entities.Models;

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

        public void Save()
        {
            _repoContext.SaveChanges();
        }
        #endregion
    }
}
