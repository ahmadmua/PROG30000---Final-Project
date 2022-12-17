using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.models;
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


    }
}