using AppManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppManager.Controllers
{
    public interface IAppController
    {
        ActionResult InitPromotion(PromotionRequest request);
        
    }
}