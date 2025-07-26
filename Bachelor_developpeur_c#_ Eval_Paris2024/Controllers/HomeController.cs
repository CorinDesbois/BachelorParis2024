using System.Diagnostics;
using Bachelor_developpeur_c___Eval_Paris2024.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bachelor_developpeur_c___Eval_Paris2024.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Offers()
        {
            return View();
        }

        public IActionResult Connection()
        { 
            return View();       
        }

        public IActionResult ConstructionPage()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
