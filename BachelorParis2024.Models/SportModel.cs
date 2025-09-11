using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BachelorParis2024.Models
{
    public class SportModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public required string ImageUrl { get; set; }
    }
}
