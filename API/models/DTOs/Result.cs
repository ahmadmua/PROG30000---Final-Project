using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Author Jordan Bhar
//used this to populate the database initialy never used again for main functonalities 
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
        public int Episodes { get; set; }
        public int Seasons { get; set; }


    }

    public class Root
    {
        public List<Result> results { get; set; }
    }
}