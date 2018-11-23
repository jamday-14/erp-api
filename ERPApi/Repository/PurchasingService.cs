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
    }
}
