using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Interface pour que le controller puisse récupérer la liste des événements du mock (EventsMock.cs) 
//via l'injection de dépendance dans Program.cs
//servira également plus tard pour connecter la base de données

namespace BachelorParis2024.Models
{
    public interface IEventRepository
    {
        IEnumerable<EventModel> GetAllEvents();

        EventModel GetEventById(int id);
        EventModel GetEventByName(string name);
    }
}
