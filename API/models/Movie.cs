using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.models;

namespace API.Models
{
    public class Movie : VisualMedia
    {
        public int Runtime { get; set; }
    }
}