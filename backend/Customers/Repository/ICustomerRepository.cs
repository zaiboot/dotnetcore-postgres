using Customers.Repository.DTO;

namespace Customers.Repository
{
    public interface ICustomerRepository
    {
        CustomerInformation GetCustomerInformation(int customerId);
    }
}