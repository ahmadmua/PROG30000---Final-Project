using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.models
{
    public class MediaLists
    {
        public Guid Id { get; set; }
        public string? WatchLater { get; set; }
        public string? Favorites { get; set; }
    }
}