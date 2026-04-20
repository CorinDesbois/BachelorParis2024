    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BachelorParis2024.Domain.Identity;

// Add profile data for application users by adding properties to the BachelorParis2024User class
public class BachelorParis2024User : IdentityUser
{
    //champs ajoutés:
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}

