using System.Threading.Tasks;
using AppManager.DTO;

namespace AppManager.Repository
{
    public interface ICustomerRepository
    {
        Task<CustomerCreateResult> Create(CustomerCreateRequest customerCreateRequest);
    }
}