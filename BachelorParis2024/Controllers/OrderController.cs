using BachelorParis2024.Domain.Identity;
using BachelorParis2024.Domain.Interfaces;
using BachelorParis2024.Domain.Models;
using BachelorParis2024.Repository.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices.Data;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BachelorParis2024.Controllers
{
    public class OrderController : Controller
    {
        //injection des dépendances
        private readonly DbProjectContext _context;
        private readonly UserManager<BachelorParis2024User> _userManager;

        public OrderController(DbProjectContext context, UserManager<BachelorParis2024User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> OrderList()
        {
            //on vérifie si l'utilisateur est connecté
            if (User.Identity?.IsAuthenticated != true) 
            {
                return View("/Identity/Login");
            }
            //on récupère l'id  de l'utilisateur connecté
            var user = await _userManager.GetUserAsync(User);
            var userId = user?.Id;
            if (userId == null)
            {
                return View("/Identity/Login");
            }
            List<Order> orders = await _context.Order
                .Include(o => o.Tickets)
                .AsNoTracking() //améliore les performances pour les opérations en lecture seule
                .Where(o => o.UserId == userId)
                .ToListAsync(); //Obligatoire avec IQueryable<> sinon la méthode retourne une erreur

            List<Ticket> tickets = new List<Ticket>();

            foreach(var o in orders)
            {
                tickets = await _context.Ticket
                    .Where(t => t.OrderId == o.Id)
                    .ToListAsync();

         
            }

            var ordersResume = new TicketOrderViewModel
            {
                Orders = orders,
                Tickets = tickets,
            };
               

            return View("OrderList", ordersResume);
        }


        public async Task<IActionResult> Ticket()
        {
            return View();
        }
    } 
}
