using prizes.Repository.DTO;

namespace prizes.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public CustomerInformation GetCustomerInformation(int customerId)
        {
            return new CustomerInformation {
                CustomerName = "Edgar Madrigal",
                ClaimedAmount= 10.5F
            };
        }
    }
}