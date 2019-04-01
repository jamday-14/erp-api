using Entities.Models;
using System.Linq;

namespace Contracts
{
    public interface IItemReleaseDetailRepository : IRepositoryBase<TblItemReleaseDetails>
    {
        IQueryable<TblItemReleaseDetails> GetByItemReleaseId(int id);
    }
}
