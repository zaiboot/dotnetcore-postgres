using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Customers.Api.Mapping;

namespace Customers.Controllers
{
    // Code redundancy ? Yes, part of the principles of microservices is to allow
    // the duplication of code in favor of loosely coupling. We could pontentially create a nuget package
    // to store this common settings. We will have to review it more in depth in order to find it is valid or not
    public class CustomersAppControllerBase : ControllerBase
    {
        protected readonly IMappingEngine _mappingEngine;
        protected readonly ILogger<CustomersAppControllerBase> _logger;

        public CustomersAppControllerBase(IMappingEngine mappingEngine, ILogger<CustomersAppControllerBase> logger)
        {
            this._mappingEngine = mappingEngine;
            this._logger = logger;
        }
    }
}