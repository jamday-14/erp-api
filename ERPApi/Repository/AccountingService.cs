using AutoMapper;
using Contracts;
using Entities.Models;

namespace Services
{
    public class AccountingService : IAccountingService
    {
        private ERPContext _repoContext;
        private readonly IMapper _mapper;

        public AccountingService(ERPContext repositoryContext, IMapper mapper)
        {
            _repoContext = repositoryContext;
            _mapper = mapper;
        }

        #region PRIVATE REPOSITORY INTERFACES
        private IBillPaymentRepository _billPaymentRepo;
        private ISalesInvoicePaymentRepository _salesInvoicePaymentRepo;
        #endregion

        #region REPOSITORY GETTERS

        public IBillPaymentRepository BillPaymentRepo
        {
            get
            {
                if (_billPaymentRepo == null)
                {
                    _billPaymentRepo = new BillPaymentRepository(_repoContext);
                }
                return _billPaymentRepo;
            }
        }

        public ISalesInvoicePaymentRepository SalesInvoicePaymentRepo
        {
            get
            {
                if (_salesInvoicePaymentRepo == null)
                {
                    _salesInvoicePaymentRepo = new SalesInvoicePaymentRepository(_repoContext);
                }
                return _salesInvoicePaymentRepo;
            }
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
        #endregion
    }
}
