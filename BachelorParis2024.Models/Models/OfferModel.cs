using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BachelorParis2024.Domain.Models
{
    public class OfferModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public required int PersonsNumber { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }

        public required string Conditions { get; set; }
        public required string ImageUrl { get; set; }

    }
}
