using System.Linq;
using Prizes.DataContext;
using Prizes.Repository.DTO;

namespace Prizes.Repository
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