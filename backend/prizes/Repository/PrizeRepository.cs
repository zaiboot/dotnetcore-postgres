using System.Collections.Generic;
using Prizes.DataContext;
using Prizes.DTO;

namespace Prizes.Repository
{
    public class PrizeRepository : IPrizeRepository
    {
        private readonly PrizesDataContext _ctx;

        public PrizeRepository(PrizesDataContext ctx)
        {
            this._ctx = ctx;
        }
        public IEnumerable<Prize> GetPrizes()
        {
            return this._ctx.Prizes;
        }
    }
}