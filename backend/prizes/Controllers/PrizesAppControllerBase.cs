using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prizes.Api.Mapping;

namespace Prizes.Controllers
{
    //The idea here is to setup dependencies for all the controllers, like mappers
    // you will always load data from a specific datasources , now you need to return
    // a custom object ( to avoid thightly coupling), so we need a mapper
    public class PrizesAppControllerBase : ControllerBase
    {
        protected readonly IMappingEngine _mappingEngine;
        protected readonly ILogger<PrizesAppControllerBase> _logger;

        public PrizesAppControllerBase(IMappingEngine mappingEngine, ILogger<PrizesAppControllerBase> logger)
        {
            this._mappingEngine = mappingEngine;
            this._logger = logger;
        }
    }
}