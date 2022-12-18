using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.models;
using Microsoft.AspNetCore.Mvc;

//Author: Nicholas Cammisuli
namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MediaController : ControllerBase
    {
        private DataContext _db;
        public MediaController(DataContext db)
        {
            _db = db;
        }

        //POST /api/media/watchlater
        [HttpPost("WatchLater")]
        public async Task<IActionResult> AddWatchLaterAsync([FromBody] string title)
        {
            if (_db.WatchLaters.Any(x => x.ToWatch == title))
                return BadRequest("Media already in Watch Later");


            var data = new WatchLater
            {
                ToWatch = title
            };

            await _db.WatchLaters.AddAsync(data);
            await _db.SaveChangesAsync();
            return Ok("Media added to Watch Later");
        }

        //GET /api/media/watchlater
        [HttpGet("WatchLater")]
        public IActionResult GetWatchLater()
        {
            return Ok(_db.WatchLaters);
        }



        //POST /api/media/Favorites
        [HttpPost("Favorites")]
        public async Task<IActionResult> AddFavoritesAsync([FromBody] string title)
        {
            if (_db.Favorites.Any(x => x.FavoritesMedia == title))
                return BadRequest("Media already in Favorites");

            var data = new Favorites
            {
                FavoritesMedia = title
            };

            await _db.Favorites.AddAsync(data);
            await _db.SaveChangesAsync();
            return Ok("Media added to favorites");
        }

        //GET /api/media/Favorites
        [HttpGet("Favorites")]
        public IActionResult GetFavorites()
        {
            return Ok(_db.Favorites);
        }
    }
}