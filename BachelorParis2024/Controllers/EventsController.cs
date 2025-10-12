using BachelorParis2024.Mocks;
using BachelorParis2024.Domain;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using BachelorParis2024.Domain.Models;
using BachelorParis2024.Domain.Interfaces;

namespace BachelorParis2024.Controllers
{
    public class EventsController : Controller
    {
        //utilisation de l'interface IEventRepository pour récupérer la liste des événements du mock (EventsMock.cs)
        private readonly IEventRepository _eventRepository;
       

        public EventsController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
     

        [HttpPost]
        public IActionResult DisplayEventsBySport(string valueFromHiddenForm)
        {
            
            IEnumerable<EventModel> allEvents = _eventRepository.GetAllEvents();
            IEnumerable<EventModel> eventsBySport = allEvents.Where(ev => ev.Sport == valueFromHiddenForm);

                if (eventsBySport == null)
                {
                    return NotFound("Aucun événement correspondant à votre recherche");
                }
            ViewBag.Titre = valueFromHiddenForm;
            return View("Index", eventsBySport);

        }

        public IActionResult Index()
        {
            try
            {
                IEnumerable<EventModel> allEvents = _eventRepository.GetAllEvents();
                IEnumerable<EventModel> eventList = allEvents.OrderBy(ev => ev.Sport);
                ViewBag.Titre = "Evénements";
                return View("Index", eventList);
            }
            catch(Exception)
            {
                return View("Error");
            }
        }
    }    
}

