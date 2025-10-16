using BachelorParis2024.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BachelorParis2024.Domain.Identity;

namespace BachelorParis2024.Repository.Context
{
    public class DbProjectContext : IdentityDbContext<BachelorParis2024User>
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
            //contrainte d'unicité sur le UserId dans la table Cart
            //1 utilisateur ne peut avoir qu'un seul panier
            modelBuilder.Entity<Cart>()
                .HasIndex(c => c.UserId)
                .IsUnique();
            modelBuilder.Entity<Cart>().ToTable("Carts");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //on configure la chaîne de connexion ici si besoin
                optionsBuilder.UseSqlServer("Server=tcp:bachelorparis2024freeserver.database.windows.net,1433;Initial Catalog=BachelorParis2024FreeDB;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication= 'Active Directory Default';");
            }
        }

        //on crée une propriété DbSet pour chaque entité que l'on veut créer dans la base de données
        public DbSet<OfferModel> Offre { get; set; }

        public DbSet<Cart> Cart { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

    }
}
