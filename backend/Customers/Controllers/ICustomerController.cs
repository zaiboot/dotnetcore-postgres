using Microsoft.AspNetCore.Mvc;
using Customers.Models;

namespace Customers.Controllers
{
    public interface ICustomerController
    {
        ActionResult<Customer> Get();
    }
}