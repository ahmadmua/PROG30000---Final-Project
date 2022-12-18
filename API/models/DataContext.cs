using API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.models
{
    public class DataContext : IdentityDbContext<AppUser>
    {

        public DbSet<Movie> Movies { get; set; }
        public DbSet<TVShow> Shows { get; set; }
        public DbSet<MediaLists> MediaLists { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<WatchLater> WatchLaters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=UserDatabase.db");
        }
    }
}


