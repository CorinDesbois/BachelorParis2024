using BachelorParis2024.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BachelorParis2024.Repository.Context
{
    public class DbProjectContext : DbContext
    {   
        //on crée un constructeur qui prend en paramètre DbContextOptions
        //qui va permettre de configurer le contexte de la base de données
        public DbProjectContext(DbContextOptions<DbProjectContext> options) : base(options)
        {    
        }

        //on crée une propriété DbSet pour chaque entité que l'on veut créer dans la base de données
        public DbSet<OfferModel> Offre { get; set; }
    }   
}
