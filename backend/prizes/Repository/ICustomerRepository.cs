using Prizes.Repository.DTO;

namespace Prizes.Repository
{
    public interface ICustomerRepository
    {
        CustomerInformation GetCustomerInformation(int customerId);
    }
}