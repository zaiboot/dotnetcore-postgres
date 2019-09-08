using System.Threading.Tasks;
using Customers.Models;
using Customers.Repository.DTO;

namespace Customers.Repository
{
    public interface ICustomerRepository
    {
        CustomerInformation GetCustomerInformation(int customerId);
        Task<CustomerInformation> CreateCustomerAsync(CreateCustomerRequest request);
    }
}