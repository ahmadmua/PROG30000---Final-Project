using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.models
{
  public class DataContext : IdentityDbContext<AppUser>
    {
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             optionsBuilder.UseSqlite("Filename=UserDatabase.db");
         }
    }
}


