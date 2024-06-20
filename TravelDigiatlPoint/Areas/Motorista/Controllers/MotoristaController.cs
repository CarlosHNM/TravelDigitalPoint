using Microsoft.AspNetCore.Mvc;

namespace TravelDigiatlPoint.Areas.Motorista.Controllers
{
    [Area("Motorista")]
    public class MotoristaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
