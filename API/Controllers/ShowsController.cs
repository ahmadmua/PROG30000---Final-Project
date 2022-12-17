using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.models;
using API.Models;
using API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShowsController : ControllerBase
    {
        private DataContext _database;

        public ShowsController(DataContext database)
        {
            _database = database;
        }

        [HttpPost]
        public IActionResult PopulateShows(Root result)
        {
            foreach (var show in result.results)
            {
                var newShow = new TVShow{
                    Title = show.Title,
                    Genre = show.Genre,
                    Release_date = show.Release_date,
                    Vote_average = (float?)show.vote_average,
                    Poster_path = show.poster_path,
                    Overview = show.Overview,
                    Episodes = show.Episodes,
                    Seasons = show.Seasons
                };

                _database.Shows.Add(newShow);
            }

            _database.SaveChanges();

            return Ok();
            
        }

        [HttpGet]
        public IActionResult DeleteShows()
        {
            foreach (var show in _database.Shows)
            {
                _database.Shows.RemoveRange(show);
            }

            _database.SaveChanges();

            return Ok();
            
        }


    }
}