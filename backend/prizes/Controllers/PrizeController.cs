﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prizes.Api.Mapping;
using Prizes.DTO;
using Prizes.Model;
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

        [HttpPost]
        public async Task<ActionResult> BulkInsertPrizesAsync(PrizeBulkCreationRequest request)
        {

            // there are so many ways we can handle this:
            // * Queue
            // * Kafka
            // * etc
            //for the moment it will go with a simple range add
            var listOfPrizes = new List<DTO.Prize>();
            for (int i = 0; i < request.TotalPrizes; i++)
            {
                var p = new DTO.Prize
                {
                    //id is autogenerated
                    Amount = request.DistributionPerPrize,
                    Name = $"Name = {i}",
                    CustomerId = request.CustomerId,
                    Status = StatusEnum.NOT_INITIALIZED
                };

                listOfPrizes.Add(p);

            }

            await _prizeRepository.BulkInsertPrizes(listOfPrizes);

            return Ok();

            //it really shoud return Accepted() if we ever move this to a queue or kafka.
            /*
            https://tools.ietf.org/html/rfc7231#section-6.3.3            
            
            The 202 (Accepted) status code indicates that the request has been
            accepted for processing, but the processing has not been completed.
            The request might or might not eventually be acted upon, as it might
            be disallowed when processing actually takes place.  There is no
            facility in HTTP for re-sending a status code from an asynchronous
            operation.
             */

        }


        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<List<Models.Prize>>> GetAsync(int customerId)
        {
            var prizes = this._prizeRepository.GetPrizes(customerId);
            var firstPrize = prizes.First();
            if (firstPrize.Status != StatusEnum.AVAILABLE)
            {
                await this._prizeRepository.MarkOneAsAvailable(firstPrize);

                //ideally we shouldn't need to do this but to to be sure, I think we will do it.
                firstPrize.Status = StatusEnum.AVAILABLE;

            }
            var result = _mappingEngine.Map<IEnumerable<Prizes.DTO.Prize>, List<Models.Prize>>(prizes);
            return result;
        }

        // POST api/values
        [HttpPut]
        public ActionResult SetStatus([FromBody] PrizeStatusUpdateRequest prize)
        {
            return Ok();
        }
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
