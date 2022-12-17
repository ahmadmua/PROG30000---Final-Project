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
        public IActionResult PopulateShows(Root results)
        {
           
            var movieList = new List<TVShow>();

            

            return Ok();


            





        }

    }
}