using Microsoft.AspNetCore.Mvc;
using Customers.Models;
using System.Threading.Tasks;

namespace Customers.Controllers
{
    public interface ICustomerController
    {
        ActionResult<Customer> Get();
        Task<CustomerCreateResult> CreateCustomer(CreateCustomerRequest request);
    }
}