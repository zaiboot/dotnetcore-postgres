using System.Linq;
using AppManager.DataContext;
using AppManager.Repository.DTO;

namespace AppManager.Repository
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