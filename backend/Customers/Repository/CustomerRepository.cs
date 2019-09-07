using System.Linq;
using Customers.DataContext;
using Customers.Repository.DTO;

namespace Customers.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDataContext context;

        public CustomerRepository(CustomerDataContext context)
        {
            this.context = context;
        }
        public CustomerInformation GetCustomerInformation(int customerId)
        {
            return context.Customer.First();
        }
    }
}