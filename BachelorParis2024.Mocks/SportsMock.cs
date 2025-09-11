using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BachelorParis2024.Models;

namespace BachelorParis2024.Mocks
{
    public class SportsMock : ISportRepository
    {
        public static List<SportModel> ListSports = new List<Models.SportModel>
        {
            new SportModel() { Id = 1, Name = "Athlétisme", ImageUrl = "athle" },
            new SportModel() { Id = 2, Name = "Aviron", ImageUrl = "aviron" },
            new SportModel() { Id = 3, Name = "Basketball", ImageUrl = "basketball" },
            new SportModel() { Id = 4, Name = "Canoë", ImageUrl = "canoe" },
            new SportModel() { Id = 5, Name = "Cyclisme", ImageUrl = "cyclisme" },
            new SportModel() { Id = 6, Name = "Escrime", ImageUrl = "escrime" },
            new SportModel() { Id = 7, Name = "Gymnastique", ImageUrl = "gym" },
            new SportModel() { Id = 8, Name = "Haltérophilie", ImageUrl = "culturisme" },
            new SportModel() { Id = 9, Name = "Hockey", ImageUrl = "hockey" },
            new SportModel() { Id = 10, Name = "Judo", ImageUrl = "judo" },
            new SportModel() { Id = 11, Name = "Natation", ImageUrl ="natation" },
            new SportModel() { Id = 12, Name = "Tennis de table", ImageUrl = "tennistable" }
        };

        public IEnumerable<SportModel> GetAllSports() => ListSports;

        public Models.SportModel GetSportById(int id)
        {
            return ListSports.FirstOrDefault(s => s.Id == id);
        }
        public Models.SportModel GetSportByName(string name)
        {
            return ListSports.FirstOrDefault(s => s.Name == name);
        }
    }
}
