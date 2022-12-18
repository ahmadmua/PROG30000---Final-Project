using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

//Author Muaz Ahmad
namespace API.models
{
    public class AppUser : IdentityUser
    {
        public string Review { get; set; }
    }
}