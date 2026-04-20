using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BachelorParis2024.Domain.Models
{
    public class CartItemViewModel
    {   
        public required IEnumerable<CartItem>  CartItems  { get; set; }

        public required Cart Cart { get; set; }
    }
}
