using BachelorParis2024.Domain.Identity;
using BachelorParis2024.Domain.Models;
using BachelorParis2024.Repository.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace BachelorParis2024.Controllers
{
    public class TicketController : Controller
    {
        private readonly QrCodeService _qrCodeService;
        private readonly IConfiguration _config;
        private readonly DbProjectContext _dbContext;
        private readonly UserManager<BachelorParis2024User> _userManager;

        public TicketController(QrCodeService qrCodeService, IConfiguration config, DbProjectContext dbContext, UserManager<BachelorParis2024User> userManager)
        {
            _qrCodeService = qrCodeService;
            _config = config;
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task <IActionResult> Ticket(Guid id)
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


            var ticket = await _dbContext.Ticket
                .FirstOrDefaultAsync(t => t.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            var order = ticket.Order;

            var ticketViewModel = new TicketViewModel
            {
                Ticket = ticket,
                Order = order,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            return View("Ticket", ticketViewModel);
        }   
    }
 }
