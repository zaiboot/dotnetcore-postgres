using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prizes.Repository;
using Prizes.Repository.DTO;
using Prizes.Api.Mapping;
using Prizes.Models;

namespace Prizes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : PrizesAppControllerBase, ICustomerController
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(IMappingEngine mappingEngine, ILogger<PrizesAppControllerBase> logger, ICustomerRepository customerRepository) : base(mappingEngine, logger)
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
