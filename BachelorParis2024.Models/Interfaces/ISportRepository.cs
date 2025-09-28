using BachelorParis2024.Domain;
using BachelorParis2024.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Interface pour que le controller puisse récupérer la liste des sports du mock (SportsMock.cs) 
//via l'injection de dépendance dans Program.cs
//servira également plus tard pour connecter la base de données

namespace BachelorParis2024.Domain.Interfaces
{
    public interface ISportRepository
    {
        IEnumerable<SportModel> GetAllSports();
        SportModel GetSportById(int id);
        SportModel GetSportByName(string name);
    }
}
