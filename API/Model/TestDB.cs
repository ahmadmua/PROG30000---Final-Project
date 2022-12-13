using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    public class TestDB
    {
        public Guid Id { get; set; }
        public string title { get; set; }
        public string overview { get; set; }
        public string release_date { get; set; }
        public float vote_average { get; set; }
        public string poster_path { get; set; }
        public List<int> genre_ids { get; set; }
    }
}