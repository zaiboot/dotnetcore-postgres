using System.Threading.Tasks;
using AppManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppManager.Controllers
{
    public interface IAppController
    {
        Task<ActionResult> InitPromotionAsync(PromotionRequest request);
        
    }
}