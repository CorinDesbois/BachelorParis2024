using System.Diagnostics;
using BachelorParis2024.Models;
using Microsoft.AspNetCore.Mvc;
using BachelorParis2024.Mocks;


namespace BachelorParis2024.Controllers
{
    public class EventsController : Controller
    {
        //utilisation de l'interface IEventRepository pour récupérer la liste des événements du mock (EventsMock.cs)
        //ajout de l'interface IEventSports pour récupérer la liste des sports mock (SportsMock.cs)
        private readonly IEventRepository _eventRepository;
        private readonly ISportRepository sportRepository;

        public EventsController(IEventRepository eventRepository, ISportRepository sportRepository)
        {
            _eventRepository = eventRepository;
            this.sportRepository = sportRepository;
        }

        public IEnumerable<EventModel> GetAllEvents()
        {
            return _eventRepository.GetAllEvents();
        }

        public IEnumerable<SportModel> GetAllSports()
        {
            return this.sportRepository.GetAllSports();
        }
        //---------------------------------
        public IActionResult Index()
        {
            
            return View();
        }

        
    }
}
