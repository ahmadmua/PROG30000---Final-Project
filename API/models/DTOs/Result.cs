using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.DTOs
{
        public class Result
    {
        public string Release_date { get; set; }
        public string Genre { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string poster_path { get; set; }
        public double vote_average { get; set; }
    }

    public class Root
    {
        public List<Result> results { get; set; }
    }
}