using Entities.Models;
using System.Linq;

namespace Contracts
{
    public interface IItemEntryDetailRepository : IRepositoryBase<TblItemEntryDetails>
    {
        IQueryable<TblItemEntryDetails> GetByItemEntryId(int id);
    }
}
