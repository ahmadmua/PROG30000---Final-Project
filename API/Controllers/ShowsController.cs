using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

        // [HttpPost]
        // public IActionResult PopulateShows(Root result)
        // {
        //     foreach (var show in result.results)
        //     {
        //         var newShow = new TVShow{
        //             Title = show.Title,
        //             Genre = show.Genre,
        //             Release_date = show.Release_date,
        //             Vote_average = (float?)show.vote_average,
        //             Poster_path = show.poster_path,
        //             Overview = show.Overview,
        //             Episodes = show.Episodes,
        //             Seasons = show.Seasons
        //         };

        //         _database.Shows.Add(newShow);
        //     }

        //     _database.SaveChanges();

        //     return Ok();
            
        // }

        [HttpPost("add")]
        public async Task<IActionResult> AddShowToDbAsync(TVShow show)
        {
            string pattern = @"^\d{4}\-(0?[1-9]|1[012])\-(0?[1-9]|[12][0-9]|3[01])$";
            try
            {
                if (string.IsNullOrEmpty(show.Title))
                    return BadRequest("Title can't be empty");

                if (Regex.Match(show.Release_date, pattern).Success)
                {

                    if (_database.Movies.Any(x => x.Title == show.Title) & _database.Movies.Any(x => x.Release_date == show.Release_date))
                    {
                        return BadRequest("Movie already exists");
                    }

                    await _database.Shows.AddAsync(show);
                    await _database.SaveChangesAsync();
                    return Ok(show);
                }

                return BadRequest("Please use 'YYYY-MM-DD' format");

            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllShows()
        {
            return Ok(_database.Shows);
        }



    }
}