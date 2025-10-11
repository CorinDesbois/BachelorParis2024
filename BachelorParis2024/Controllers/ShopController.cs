using BachelorParis2024.Domain.Interfaces;
using BachelorParis2024.Domain.Models;
using BachelorParis2024.Repository.Context;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Elfie.Extensions;
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
                return View("Error");
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

        public IActionResult DisplayEventToBook(int eventId, string eventSport, string eventName, DateTime eventDate, string eventLocation)
        {
            //instanciation de l'objet EventModel pour afficher les détails de l'événement
            //reçus par le formulaire caché
            EventModel eventToDisplay = new()
            {
                Id = eventId,
                Date = eventDate,
                Sport = eventSport,
                Name = eventName,
                Description = "",
                Location = eventLocation,
                AvailablePlaces = 15000
            };
            // Récupération de la liste des offres depuis la base de données
            try
            { var offers = _context.Offre.ToList();

                var vm = new EventOfferModel
                {
                    EventToDisplay = eventToDisplay,
                    Offers = offers
                };

                ViewBag.Id = eventId;
                ViewBag.Sport = eventSport;
                ViewBag.Description = eventName;
                ViewBag.Date = eventDate;
                ViewBag.Location = eventLocation;
                return View("Booking", vm);

            }
            catch
            {
                return View("Error");
            }
        }

        public IActionResult Booking()
        {
            return View();
        }

        public IActionResult AddToCart(int eventId, string eventSport, string eventName, DateTime eventDate, string eventLocation, string offerName)
        {
            //instanciation de l'objet EventModel pour afficher les détails de l'événement + offre
            //reçus par le formulaire caché
            EventModel eventToAdd = new()
            {
                Id = eventId,
                Date = eventDate,
                Sport = eventSport,
                Name = eventName,
                Description = "",
                Location = eventLocation,
                AvailablePlaces = 15000
            };

            //A mettre dans unn bloc try and catch
            var offers = _context.Offre.ToList();
            var offerToAdd = offers.Where(of => of.Name == offerName);

            var vm = new EventOfferModel
            {
                EventToDisplay = eventToAdd,
                Offers = offerToAdd
            };

            return View("Cart");

        }

        public IActionResult Cart()
        {
            return View();
        }
    }

}

