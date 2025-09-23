using BachelorParis2024.Models;
using Microsoft.AspNetCore.Components;
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

        public IActionResult DisplayEventToBook(int eventId, string eventSport, string eventDescription, DateTime eventDate, string eventLocation)
        {
            EventModel eventToDisplay = new()
            {
                Id = eventId,
                Date = eventDate,
                Sport = eventSport,
                Name = eventDescription,
                Description = "",
                Location = eventLocation,
                AvailablePlaces = 15000
            };

            ViewBag.Id = eventId;
            ViewBag.Sport = eventSport;
            ViewBag.Description = eventDescription;
            ViewBag.Date = eventDate;
            ViewBag.Location = eventLocation;
            return View("Booking", eventToDisplay);
        }
    }
}
