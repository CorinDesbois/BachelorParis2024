using BachelorParis2024.Mocks;
using BachelorParis2024.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

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

        
    }    
}

