using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//ajout d'une classe DbProjectContextFactory:IDesignTimeDbContextFactory
//pour essayer de résoudre le problème de migration
//permettra à Entity Framework de créer une instance de DbProjectContext au moment de la
//conception (design time)
namespace BachelorParis2024.Repository.Context
{
    internal class DbProjectContextFactory : IDesignTimeDbContextFactory<DbProjectContext>
    {
        public DbProjectContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbProjectContext>();
            optionsBuilder.UseSqlServer("Data Source=tcp:bachelorparis2024freeserver.database.windows.net,1433;Initial Catalog=BachelorParis2024FreeDB;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication= 'Active Directory Default'; Encrypt=True;");
            return new DbProjectContext(optionsBuilder.Options);
        }
    }
}
