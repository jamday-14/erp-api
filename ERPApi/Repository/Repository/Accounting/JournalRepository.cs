using Contracts;
using Entities.Models;

namespace Services
{
    public class JournalRepository : RepositoryBase<TblJournals>, IJournalRepository
    {
        public JournalRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
