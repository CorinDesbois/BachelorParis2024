using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BachelorParis2024.Domain.Models
{
    public class EventOfferModel
    {
        public required EventModel EventToDisplay { get; set; }
        public required IEnumerable<OfferModel> Offers { get; set; }
    }
}
