using Microsoft.AspNetCore.Mvc;
using Prizes.Models;

namespace prizes.Controllers
{
    public interface ICustomerController
    {
        ActionResult<Customer> Get();
    }
}