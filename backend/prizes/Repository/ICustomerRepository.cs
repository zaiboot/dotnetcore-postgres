using prizes.Repository.DTO;

namespace prizes.Repository
{
    public interface ICustomerRepository
    {
        CustomerInformation GetCustomerInformation(int customerId);
    }
}