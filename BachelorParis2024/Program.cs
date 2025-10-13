using BachelorParis2024.Domain.Interfaces;
using BachelorParis2024.Mocks;
using BachelorParis2024.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using BachelorParis2024.Repository_Context_DbProjectContext;
using Microsoft.AspNetCore.Identity;
using BachelorParis2024.Domain.Identity;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Ajout de Entity Framework et de la cha�ne de connexion
/*builder.Services.AddDbContext<DbProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING"))
        .EnableSensitiveDataLogging()   // !! � activer seulement en debug
        .LogTo(Console.WriteLine, LogLevel.Information)); //pour debug*/
//� supprimer des commentaires

//suppression du AddDbContext classique et
// AJout d'un DbContextFactory � la place
//pour essayer de r�soudre les probl�mes de migration avec EF Core Tools
//permet de cr�er des instances de DbProjectContext � la vol�e
// AJout d'un DbContextFactory (optionnel)
//pour essayer de r�soudre les probl�mes de migration avec EF Core Tools
//permet de cr�er des instances de DbProjectContext � la vol�e
builder.Services.AddDbContextFactory<DbProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")));

builder.Services.AddDefaultIdentity<BachelorParis2024User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<DbProjectContext>();
        

// Injections de d�pendance pour les mocks
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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
