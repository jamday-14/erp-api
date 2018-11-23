using AutoMapper;
using Contracts;
using Entities.Models;

namespace Services
{
    public class InventoryService: IInventoryService
    {
        private ERPContext _repoContext;
        private readonly IMapper _mapper;

        public InventoryService(ERPContext repositoryContext, IMapper mapper)
        {
            _repoContext = repositoryContext;
            _mapper = mapper;
        }
    }
}
