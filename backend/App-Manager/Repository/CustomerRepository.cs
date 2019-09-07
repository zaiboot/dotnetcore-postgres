using System.Linq;
using AppManager.Repository.DTO;

namespace AppManager.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public CustomerRepository()
        {
        }
        public CustomerInformation GetCustomerInformation(int customerId)
        {
            return null;
        }
    }
}