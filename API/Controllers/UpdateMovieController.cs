using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.models;
using API.Models;
using Microsoft.AspNetCore.Mvc;

//Author: Nicholas Cammisuli
namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UpdateMovieController : ControllerBase
    {
        private DataContext _db;
        public UpdateMovieController(DataContext db)
        {
            _db = db;
        }


        [HttpGet]
        public IActionResult UploadDataAsync()
        {


            var response = new Movie
            {
                Title = "Corrective Measures",
                Overview = "Set in San Tiburon, the world's most dangerous maximum-security penitentiary and home to the world's most treacherous superpowered criminals, where tensions among the inmates and staff heighten, leading to anarchy that engulfs the prison and order is turned upside down.",
                Poster_path = "/aHFq9NMhavOL0jtQvmHQ1c5e0ya.jpg",
                Vote_average = 5.2F,
                Release_date = "2022-04-29",
                Runtime = 107,
                Genre = "Action/Sci-Fi"
            };

            var response1 = new Movie
            {
                Title = "The Guardians of the Galaxy Holiday Special",
                Overview = "On a mission to make Christmas unforgettable for Quill, the Guardians head to Earth in search of the perfect present.",
                Poster_path = "/8dqXyslZ2hv49Oiob9UjlGSHSTR.jpg",
                Vote_average = 7.5F,
                Release_date = "2022-11-25",
                Runtime = 41,
                Genre = "Action/Adventure/Comedy"
            };

            var response2 = new Movie
            {
                Title = "Disenchanted",
                Overview = "Disillusioned with life in the city, feeling out of place in suburbia, and frustrated that her happily ever after hasn’t been so easy to find, Giselle turns to the magic of Andalasia for help. Accidentally transforming the entire town into a real-life fairy tale and placing her family’s future happiness in jeopardy, she must race against time to reverse the spell and determine what happily ever after truly means to her and her family.",
                Poster_path = "/4x3pt6hoLblBeHebUa4OyiVXFiM.jpg",
                Vote_average = 7.2F,
                Release_date = "2022-11-16",
                Runtime = 119,
                Genre = "Adventure/Comedy"
            };

            var response3 = new Movie
            {
                Title = "Lyle, Lyle, Crocodile",
                Overview = "When the Primm family moves to New York City, their young son Josh struggles to adapt to his new school and new friends. All of that changes when he discovers Lyle — a singing crocodile who loves baths, caviar and great music — living in the attic of his new home. But when Lyle’s existence is threatened by evil neighbor Mr. Grumps, the Primms must band together to show the world that family can come from the most unexpected places.",
                Poster_path = "/irIS5Tn3TXjNi1R9BpWvGAN4CZ1.jpg",
                Vote_average = 7.9F,
                Release_date = "2022-10-07",
                Runtime = 110,
                Genre = "Adventure/Comedy"
            };

            var response4 = new Movie
            {
                Title = "Diary of a Wimpy Kid: Rodrick Rules",
                Overview = "A new school year, his brother Rodrick teases him over and over and over and over again. Will Greg manage to get along with him? Or will a secret ruin everything?",
                Poster_path = "/iW6ixzkrvdrcxk0umiLZMtlSl9L.jpg",
                Vote_average = 6.5F,
                Release_date = "2022-12-02",
                Runtime = 74,
                Genre = "Animation/Comedy"
            };



            _db.Movies.Add(response);
            _db.Movies.Add(response1);
            _db.Movies.Add(response2);
            _db.Movies.Add(response3);
            _db.Movies.Add(response4);
            _db.SaveChanges();

            return Ok(response);

        }

    }
}