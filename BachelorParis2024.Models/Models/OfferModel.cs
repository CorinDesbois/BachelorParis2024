using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BachelorParis2024.Domain.Models
{
    public class OfferModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public required string Name { get; set; }
        public required int PersonsNumber { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public required string Conditions { get; set; }
        public required string ImageUrl { get; set; }

    }
}
