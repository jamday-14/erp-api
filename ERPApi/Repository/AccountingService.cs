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
        private IBillPaymentDetailRepository _billPaymentDetailRepo;
        private ISalesInvoicePaymentDetailRepository _salesInvoicePaymentDetailRepo;
        private IJournalRepository _journalRepo;
        private IJournalDetailRepository _journalDetailRepo;
        private IAccountRepository _accountRepo;

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

        public IBillPaymentDetailRepository BillPaymentDetailRepo
        {
            get
            {
                if (_billPaymentDetailRepo == null)
                {
                    _billPaymentDetailRepo = new BillPaymentDetailRepository(_repoContext);
                }
                return _billPaymentDetailRepo;
            }
        }

        public ISalesInvoicePaymentDetailRepository SalesInvoicePaymentDetailRepo
        {
            get
            {
                if (_salesInvoicePaymentDetailRepo == null)
                {
                    _salesInvoicePaymentDetailRepo = new SalesInvoicePaymentDetailRepository(_repoContext);
                }
                return _salesInvoicePaymentDetailRepo;
            }
        }

        public IJournalRepository JournalRepo
        {
            get
            {
                if (_journalRepo == null)
                {
                    _journalRepo = new JournalRepository(_repoContext);
                }
                return _journalRepo;
            }
        }

        public IJournalDetailRepository JournalDetailRepo
        {
            get
            {
                if (_journalDetailRepo == null)
                {
                    _journalDetailRepo = new JournalDetailRepository(_repoContext);
                }
                return _journalDetailRepo;
            }
        }

        public IAccountRepository AccountRepo
        {
            get
            {
                if (_accountRepo == null)
                {
                    _accountRepo = new AccountRepository(_repoContext);
                }
                return _accountRepo;
            }
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
        #endregion
    }
}
