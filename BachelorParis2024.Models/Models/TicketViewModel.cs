using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BachelorParis2024.Domain.Models
{
    public class TicketViewModel
    {
        public required Order Order { get; set; }

        public required Ticket Ticket { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }
    }
}
