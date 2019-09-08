using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task BulkInsertPrizes(IReadOnlyList<Prize> listOfPrizes)
        {
            await this._ctx.Prizes.AddRangeAsync(listOfPrizes);
            await this._ctx.SaveChangesAsync();
        }

        public Prize GetPrize(int id)
        {
            return this._ctx.Prizes.First( p => p.Id == id);
        }

        public IEnumerable<Prize> GetPrizes()
        {
            return this._ctx.Prizes;
        }

        public IEnumerable<Prize> GetPrizes(int customerId)
        {
            return this._ctx.Prizes.Where(p => p.CustomerId == customerId);
        }
    }
}