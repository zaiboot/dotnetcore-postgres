using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AppManager.Repository;
using AppManager.Api.Mapping;
using AppManager.Models;

namespace AppManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : AppControllerBase, IAppController
    {
        private readonly ICustomerRepository _customerRepository;

        public AppController(IMappingEngine mappingEngine, ILogger<AppControllerBase> logger, ICustomerRepository customerRepository) : base(mappingEngine, logger)
        {
            _customerRepository = customerRepository;
        }
        [HttpPost]
        public ActionResult InitPromotion(PromotionRequest request)
        {
            
        }
    }
}
