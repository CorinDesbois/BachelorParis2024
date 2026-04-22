using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using BachelorParis2024.Domain.Identity;


//ajout d'une classe DbProjectContextFactory:IDesignTimeDbContextFactory
//pour essayer de résoudre le problème de migration
//permettra à Entity Framework de créer une instance de DbProjectContext au moment de la
//conception (design time)
/*namespace BachelorParis2024.Repository.Context
{
    internal class DbProjectContextFactory : IDesignTimeDbContextFactory<DbProjectContext>
    {
        public DbProjectContext CreateDbContext(string[] args)
        {
            // Charger la config depuis appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables() // permet aussi de lire AZURE_SQL_CONNECTIONSTRING si dispo
                .Build();

            var connectionString = configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");

            var optionsBuilder = new DbContextOptionsBuilder<DbProjectContext>();
            optionsBuilder.UseSqlServer("AZURE_SQL_CONNECTIONSTRING");
            return new DbProjectContext(optionsBuilder.Options);
        }
    }
}*/
