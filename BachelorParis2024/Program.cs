using BachelorParis2024.Domain.Identity;
using BachelorParis2024.Domain.Interfaces;
using BachelorParis2024.Mocks;
using BachelorParis2024.Repository.Context;
using BachelorParis2024.Repository_Context_DbProjectContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.SqlServer.Management.Smo;
using System.ComponentModel;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Ajout de Entity Framework et de la cha�ne de connexion
//suppression du AddDbContext classique et
// AJout d'un DbContextFactory � la place
//pour essayer de r�soudre les probl�mes de migration avec EF Core Tools
//permet de cr�er des instances de DbProjectContext � la vol�e
builder.Services.AddDbContextFactory<DbProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")));

//Ajout de Identity pour gérer la création de comptes, les login et les rôles
builder.Services.AddDefaultIdentity<BachelorParis2024User>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.User.RequireUniqueEmail = true; 
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<DbProjectContext>();
        

// Injections de dependance pour les mocks
builder.Services.AddScoped<IEventRepository, EventsMock>();
builder.Services.AddScoped<ISportRepository, SportsMock>();

var mvcBuilder = builder.Services.AddRazorPages();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Seed des rôles + admin
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<BachelorParis2024User>>();
    var config = services.GetRequiredService<IConfiguration>();

    string[] roleNames = { "Admin", "User" };
    foreach (var roleName in roleNames)
    {
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }

    // Lecture des valeurs dans appsettings.json
    var adminEmail = config["AdminUser:Email"];
    var adminPassword = config["AdminUser:Password"];
    var adminFirstName = config["AdminUser:FirstName"];
    var adminLastName = config["AdminUser:LastName"];

    // Vérifie si l’admin existe déjà
    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        var newAdmin = new BachelorParis2024User
        {
            UserName = adminEmail,
            Email = adminEmail,
            FirstName = adminFirstName,
            LastName = adminLastName,
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(newAdmin, adminPassword);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(newAdmin, "Admin");

        } else
        {
            foreach (var error in result.Errors)
            {
                Console.WriteLine(error.Description);
            }
        }
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();

    