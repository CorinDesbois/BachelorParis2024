using Microsoft.SqlServer.Management.SqlScriptPublish;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BachelorParis2024.Domain.Models
{
    [Table("Carts")]
    public class Cart
    {
        public int Id { get; set; }
        public required string UserId { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        [NotMapped]//indique à EF Core de ne pas ajouter cette colonne en base de données.
        public decimal TotalAmount => Items?.Sum(ci => ci.Total) ?? 0;
    }
}
