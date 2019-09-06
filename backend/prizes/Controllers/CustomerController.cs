using Microsoft.AspNetCore.Mvc;
using prizes.Repository;
using Prizes.Models;

namespace prizes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase, ICustomerController
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository) //TODO: Add DI
        {
            _customerRepository = customerRepository;
        }


        // GET api/values
        [HttpGet]
        public ActionResult<Customer> Get()
        {
            return  _customerRepository.GetCustomerInformation(1);
        }

    }
}
