using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prizes.Api.Mapping;
using Prizes.Models;
using Prizes.Repository;

namespace Prizes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrizeController : PrizesAppControllerBase
    {
        private readonly IPrizeRepository _prizeRepository;

        public PrizeController(IMappingEngine mappingEngine, ILogger<PrizesAppControllerBase> logger, IPrizeRepository prizeRepository) : base(mappingEngine, logger)
        {
            this._prizeRepository = prizeRepository;
        }


        [HttpGet]
        public ActionResult<List<Prize>> Get()
        {
            var result = _mappingEngine.Map<IEnumerable<Prizes.DTO.Prize>, List<Prize>>(this._prizeRepository.GetPrizes());
            return result;
        }

        // POST api/values
        // [HttpPut]
        // public ActionResult SetStatus([FromBody] PrizeStatusUpdateRequest prize)
        // {
        //     ActionResult operationResult;
        //     var currentPrize = this._prizeRepository.GetPrize(prize.Id);
        //     switch (prize.NewStatus)
        //     {
        //         case Status.Available:
        //             if (currentPrize.Status == Status.Unavailable)
        //             {
        //                 currentPrize.Status = Status.Available;
        //             }
        //             //If the current status is 'Unavailable' all good,
        //             //else we are getting a hack to reenable a promotion or something different.
        //             operationResult = Forbid();
        //             return operationResult;
        //             break;
        //         case Status.Missed:
        //             //Doesn't matter the previous status. We need to disable the promotion
        //             // provided the time differente has been set 
        //             currentPrize.Status = Status.Missed;
        //             break;
        //         case Status.Unavailable:
        //             break;
        //         case Status.Unknown:
        //             break;

        //     }

        //     //then mark it as available


        // }

    }
}
