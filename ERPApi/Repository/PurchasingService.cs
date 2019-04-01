using AutoMapper;
using Contracts;
using Entities.Models;
using System.Linq;

namespace Services
{
    public class PurchasingService : IPurchasingService
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

        private IPurchaseOrderDetailRepository _purchaseOrderDetailRepo;
        private IPurchaseReturnDetailRepository _purchaseReturnDetailRepo;
        private IBillDetailRepository _billDetailRepo;
        private IReceivingReportDetailRepository _receivingReportDetailRepo;
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

        public IPurchaseOrderDetailRepository PurchaseOrderDetailRepo
        {
            get
            {
                if (_purchaseOrderDetailRepo == null)
                {
                    _purchaseOrderDetailRepo = new PurchaseOrderDetailRepository(_repoContext);
                }
                return _purchaseOrderDetailRepo;
            }
        }

        public IPurchaseReturnDetailRepository PurchaseReturnDetailRepo
        {
            get
            {
                if (_purchaseReturnDetailRepo == null)
                {
                    _purchaseReturnDetailRepo = new PurchaseReturnDetailRepository(_repoContext);
                }
                return _purchaseReturnDetailRepo;
            }
        }

        public IBillDetailRepository BillDetailRepo
        {
            get
            {
                if (_billDetailRepo == null)
                {
                    _billDetailRepo = new BillDetailRepository(_repoContext);
                }
                return _billDetailRepo;
            }
        }

        public IReceivingReportDetailRepository ReceivingReportDetailRepo
        {
            get
            {
                if (_receivingReportDetailRepo == null)
                {
                    _receivingReportDetailRepo = new ReceivingReportDetailRepository(_repoContext);
                }
                return _receivingReportDetailRepo;
            }
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }

        public void PayBill(int billId, decimal amount)
        {
            var bill = BillRepo.FindByCondition(x => x.Id == billId).FirstOrDefault();

            if (bill != null)
            {
                bill.AmountPaid += amount;
                bill.AmountDue -= amount;
                bill.Closed = bill.AmountDue == 0;
            }
        }
        #endregion
    }
}
