using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.models;

namespace API.Models
{
    //Author Jordan Bhar
    public class TVShow : VisualMedia
    {
        public int Episodes { get; set; }

        public int Seasons { get; set; }
    }
}