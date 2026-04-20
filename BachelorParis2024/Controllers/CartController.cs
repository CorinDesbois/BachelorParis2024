using BachelorParis2024.Data_Transfer_Object;
using BachelorParis2024.Domain.Interfaces;
using BachelorParis2024.Domain.Models;
using BachelorParis2024.Repository.Context;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BachelorParis2024.Controllers
{
    public class CartController : Controller
    {

        //injection du context  +l'interface IEventRepository(pour les événement qui sont provisoirement dans le mock) 
        private readonly DbProjectContext _context;
        private readonly IEventRepository _eventRepository;

        public CartController(DbProjectContext context, IEventRepository eventRepository)
        {
            _context = context;
            _eventRepository = eventRepository;
        }

        //on récupère le panier envoyé par le front via javascript fetch
        //et on le stocke dans la base de données si l'utilisateur est connecté

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostCart([FromBody] List<CartItemDto> cartItems)
        {
            if (cartItems == null)
                return BadRequest(new { message = "No cart items provided" });

            //on vérifie si l'utilisateur est connecté
            if (User.Identity?.IsAuthenticated == true)
            {
                //on récupère l'id de l'utilisateur connecté
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userId == null)
                {
                    return Unauthorized(new { message = "User ID not found in claims" });
                }

                var cart = new Cart
                {
                    UserId = userId,
                    Items = new List<CartItem>()
                };

                foreach (CartItemDto item in cartItems)
                {
                    var offer = await _context.Offre
                        .FirstOrDefaultAsync(o => o.Id == item.IdOffer);
                    if (offer == null)
                    {
                        return NotFound(new { message = "offre non trouvée" });
                    }

                    IEnumerable<EventModel> allEvents = _eventRepository.GetAllEvents();
                    var selectedEvent = allEvents.FirstOrDefault(ev => ev.Id == item.IdEvent);
                    if (selectedEvent == null)
                    {
                        return NotFound(new { message = "événement non trouvée" });
                    }

                    var newCartItem = new CartItem
                    {
                        IdTicket = item.IdTicket,
                        IdEvent = item.IdEvent,
                        Sport = selectedEvent.Sport,
                        Event = selectedEvent.Name,
                        Date = selectedEvent.Date,
                        Location = selectedEvent.Location,
                        IdOffer = item.IdOffer,
                        OfferName = offer.Name,
                        OfferDescription = offer.Description,
                        OfferPersonNb = offer.PersonsNumber,
                        Price = offer.Price,
                        Quantity = item.Quantity,
                        Total = offer.Price * item.Quantity,
                        Cart = cart //rattache chaque item au panier
                    };
                    //on enregistre chaque item dans la base de données
                    _context.CartItems.Add(newCartItem);
                    await _context.SaveChangesAsync();
                }
            }
            return Ok(new { message = "panier sauvegardé" });
        }

        public async Task<IActionResult> Checkout()
        {
            //On récupère l'Id de l'utisateur via Idenity
            if (User.Identity?.IsAuthenticated == true)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userId == null)
                {
                    return View("/Idenity/Login");
                }

                //on récupère le panier de l'utilisateur connecté
                var newcart = await _context.Cart.Where(c => c.UserId == userId)
                    .Include(c => c.Items)
                    .FirstOrDefaultAsync();

                List<CartItem> cartItems = new List<CartItem>();
                
                if (newcart != null)
                {   
                    cartItems = await _context.CartItems
                        .Where(ci => ci.CartId == newcart.Id)
                        .ToListAsync();

                    var ticket = new CartItemViewModel
                    {
                        Cart = newcart,
                        CartItems = cartItems, 
                    };
                    return View("Checkout", ticket);
                }
            }  
            return View("/Idenity/Login");
        }
    
    }
}

