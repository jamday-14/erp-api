using System.Linq;
using Contracts;
using Entities.Models;

namespace Services
{
    public class BillPaymentDetailRepository : RepositoryBase<TblBillPaymentDetails>, IBillPaymentDetailRepository
    {
        public BillPaymentDetailRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }

        public IQueryable<TblBillPaymentDetails> GetByBillPaymentId(int id)
        {
            return RepositoryContext.TblBillPaymentDetails.Where(x => x.BillPaymentId == id)
               .OrderBy(x => x.Id);
        }
    }
}
