using BachelorParis2024.Domain.Models;
using BachelorParis2024.Repository.Context;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BachelorParis2024.Controllers
{
    public class ShopController : Controller
    {   
        //ajout du context pour récupérer les liste des offres depuis la BDD
        private readonly DbProjectContext _context;

        public ShopController(DbProjectContext context)
        {
            _context = context;
        }

        // Liste des offres
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var availableOffers = await _context.Offre.ToListAsync();
                return View(availableOffers);
            }
            catch (Exception)
            {
                return View("Une erreur est survenue, veuillez réessayer");
            }
        }

        // Détails d’une offre
        [HttpGet("Shop/OfferDetail/{id}")]
        public async Task<IActionResult> OfferDetail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offerModel = await _context.Offre
                .FirstOrDefaultAsync(m => m.Id == id);
            if (offerModel == null)
            {
                return NotFound();
            }

            return View(offerModel);
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
