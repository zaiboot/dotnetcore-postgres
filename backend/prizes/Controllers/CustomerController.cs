using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Prizes.Models;

namespace prizes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<Customer> Get()
        {
            return new Customer();
        }

    }
}
