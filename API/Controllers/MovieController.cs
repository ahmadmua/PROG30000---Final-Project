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

        private DataContext _db;
        public MovieController(DataContext db)
        {
            _db = db;
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

                    if (_db.Movies.Any(x => x.Title == movie.Title) & _db.Movies.Any(x => x.Release_date == movie.Release_date))
                    {
                        return BadRequest("Movie already exists");
                    }

                    await _db.Movies.AddAsync(movie);
                    await _db.SaveChangesAsync();
                    return Ok(movie);
                }

                return BadRequest("Please use 'YYYY-MM-DD' format");

            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }


    }
}