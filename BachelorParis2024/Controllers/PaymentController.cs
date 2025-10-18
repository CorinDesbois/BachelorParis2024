using BachelorParis2024.Domain.Identity;
using BachelorParis2024.Domain.Interfaces;
using BachelorParis2024.Domain.Models;
using BachelorParis2024.Repository.Context;
using BachelorParis2024.Services.Payment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices.Data;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.SqlServer.Management.Smo;
using NuGet.Versioning;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace BachelorParis2024.Controllers
{
    //controller servant à simuler un paiement réussi
    //en retournant OK

   
    public class PaymentController : Controller
    {
        //injection des dépendances
        private readonly DbProjectContext _context;
        private readonly IPaymentProcessor _IpaymentProcessor;
        private readonly UserManager<BachelorParis2024User> _userManager;

        public PaymentController(DbProjectContext context, IPaymentProcessor IPaymentProcessor, UserManager<BachelorParis2024User> userManager)
        {
            _context = context;
            _IpaymentProcessor = IPaymentProcessor;
            _userManager = userManager;
        }

        [Authorize]
        [HttpPost]
        public async Task <IActionResult> ProcessPayment()
        {   
            //on vérifie si l'utilisateur est connecté
            if (User.Identity?.IsAuthenticated != true)
            {
                return Unauthorized(new {message = "utilisateur non connecté"});
            }
            //on récupère l'id, le nom et le prénom de l'utilisateur connecté
            var user = await _userManager.GetUserAsync(User);

            var userId = user?.Id;
            if (userId == null)
            {
                return Unauthorized(new { message = "idUser non reconnu" });
            }
            var userFirstName = user.FirstName;
            var userLastName = user.LastName;

            //on récupère le panier de l'utilisateur connecté
            var userCart = await _context.Cart.Where(c => c.UserId == userId)
                .Include(c => c.Items)
                .FirstOrDefaultAsync();
            
            if(userCart == null)
            {
                return NotFound(new { message = "aucun panier trouvé" });
            }

            //on fait appel au appel au service PaymentProcessor pour simuler le paiement
            var succeededPayment = await _IpaymentProcessor.ProcessPaymentAsync(userId);
            if (!succeededPayment)
            {
                return BadRequest(new { message = "échec du paiement" });
            }
            //si le paiement a réussi, on crée une commande à partir du panier.
            var order = new Order
            {
                UserId = userId,
                OrderDate = DateTime.UtcNow,
                OrderStatus = 2, //statut "payé"
                TotalAmount = userCart.Items.Sum(i => i.Total)
            };

            order.Items = userCart.Items;

            List<CartItem> items = order.Items;

           foreach(CartItem i in items)
            {
                var ticket = new Ticket
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    IdEvent = i.IdEvent,
                    Sport = i.Sport,
                    Event = i.Event,
                    Date = i.Date,
                    Location = i.Location,
                    IdOffer = i.IdOffer,
                    OfferName = i.OfferName,
                    OfferDescription = i.OfferDescription,
                    OfferPersonNb = i.OfferPersonNb,
                    Price = i.Price,
                    Quantity = i.Quantity,
                    Total = i.Total,
                    Order = order //rattache chaque ticket à sa commande
                };
                //on enregistre chaque ticket dans la base de données
                _context.Ticket.Add(ticket);
                await _context.SaveChangesAsync();
           }
            _context.Cart.Remove(userCart);
            await _context.SaveChangesAsync();
            return Ok(new { message = "commande enregistrée" });
        }    
    }
}
 