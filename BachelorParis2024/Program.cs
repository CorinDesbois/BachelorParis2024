using BachelorParis2024.Domain.Interfaces;
using BachelorParis2024.Mocks;
using BachelorParis2024.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

    var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Ajout de Entity Framework et de la chaîne de connexion
/*builder.Services.AddDbContext<DbProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING"))
        .EnableSensitiveDataLogging()   // !! à activer seulement en debug
        .LogTo(Console.WriteLine, LogLevel.Information)); //pour debug*/
//à supprimer des commentaires

//suppression du AddDbContext classique et
// AJout d'un DbContextFactory à la place
//pour essayer de résoudre les problèmes de migration avec EF Core Tools
//permet de créer des instances de DbProjectContext à la volée
// AJout d'un DbContextFactory (optionnel)
//pour essayer de résoudre les problèmes de migration avec EF Core Tools
//permet de créer des instances de DbProjectContext à la volée
builder.Services.AddDbContextFactory<DbProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")));

// Injections de dépendance pour les mocks
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

app.Run();
