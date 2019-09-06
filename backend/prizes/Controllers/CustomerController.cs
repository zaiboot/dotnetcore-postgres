using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using prizes.Repository;
using prizes.Repository.DTO;
using Prizes.Api.Mapping;
using Prizes.Models;

namespace prizes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : PrizesControllerBase, ICustomerController
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(IMappingEngine mappingEngine, ILogger<PrizesControllerBase> logger, ICustomerRepository customerRepository) : base(mappingEngine, logger)
        {
            _customerRepository = customerRepository;
        }


        // GET api/values
        [HttpGet]
        public ActionResult<Customer> Get()
        {
            var customerId = 1;            
            var c = _customerRepository.GetCustomerInformation(customerId);
            //Async calls needs to be resolved later.
            // The main probleme here is the mapper not being async
            return base._mappingEngine.Map<CustomerInformation,Customer>(c);
        }

    }
}
