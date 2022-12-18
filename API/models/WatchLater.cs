using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.models
{
    public class WatchLater
    {
        public Guid Id { get; set; }
        public string? ToWatch { get; set; }
    }
}