using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Model;
using API.Model.Persistence;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Globalization;

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
        public IActionResult UploadDataAsync()
        {

            StreamReader r = new StreamReader("Model/Json/movies.json");
            string jsonString = r.ReadToEnd();
            var dataObj = JObject.Parse(jsonString);

            foreach (var result in dataObj["results"])
            {
                var vote = float.Parse($"{result["vote_average"]}", CultureInfo.InvariantCulture.NumberFormat);
                var response = new VisualMedia
                {
                    title = $"{result["title"]}",
                    overview = $"{result["overview"]}",
                    poster_path = $"{result["poster_path"]}",
                    vote_average = vote,
                    release_date = $"{result["release_date"]}",
                };

                // _db.Medias.Add(response);
                // _db.SaveChanges();

                return Ok(response);
            }
            // var dataObj = JsonSerializer.Deserialize<JObject>(jsonString);

            // foreach (KeyValuePair<string, JToken> item in dataObj)
            // {
            //     int iKey = 0;
            //     string key = item.Key;
            //     JToken jToken = item.Value;
            //     if (int.TryParse(key, out iKey))
            //     {
            //         string value = jToken.ToString();
            //         Console.WriteLine(key + "--" + value);
            //         return Ok(value);
            //     }
            // }

            return Ok("Fail");

            // foreach (var result in dataObj)
            // {

            //     JArray obj = JArray.Parse(result);

            //     foreach (JObject parsedObject in dataObj.Children<JObject>())
            //     {
            //         foreach (JProperty parsedProperty in parsedObject.Properties())
            //         {
            //             string propertyName = parsedProperty.Name;
            //             if (propertyName.Equals("title"))
            //             {
            //                 string propertyValue = (string)parsedProperty.Value;
            //                 Console.WriteLine("Name: {0}, Value: {1}", propertyName, propertyValue);
            //                 return Ok(propertyValue);
            //             }
            //         }
            //     }
            // }
            // return BadRequest();

            // var response = new VisualMedia
            // {
            //     title = $"{dataObj["results"]["adult"]}",
            //     overview = $"{dataObj["adult"]}",
            //     poster_path = $"{dataObj["poster_path"]}",
            //     vote_average = 5.5F,
            //     release_date = $"{dataObj["title"]}",
            // };

            // Console.WriteLine(response);
            // return Ok();

            // //Define your base url
            // string baseURL = $"https://api.themoviedb.org/3/movie/popular?api_key=6b967fb6a6adb1090bb2d704b501a3c9&language=en-US&page=1";
            // //Have your api call in try/catch block.
            // try
            // {

            //     StreamReader r = new StreamReader(@"./Json/movies.json");
            //     string jsonString = r.ReadToEnd();
            //     var dataObj = JObject.Parse(jsonString);


            //     var response = new VisualMedia
            //     {
            //         title = $"{dataObj["results"]}",
            //         overview = $"{dataObj["adult"]}",
            //         poster_path = $"{dataObj["poster_path"]}",
            //         vote_average = 5.5F,
            //         release_date = $"{dataObj["title"]}",
            //     };

            //     Console.WriteLine(response);
            //     return Ok(response);


            //     // //Now we will have our using directives which would have a HttpClient 
            //     // using (HttpClient client = new HttpClient())
            //     // {
            //     //     //Now get your response from the client from get request to baseurl.
            //     //     //Use the await keyword since the get request is asynchronous, and want it run before next asychronous operation.
            //     //     using (HttpResponseMessage res = await client.GetAsync(baseURL))
            //     //     {
            //     //         //Now we will retrieve content from our response, which would be HttpContent, retrieve from the response Content property.
            //     //         using (HttpContent content = res.Content)
            //     //         {
            //     //             //Retrieve the data from the content of the response, have the await keyword since it is asynchronous.
            //     //             string data = await content.ReadAsStringAsync();
            //     //             //If the data is not null, parse the data to a C# object, then create a new instance of PokeItem.
            //     //             if (data != null)
            //     //             {
            //     //                 //Parse your data into a object.
            //     //                 var dataObj = JObject.Parse(data);
            //     //                 //Then create a new instance of PokeItem, and string interpolate your name property to your JSON object.
            //     //                 //Which will convert it to a string, since each property value is a instance of JToken.
            //     //                 // PokeItem pokeItem = new PokeItem(name: $"{dataObj["name"]}");

            //     //                 var response = new VisualMedia
            //     //                 {
            //     //                     title = $"{dataObj["results"]}",
            //     //                     overview = $"{dataObj["total_results"]}",
            //     //                     poster_path = $"{dataObj["poster_path"]}",
            //     //                     vote_average = 5.5F,
            //     //                     release_date = $"{dataObj["title"]}",
            //     //                 };

            //     //                 return Ok(response);

            //     //                 // Console.WriteLine(dataObj);
            //     //                 // Console.WriteLine($"{dataObj["results:[title]"]}");
            //     //                 //Log your pokeItem's name to the Console.
            //     //                 // Console.WriteLine("Pokemon Name: {0}", pokeItem.Name);
            //     //                 // return Ok(response);
            //     //             }
            //     //             else
            //     //             {
            //     //                 //If data is null log it into console.
            //     //                 Console.WriteLine("Data is null!");
            //     //                 return BadRequest();
            //     //             }
            //     //         }
            //     //     }
            //     // }
            //     //Catch any exceptions and log it into the console.
            // }
            // catch (Exception exception)
            // {
            //     Console.WriteLine(exception);
            //     return BadRequest();
            // }
        }


    }
}