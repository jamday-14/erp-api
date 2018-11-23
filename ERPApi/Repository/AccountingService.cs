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
    }
}
