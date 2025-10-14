using BachelorParis2024.Repository.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BachelorParis2024.Controllers
{
    public class CartController : Controller
    {
        //injection du context
        private readonly DbProjectContext _context;

        public CartController(DbProjectContext context)
        {
            _context = context;
        }

        //on récupère le panier envoyé par le front via javascript fetch
        //et on le stocke dans la base de données si l'utilisateur est connecté

        [Authorize]
        [HttpPost]
        public IActionResult PostCart([FromBody] List<CartItem> cart)
        {
        
            //on vérifie si l'utilisateur est connecté
           if (User.Identity?.IsAuthenticated == true)
            {
                //return Ok();
                //on récupère l'id de l'utilisateur connecté
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userId == null)
                {
                    return Unauthorized(new { message = "User ID not found in claims" });
                }
                //on stocke le panier dans la base de données
                //ici on peut créer une entité CartModel qui contient l'id de l'utilisateur et la liste des id des offres
                //puis on ajoute cette entité à la base de données
                //pour simplifier, on va juste afficher le panier dans la console
                Console.WriteLine($"User {userId} cart: {string.Join(", ", cart)}");
                return Ok(new { message = "Cart saved successfully" });
            }
            else
            {
                return Unauthorized();
            }
        }

        public class CartItem
        {
            public string IdTicket { get; set; }
            public string IdEvent { get; set; }
            public string IdOffer { get; set; }
        }
    }
}
