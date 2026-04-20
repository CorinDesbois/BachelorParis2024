using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BachelorParis2024.Domain.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public required string UserId { get; set; }

        public DateTime OrderDate { get; set; }

        public int OrderStatus { get; set; }

        public List<CartItem> Items { get; set; } = [];

        public List<Ticket> Tickets { get; set; } = [];

        public decimal TotalAmount { get; set; }

    }
}
