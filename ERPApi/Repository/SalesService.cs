using AutoMapper;
using Contracts;
using Entities.Models;

namespace Services
{
    public class SalesService : ISalesService
    {
        private ERPContext _repoContext;
        private readonly IMapper _mapper;

        public SalesService(ERPContext repositoryContext, IMapper mapper)
        {
            _repoContext = repositoryContext;
            _mapper = mapper;
        }

        #region PRIVATE REPOSITORY INTERFACES
        private ISalesOrderRepository _salesOrderRepo;
        private ISalesInvoiceRepository _salesInvoiceRepo;
        private ISalesReturnRepository _salesReturnRepo;
        private IDeliveryReceiptRepository _deliveryReceiptRepo;
        #endregion

        #region REPOSITORY GETTERS
        public ISalesOrderRepository SalesOrderRepo
        {
            get
            {
                if (_salesOrderRepo == null)
                {
                    _salesOrderRepo = new SalesOrderRepository(_repoContext);
                }
                return _salesOrderRepo;
            }
        }

        public ISalesInvoiceRepository SalesInvoiceRepo
        {
            get
            {
                if (_salesInvoiceRepo == null)
                {
                    _salesInvoiceRepo = new SalesInvoiceRepository(_repoContext);
                }
                return _salesInvoiceRepo;
            }
        }

        public ISalesReturnRepository SalesReturnRepo
        {
            get
            {
                if (_salesReturnRepo == null)
                {
                    _salesReturnRepo = new SalesReturnRepository(_repoContext);
                }
                return _salesReturnRepo;
            }
        }

        public IDeliveryReceiptRepository DeliveryReceiptRepo
        {
            get
            {
                if (_deliveryReceiptRepo == null)
                {
                    _deliveryReceiptRepo = new DeliveryReceiptRepository(_repoContext);
                }
                return _deliveryReceiptRepo;
            }
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
        #endregion
    }
}
