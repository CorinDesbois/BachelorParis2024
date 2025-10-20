using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BachelorParis2024.Domain.Models
{
    public class TicketOrderViewModel
    {   
        public Order? Order { get; set; }

        public Ticket? Ticket { get; set; }
        public required List<Order> Orders { get; set; }

        public required List<Ticket> Tickets { get; set; }

    }
}
