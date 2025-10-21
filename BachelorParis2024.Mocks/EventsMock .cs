using BachelorParis2024;
using BachelorParis2024.Domain.Interfaces;
using BachelorParis2024.Domain.Models;
using System.Collections.Generic;
using System.Composition;

namespace BachelorParis2024.Mocks
{
    public class EventsMock : IEventRepository
    {
        public List<EventModel> _listEvents = new List<EventModel>
        {
            new EventModel
            {
                Id = 1,
                Date = new DateTime(2024, 07, 26, 18, 0, 0),
                Sport = "Athlétisme",
                Name = "Finale du 100m sprint",
                Description = "Course finale du 100 mètres sprint.",
                Location = "Stade de France, Paris",
                AvailablePlaces = 15000
            },
            new EventModel
            {
                Id = 2,
                Date = new DateTime(2024, 07, 27, 10, 0, 0),
                Sport = "Athlétisme",
                Name = "Finale du saut en hauteur",
                Description = "Compétition finale du saut en hauteur.",
                Location = "Stade de France, Paris",
                AvailablePlaces = 8000
            },
            new EventModel
            {
                Id = 3,
                Date = new DateTime(2024, 07, 28, 14, 0, 0),
                Sport = "Athlétisme",
                Name = "Finale du marathon",
                Description = "Course finale du marathon.",
                Location = "Champs-Élysées, Paris",
                AvailablePlaces = 20000
            },
            new EventModel
            {
                Id = 4,
                Date = new DateTime(2024, 07, 29, 16, 0, 0),
                Sport = "Athlétisme",
                Name = "Finale du relais 4x100m",
                Description = "Course finale du relais 4x100 mètres.",
                Location = "Stade de France, Paris",
                AvailablePlaces = 10000
            },
            new EventModel
            {
                Id = 5,
                Date = new DateTime(2024, 07, 30, 19, 0, 0),
                Sport = "Gymnastique",
                Name = "Finale par équipes féminines",
                Description = "Compétition finale par équipes féminines.",
                Location = "Accor Arena, Paris",
                AvailablePlaces = 12000
            },
            new EventModel
            {
                Id = 6,
                Date = new DateTime(2024, 07, 31, 15, 0, 0),
                Sport = "Natation",
                Name = "Finale du 100m nage libre",
                Description = "Course finale du 100 mètres nage libre.",
                Location = "Piscine Olympique, Paris",
                AvailablePlaces = 9000
            },
            new EventModel
            {
                Id = 7,
                Date = new DateTime(2024, 08, 01, 11, 0, 0),
                Sport = "Cyclisme",
                Name = "Course sur route masculine",
                Description = "Compétition de course sur route masculine.",
                Location = "Boulevard Haussmann, Paris",
                AvailablePlaces = 5000
            },
            new EventModel
            {
                Id = 8,
                Date = new DateTime(2024, 08, 02, 13, 0, 0),
                Sport = "Escrime",
                Name = "Finale individuelle masculine",
                Description = "Compétition finale individuelle masculine.",
                Location = "Grand Palais, Paris",
                AvailablePlaces = 7000
            },
            new EventModel
            {
                Id = 9,
                Date = new DateTime(2024, 08, 03, 17, 0, 0),
                Sport = "Aviron",
                Name = "Finale du huit avec barreur",
                Description = "Course finale du huit avec barreur.",
                Location = "Seine, Paris",
                AvailablePlaces = 6000
            },
            new EventModel
            {
                Id = 10,
                Date = new DateTime(2024, 08, 04, 20, 0, 0),
                Sport = "Canoë",
                Name = "Finale du kayak monoplace",
                Description = "Course finale du kayak monoplace.",
                Location = "Lac Daumesnil, Paris",
                AvailablePlaces = 4000
            },
            new EventModel
            {
                Id = 11,
                Date = new DateTime(2024, 08, 05, 18, 0, 0),
                Sport = "Basketball",
                Name = "Finale du tournoi féminin",
                Description = "Match final du tournoi de basketball féminin.",
                Location = "Accor Arena, Paris",
                AvailablePlaces = 20000
            },
            new EventModel
            {
                Id = 12,
                Date = new DateTime(2024, 08, 06, 16, 0, 0),
                Sport = "Gymnastique",
                Name = "Finale individuelle masculine",
                Description = "Compétition finale individuelle masculine.",
                Location = "Accor Arena, Paris",
                AvailablePlaces = 12000
            },
            new EventModel
            {
                Id = 13,
                Date = new DateTime(2024, 08, 07, 14, 0, 0),
                Sport = "Tennis de table",
                Name = "Finale individuelle féminine",
                Description = "Compétition finale individuelle féminine.",
                Location = "Palais des Sports, Paris",
                AvailablePlaces = 7000
            },
            new EventModel
            {
                Id = 14,
                Date = new DateTime(2024, 08, 08, 12, 0, 0),
                Sport = "Judo",
                Name = "Finale des -60 kg masculins",
                Description = "Compétition finale des -60 kg masculins.",
                Location = "Accor Arena, Paris",
                AvailablePlaces = 8000
            },
            new EventModel
            {
                Id = 15,
                Date = new DateTime(2024, 08, 09, 19, 0, 0),
                Sport = "Haltérophilie",
                Name = "Finale des 81 kg masculins",
                Description = "Compétition finale des 81 kg masculins.",
                Location = "Palais des Sports, Paris",
                AvailablePlaces = 5000
            },
            new EventModel
            {
                Id = 16,
                Date = new DateTime(2024, 08, 10, 15, 0, 0),
                Sport = "Judo",
                Name = "Finale des -73 kg masculins",
                Description = "Compétition finale des -73 kg masculins.",
                Location = "Accor Arena, Paris",
                AvailablePlaces = 8000
            },
            new EventModel
            {
                Id = 17,
                Date = new DateTime(2024, 08, 11, 13, 0, 0),
                Sport = "Hockey",
                Name = "Finale du tournoi masculin",
                Description = "Match final du tournoi de hockey sur gazon masculin.",
                Location = "Stade Yves-du-Manoir, Colombes",
                AvailablePlaces = 10000
            },
            new EventModel
            {
                Id = 18,
                Date = new DateTime(2024, 08, 12, 17, 0, 0),
                Sport = "Aviron",
                Name = "Finale du quatre sans barreur",
                Description = "Course finale du quatre sans barreur.",
                Location = "Seine, Paris",
                AvailablePlaces = 6000
            },
            new EventModel
            {
                Id = 19,
                Date= new DateTime(2024, 08, 13, 11, 0, 0),
                Sport = "Football",
                Name = "Finale du tournoi féminin", 
                Description = "Match final du tournoi de football féminin.",
                Location = "Stade de France, Paris",
                AvailablePlaces = 80000
            },
            new EventModel
            {
                Id = 20,
                Date = new DateTime(2024, 08, 14, 20, 0, 0),
                Sport = "Rugby à sept",
                Name = "Finale du tournoi masculin",
                Description = "Match final du tournoi de rugby à sept masculin.",
                Location = "Stade Jean-Bouin, Paris",
                AvailablePlaces = 20000
            }
        };

        public IEnumerable<EventModel> GetAllEvents() => _listEvents;

        public EventModel? GetEventById(int id)
        {   
            if (id <= 0)
            {
                return null;
            }
            return _listEvents.FirstOrDefault(e =>e.Sport!=null && e.Id == id);
        }

        public EventModel? GetEventByName(string? name)
        {
            if (string.IsNullOrWhiteSpace(name)) return null;

            return _listEvents.FirstOrDefault(e =>e.Name!= null && e.Name == name!);
        }

        public EventModel? GetEventBySport(string sport)
        {
            if (string.IsNullOrWhiteSpace(sport)) return null;
            return _listEvents.FirstOrDefault(e =>e.Sport !=null && e.Sport == sport);
        }
    }
}
