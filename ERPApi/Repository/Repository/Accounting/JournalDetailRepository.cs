using System.Linq;
using Contracts;
using Entities.Models;

namespace Services
{
    public class JournalDetailRepository : RepositoryBase<TblJournalDetails>, IJournalDetailRepository
    {
        public JournalDetailRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }

        public IQueryable<TblJournalDetails> GetByJournalId(int id)
        {
            return RepositoryContext.TblJournalDetails.Where(x => x.JournalId == id)
                .OrderBy(x => x.Id);
        }
    }
}
