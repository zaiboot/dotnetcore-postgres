using System.Collections.Generic;
using Prizes.DTO;

namespace Prizes.Repository
{
    public interface IPrizeRepository
    {
        IEnumerable<Prize> GetPrizes();
    }
}