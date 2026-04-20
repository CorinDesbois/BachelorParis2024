using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BachelorParis2024.Domain.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        public int CartId { get; set; }

        public long IdTicket { get; set; }

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

        public required Cart Cart { get; set; }
    }
}
