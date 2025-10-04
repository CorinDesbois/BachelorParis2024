using BachelorParis2024.Repository.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BachelorParis2024.Controllers
{
    public class DbDebugController : Controller
    {
        private readonly DbProjectContext _db;

        public DbDebugController(DbProjectContext db)
        {
            _db = db;
        }

        [HttpGet("/debug/whoami")]
        public async Task<IActionResult> WhoAmI()
        {
            // Exécute une requête SQL brute pour voir l'utilisateur courant
            var currentUser = await _db.Database
                .SqlQueryRaw<string>("SELECT SUSER_SNAME()")
                .FirstAsync();

            var currentSid = await _db.Database
                .SqlQueryRaw<byte[]>("SELECT SUSER_SID()")
                .FirstAsync();

            string sidHex = "0x" + BitConverter.ToString(currentSid).Replace("-", "");

            return Content($"Utilisateur SQL courant : {currentUser}\nSID (hex) : {sidHex}");
        }
    }
}

