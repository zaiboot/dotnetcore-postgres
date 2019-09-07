using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Customers.Repository;
using Customers.Repository.DTO;
using Customers.Api.Mapping;
using Customers.Models;

namespace Customers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : CustomersAppControllerBase, ICustomerController
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(IMappingEngine mappingEngine, ILogger<CustomersAppControllerBase> logger, ICustomerRepository customerRepository) : base(mappingEngine, logger)
        {
            _customerRepository = customerRepository;
        }
        
        [HttpGet]
        public ActionResult<Customer> Get()
        {
            var customerId = 1;            
            var c = _customerRepository.GetCustomerInformation(customerId);
            //Async calls needs to be resolved later.
            // The main problem here is the mapper not being async
            return base._mappingEngine.Map<CustomerInformation,Customer>(c);
        }

    }
}
