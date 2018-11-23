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
    }
}
