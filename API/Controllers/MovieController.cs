using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using API.models;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {

        private DataContext _database;
        public MovieController(DataContext db)
        {
            _database = db;
        }

        //POST /api/movie/add
        [HttpPost("add")]
        public async Task<IActionResult> AddMovieToDbAsync(Movie movie)
        {
            string pattern = @"^\d{4}\-(0?[1-9]|1[012])\-(0?[1-9]|[12][0-9]|3[01])$";
            try
            {
                if (string.IsNullOrEmpty(movie.Title))
                    return BadRequest("Title can't be empty");

                if (Regex.Match(movie.Release_date, pattern).Success)
                {

                    if (_database.Movies.Any(x => x.Title == movie.Title) & _database.Movies.Any(x => x.Release_date == movie.Release_date))
                    {
                        return BadRequest("Movie already exists");
                    }

                    await _database.Movies.AddAsync(movie);
                    await _database.SaveChangesAsync();
                    return Ok(movie);
                }

                return BadRequest("Please use 'YYYY-MM-DD' format");

            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies()
        {
            return Ok(_database.Movies);
        }

        [HttpGet("popularMovies")]
        public async Task<IActionResult> GetAllPopularMovies()
        {
            return Ok(_database.Movies.Where(x => x.Vote_average > 5));
        }

    }
}