using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AppManager.Api.Mapping;

namespace AppManager.Controllers
{
    // Code redundancy ? Yes, part of the principles of microservices is to allow
    // the duplication of code in favor of loosely coupling. We could pontentially create a nuget package
    // to store this common settings. We will have to review it more in depth in order to find it is valid or not
    public class AppControllerBase : ControllerBase
    {
        protected readonly IMappingEngine _mappingEngine;
        protected readonly ILogger<AppControllerBase> _logger;

        public AppControllerBase(IMappingEngine mappingEngine, ILogger<AppControllerBase> logger)
        {
            this._mappingEngine = mappingEngine;
            this._logger = logger;
        }
    }
}