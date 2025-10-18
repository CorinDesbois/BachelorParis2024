using BachelorParis2024.Domain.Interfaces;
using BachelorParis2024.Domain.Models;
using BachelorParis2024.Repository.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BachelorParis2024.Controllers
{
    public class OrderController : Controller
    {   
        //injection du context  +l'interface IEventRepository(pour les événement qui sont provisoirement dans le mock) 
        private readonly DbProjectContext _context;

        public OrderController(DbProjectContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
