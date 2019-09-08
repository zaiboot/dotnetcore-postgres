using System.Threading.Tasks;
using AppManager.DTO;

namespace AppManager.Controllers
{
    public interface IPrizesRepository
    {
        Task<PrizeBulkCreationResult> CreatePrizes(PrizeBulkCreationRequest prizeBulkCreationRequest);
    }
}