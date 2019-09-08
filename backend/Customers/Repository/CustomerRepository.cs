using System.Linq;
using System.Threading.Tasks;
using Customers.Api.Mapping;
using Customers.DataContext;
using Customers.Models;
using Customers.Repository.DTO;

namespace Customers.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDataContext context;
        private readonly IMappingEngine mappingEngine;

        public CustomerRepository(CustomerDataContext context, IMappingEngine mappingEngine)
        {
            this.context = context;
            this.mappingEngine = mappingEngine;
        }

        public async Task<CustomerInformation> CreateCustomerAsync(CreateCustomerRequest request)
        {
            var newCustomerRequest = mappingEngine.Map<CreateCustomerRequest, CustomerInformation>(request);
            var newCustomer = await this.context.Customer.AddAsync(newCustomerRequest);
            return newCustomer.Entity;
        }


        public CustomerInformation GetCustomerInformation(int customerId)
        {
            return context.Customer.First();
        }
    }
}