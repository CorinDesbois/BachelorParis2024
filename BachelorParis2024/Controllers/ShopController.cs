using Microsoft.AspNetCore.Mvc;

namespace BachelorParis2024.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OfferDetail()
        {
            return View();
        }

        public IActionResult Booking()
        {
            return View();
        }
    }
}
