using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AppManager.Repository;
using AppManager.Api.Mapping;
using AppManager.Models;
using AppManager.DTO;
using System.Threading.Tasks;
using System.Net;

namespace AppManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : AppControllerBase, IAppController
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IPrizesRepository _prizesRepository;

        public AppController(IMappingEngine mappingEngine, ILogger<AppControllerBase> logger,
            ICustomerRepository customerRepository, IPrizesRepository prizesRepository) : base(mappingEngine, logger)
        {
            _customerRepository = customerRepository;
            _prizesRepository = prizesRepository;
        }
        [HttpPost]
        public async Task<ActionResult> InitPromotionAsync(PromotionRequest request)
        {

            //var result = Created(??); 
            //The correct status code will be 201 ( created ) however we need to build a url
            // which stores the result of the method. This is out of scope but we can modify this later.
            var result = StatusCode(500);

            var customerCreateRequest = new CustomerCreateRequest
            {
                CustomerName = request.CustomerName
            };

            //create customer
             var taskResult = await _customerRepository.Create(customerCreateRequest).ContinueWith(async a =>
            {
                var newCustomer = a.Result;
                var distributionPerPrize = request.TotalAmount / request.NumberOfPrizes;
                 //create prizes 
                 var prizeBulkCreationRequest = new PrizeBulkCreationRequest
                {
                    CustomerId = newCustomer.CustomerId,
                    TotalPrizes = request.NumberOfPrizes,
                    DistributionPerPrize = distributionPerPrize
                };

                 //now the desicion to make here.
                 // Do we want to create a list with {NumberOfPrizes} length or
                 // delegate this to the prizes API. 

                 //to avoid blocking the current API we will delegate this to the prizes API. 
                 var prizesBulkCreationResponse = await _prizesRepository.CreatePrizes(prizeBulkCreationRequest);
                 return result;
                
            });

            if (!taskResult.IsFaulted)
            {
                result = Ok();
            }
            
            return result;
        }
    }
}