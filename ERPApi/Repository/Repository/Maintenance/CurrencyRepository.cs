using Contracts;
using Entities.Models;

namespace Services
{
    public class CurrencyRepository : RepositoryBase<TblCurrencies>, ICurrencyRepository
    {
        public CurrencyRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
