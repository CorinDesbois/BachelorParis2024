
namespace BachelorParis2024.Models
{
    public class EventModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public required string Sport { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Location { get; set; }

        public required int AvailablePlaces { get; set; }

    }
}