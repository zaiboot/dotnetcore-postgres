using System.Linq;
using prizes.Repository.DTO;

namespace prizes.Repository
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