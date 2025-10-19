using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BachelorParis2024.Domain.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }

        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public int IdEvent { get; set; }

        public required string Sport { get; set; }

        public required string Event { get; set; }

        public DateTime Date { get; set; }

        public required string Location { get; set; }

        public int IdOffer { get; set; }

        public required string OfferName { get; set; }

        public required string OfferDescription { get; set; }

        public required int OfferPersonNb { get; set; }
        
        public required decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal Total { get; set; }

        public required Order Order { get; set; }
    }
}
