using BachelorParis2024.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BachelorParis2024.Repository.Context
{
    public class DbProjectContext : DbContext
    {   
        //on crée un constructeur qui prend en paramètre DbContextOptions
        //qui va permettre de configurer le contexte de la base de données
        public DbProjectContext(DbContextOptions<DbProjectContext> options) : base(options)
        {    
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //on configure les entités ici si besoin
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //on configure la chaîne de connexion ici si besoin
                optionsBuilder.UseSqlServer("Data Source=tcp:bachelorparis2024freeserver.database.windows.net,1433;Initial Catalog=BachelorParis2024FreeDB;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication= 'Active Directory Default'; Encrypt=True;");
            }
        }

        //on crée une propriété DbSet pour chaque entité que l'on veut créer dans la base de données
        public DbSet<OfferModel> Offre { get; set; }
    }   
}
