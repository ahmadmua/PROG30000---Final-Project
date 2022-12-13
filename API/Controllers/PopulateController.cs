using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Model;
using API.Model.Persistence;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PopulateController : ControllerBase
    {
        private DataContext _db;
        public PopulateController(DataContext db)
        {
            _db = db;
        }

        //POST /api/People/[array of people]
        [HttpGet]
        public async Task<IActionResult> UploadDataAsync()
        {

            //Define your base url
            string baseURL = $"https://api.themoviedb.org/3/movie/popular?api_key=6b967fb6a6adb1090bb2d704b501a3c9&language=en-US&page=1";
            //Have your api call in try/catch block.
            try
            {
                //Now we will have our using directives which would have a HttpClient 
                using (HttpClient client = new HttpClient())
                {
                    //Now get your response from the client from get request to baseurl.
                    //Use the await keyword since the get request is asynchronous, and want it run before next asychronous operation.
                    using (HttpResponseMessage res = await client.GetAsync(baseURL))
                    {
                        //Now we will retrieve content from our response, which would be HttpContent, retrieve from the response Content property.
                        using (HttpContent content = res.Content)
                        {
                            //Retrieve the data from the content of the response, have the await keyword since it is asynchronous.
                            string data = await content.ReadAsStringAsync();
                            //If the data is not null, parse the data to a C# object, then create a new instance of PokeItem.
                            if (data != null)
                            {
                                //Parse your data into a object.
                                var dataObj = JObject.Parse(data);
                                //Then create a new instance of PokeItem, and string interpolate your name property to your JSON object.
                                //Which will convert it to a string, since each property value is a instance of JToken.
                                // PokeItem pokeItem = new PokeItem(name: $"{dataObj["name"]}");
                                // var response = new VisualMedia
                                // {
                                //     title = $"{dataObj["title"]}",
                                //     overview = $"{dataObj["overview"]}",
                                //     poster_path = $"{dataObj["poster_path"]}",
                                //     vote_average = 5.5F,
                                //     release_date = $"{dataObj["title"]}",
                                // };
                                Console.WriteLine(dataObj);
                                // Console.WriteLine(response);
                                //Log your pokeItem's name to the Console.
                                // Console.WriteLine("Pokemon Name: {0}", pokeItem.Name);
                                return Ok();
                            }
                            else
                            {
                                //If data is null log it into console.
                                Console.WriteLine("Data is null!");
                                return BadRequest();
                            }
                        }
                    }
                }
                //Catch any exceptions and log it into the console.
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return BadRequest();
            }
        }


    }
}