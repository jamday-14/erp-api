using Contracts;
using Entities.Models;

namespace Services
{
    public class BillPaymentRepository : RepositoryBase<TblBillPayments>, IBillPaymentRepository
    {
        public BillPaymentRepository(ERPContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
