using System.Linq;
using prizes.Repository.DTO;

namespace prizes.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApiDataContext context;

        public CustomerRepository(ApiDataContext context)
        {
            this.context = context;
        }
        public CustomerInformation GetCustomerInformation(int customerId)
        {
            return context.Customer.First();
        }
    }
}