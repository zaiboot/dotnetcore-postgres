using Microsoft.AspNetCore.Mvc;
using Customers.Models;
using System.Threading.Tasks;

namespace Customers.Controllers
{
    public interface ICustomerController
    {
        ActionResult<Customer> Get(int id);
        Task<CustomerCreateResult> CreateCustomer(CreateCustomerRequest request);
    }
}