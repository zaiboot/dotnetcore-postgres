using System.Collections.Generic;
using System.Threading.Tasks;
using Prizes.DTO;

namespace Prizes.Repository
{
    public interface IPrizeRepository
    {
        IEnumerable<Prize> GetPrizes();
        Prize GetPrize(int id);
        Task BulkInsertPrizes(IReadOnlyList<Prize> listOfPrizes);

        IEnumerable<Prize> GetPrizes(int customerId);
    }
}