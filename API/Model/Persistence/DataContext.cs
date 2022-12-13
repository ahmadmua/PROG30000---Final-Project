using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Model.Persistence
{
    public class DataContext : DbContext
    {

        public DbSet<VisualMedia> Medias { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("FileName=MovieDatabase.db");
        }
    }
}