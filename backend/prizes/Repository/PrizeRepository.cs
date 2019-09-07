using System.Collections.Generic;
using System.Linq;
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

        public Prize GetPrize(int id)
        {
            return this._ctx.Prizes.First( p => p.Id == id);
        }

        public IEnumerable<Prize> GetPrizes()
        {
            return this._ctx.Prizes;
        }
    }
}