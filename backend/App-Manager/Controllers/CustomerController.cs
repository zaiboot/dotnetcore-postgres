using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AppManager.Repository;
using AppManager.Repository.DTO;
using AppManager.Api.Mapping;
using AppManager.Models;

namespace AppManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : CustomersAppControllerBase, IAppController
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(IMappingEngine mappingEngine, ILogger<CustomersAppControllerBase> logger, ICustomerRepository customerRepository) : base(mappingEngine, logger)
        {
            _customerRepository = customerRepository;
        }
        [HttpPost]
        public ActionResult InitPromotion(PromotionRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
