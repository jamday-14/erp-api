using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Contracts;
using Entities.ExtendedModels;
using Entities.Models;

namespace Services
{
    public class MaintenanceService : IMaintenanceService
    {
        private ERPContext _repoContext;
        private readonly IMapper _mapper;

        private ICustomerRepository _customer;

        public MaintenanceService(ERPContext repositoryContext, IMapper mapper)
        {
            _repoContext = repositoryContext;
            _mapper = mapper;
        }

        public ICustomerRepository Customer
        {
            get
            {
                if (_customer == null)
                {
                    _customer = new CustomerRepository(_repoContext);
                }
                return _customer;
            }
        }

        public IList<Customer> GetCustomers()
        {
            var customers = Customer.GetAllCustomers().ToList();

            return _mapper.Map<List<Customer>>(customers);
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
