using Entities.Models;
using System.Linq;

namespace Contracts
{
    public interface IJournalDetailRepository : IRepositoryBase<TblJournalDetails>
    {
        IQueryable<TblJournalDetails> GetByJournalId(int id);
    }
}
