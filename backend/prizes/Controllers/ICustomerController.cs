using Microsoft.AspNetCore.Mvc;
using Prizes.Models;

namespace Prizes.Controllers
{
    public interface ICustomerController
    {
        ActionResult<Customer> Get();
    }
}