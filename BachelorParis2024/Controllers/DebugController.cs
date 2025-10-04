using Microsoft.AspNetCore.Mvc;

namespace BachelorParis2024.Controllers
{
    public class DebugController : Controller
    {
        private readonly IConfiguration _config;

        public DebugController(IConfiguration config)
        {
            _config = config;
        }

        // Pas besoin de vue, on renvoie directement du texte
        public IActionResult ConnectionString()
        {
            var conn = _config.GetConnectionString("DefaultConnection");
            return Content($"Chaîne de connexion active : {conn}");
        }
    }
}

