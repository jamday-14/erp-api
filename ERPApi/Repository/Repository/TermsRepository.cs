using Contracts;
using Entities.Models;

namespace Services
{
    public class TermsRepository : RepositoryBase<TblTerms>, ITermsRepository
    {
        public TermsRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
