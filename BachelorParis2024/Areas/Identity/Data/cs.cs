using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BachelorParis2024.Domain.Identity;

namespace BachelorParis2024.Repository_Context_DbProjectContext;

public class cs : IdentityDbContext<Domain.Identity.BachelorParis2024User>
{
    public cs(DbContextOptions<cs> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
