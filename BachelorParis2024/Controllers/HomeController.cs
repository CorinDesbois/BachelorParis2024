using System.Diagnostics;
using BachelorParis2024.Models;
using Microsoft.AspNetCore.Mvc;

namespace  BachelorParis2024.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ISportRepository sportRepository)
        {
            _logger = logger;
            _sportRepository = sportRepository;
        }
        //utilisation de l'interface ISportRepository pour récupérer la liste des sports du mock (SportsMock.cs)
        public readonly ISportRepository _sportRepository;

        public IEnumerable<SportModel> GetAllSports()
        {
            return _sportRepository.GetAllSports();
        }
        //---------------------------------
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
