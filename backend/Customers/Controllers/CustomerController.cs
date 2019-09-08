using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Customers.Repository;
using Customers.Repository.DTO;
using Customers.Api.Mapping;
using Customers.Models;
using System.Threading.Tasks;

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
        
        [HttpPost]
        public async Task<CustomerCreateResult> CreateCustomer(CreateCustomerRequest request)
        {
            var newCustomer = await _customerRepository.CreateCustomerAsync(request);
            var result = new CustomerCreateResult
            {
                CustomerId = newCustomer.Id
            };
            return result;

        }

        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            var c = _customerRepository.GetCustomerInformation(id);
            //Async calls needs to be resolved later.
            // The main problem here is the mapper not being async
            return base._mappingEngine.Map<CustomerInformation, Customer>(c);
        }

    }
}
