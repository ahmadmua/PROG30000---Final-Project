using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.models
{
    public abstract class VisualMedia
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string Release_date { get; set; }
        public float? Vote_average { get; set; }
        public string? Poster_path { get; set; }
        public string Genre { get; set; }
    }
}