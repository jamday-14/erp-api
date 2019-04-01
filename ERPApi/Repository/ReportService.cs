using AutoMapper;
using Contracts;
using Entities.Models;

namespace Services
{
    public class ReportService: IReportService
    {
        private ERPContext _repoContext;
        private readonly IMapper _mapper;

        public ReportService(ERPContext repositoryContext, IMapper mapper)
        {
            _repoContext = repositoryContext;
            _mapper = mapper;
        }
    }
}
