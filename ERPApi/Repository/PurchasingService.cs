using AutoMapper;
using Contracts;
using Entities.Models;

namespace Services
{
    public class PurchasingService: IPurchasingService
    {
        private ERPContext _repoContext;
        private readonly IMapper _mapper;

        public PurchasingService(ERPContext repositoryContext, IMapper mapper)
        {
            _repoContext = repositoryContext;
            _mapper = mapper;
        }

        #region PRIVATE REPOSITORY INTERFACES
        private IPurchaseOrderRepository _purchaseOrderRepo;
        private IPurchaseReturnRepository _purchaseReturnRepo;
        private IBillRepository _billRepo;
        private IReceivingReportRepository _receivingReportRepo;
        #endregion

        #region REPOSITORY GETTERS
        public IPurchaseOrderRepository PurchaseOrderRepo
        {
            get
            {
                if (_purchaseOrderRepo == null)
                {
                    _purchaseOrderRepo = new PurchaseOrderRepository(_repoContext);
                }
                return _purchaseOrderRepo;
            }
        }

        public IPurchaseReturnRepository PurchaseReturnRepo
        {
            get
            {
                if (_purchaseReturnRepo == null)
                {
                    _purchaseReturnRepo = new PurchaseReturnRepository(_repoContext);
                }
                return _purchaseReturnRepo;
            }
        }

        public IBillRepository BillRepo
        {
            get
            {
                if (_billRepo == null)
                {
                    _billRepo = new BillRepository(_repoContext);
                }
                return _billRepo;
            }
        }

        public IReceivingReportRepository ReceivingReportRepo
        {
            get
            {
                if (_receivingReportRepo == null)
                {
                    _receivingReportRepo = new ReceivingReportRepository(_repoContext);
                }
                return _receivingReportRepo;
            }
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
        #endregion
    }
}
