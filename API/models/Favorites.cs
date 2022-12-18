using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.models
{
    public class Favorites
    {
        public Guid Id { get; set; }
        public string? FavoritesMedia { get; set; }
    }
}