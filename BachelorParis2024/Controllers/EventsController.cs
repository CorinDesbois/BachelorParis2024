using System.Diagnostics;
using BachelorParis2024.Models;
using Microsoft.AspNetCore.Mvc;
using BachelorParis2024.Mocks;


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

        public IEnumerable<EventModel> GetAllEvents()
        {
            return _eventRepository.GetAllEvents();
        }
        //---------------------------------
        public IActionResult Index()
        {
            List<EventModel> listEvents = EventsMock.ListEvents;
            ViewBag.ListEvents = listEvents;
            return View();
        }

        
    }
}
