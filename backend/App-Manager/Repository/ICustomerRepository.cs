using AppManager.Repository.DTO;

namespace AppManager.Repository
{
    public interface ICustomerRepository
    {
        CustomerInformation GetCustomerInformation(int customerId);
    }
}