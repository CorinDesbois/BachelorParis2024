using System.Diagnostics;
using BachelorParis2024.Models;
using Microsoft.AspNetCore.Mvc;


namespace BachelorParis2024.Controllers
{
    public class EventsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
