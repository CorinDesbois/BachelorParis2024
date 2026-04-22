using BachelorParis2024.Domain.Identity;
using BachelorParis2024.Domain.Models;
using BachelorParis2024.Repository.Context;
using BachelorParis2024.Services.Payment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;


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
        private readonly IConfiguration _config;
        private readonly QrCodeService _qrCodeService;

        public PaymentController(DbProjectContext context, IPaymentProcessor IPaymentProcessor, UserManager<BachelorParis2024User> userManager, IConfiguration config, QrCodeService qrCodeService)
        {
            _context = context;
            _IpaymentProcessor = IPaymentProcessor;
            _userManager = userManager;
            _config = config;
            _qrCodeService = qrCodeService;
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
                    Order = order, //rattache chaque ticket à sa commande
                    QrContent = string.Empty,
                };
            
                //on enregistre chaque ticket dans la base de données
                _context.Ticket.Add(ticket);
                await _context.SaveChangesAsync();

                //Génération du contenu QR sécurisé
                ticket.QrContent = GenerateQrContent(user.Id, ticket.Id);

                //on met à jour le contenu QR dans le ticket
                await _context.SaveChangesAsync();
            }
            _context.Cart.Remove(userCart);
            await _context.SaveChangesAsync();

            

            return Ok(new { message = "commande enregistrée" });
        }

        //Méthode permettant de générer un QR Code pour chaque ticket
        private string GenerateQrContent(string userId, Guid ticketId)
        {
            var secretKey = _config["QrCode:SecretKey"];
            var payload = $"user={userId}&ticket={ticketId}";
            var signature = ComputeHmac(payload, secretKey);
            return $"{payload}&sig={signature}";
        }
        
        //Méthode retournant un QR code sous forme de fichier png à insérer dans la vue
        public IActionResult QrCode(Guid ticketId)
        {
            var ticket = _context.Ticket.Find(ticketId);
            if (ticket == null || string.IsNullOrEmpty(ticket.QrContent))
                return NotFound();

            var qrBytes = _qrCodeService.GenerateQrCode(ticket.QrContent);
            return File(qrBytes, "image/png");
        }

        //Méthode permettant de calculer la signature HMAC pour sécuriser le contenu du QR code
        private string ComputeHmac(string data, string secretKey)
        {
            var keyBytes = Encoding.UTF8.GetBytes(secretKey);
            var dataBytes = Encoding.UTF8.GetBytes(data);

            using var hmac = new HMACSHA256(keyBytes);
            var hashBytes = hmac.ComputeHash(dataBytes);
            return Convert.ToHexString(hashBytes);
        }
    }
}
 