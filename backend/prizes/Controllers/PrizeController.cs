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
            var result =  _mappingEngine.Map<IEnumerable<Prizes.DTO.Prize>,List<Prize>>( this._prizeRepository.GetPrizes());
            return result;
        }

        // POST api/values
        [HttpPost("{id}/Claim")]
        public void Claim(int id)
        {
            //TODO: Validate prize is still available
            //then mark it as claimed

        }        

    }
}
