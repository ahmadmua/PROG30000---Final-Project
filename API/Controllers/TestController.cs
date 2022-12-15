using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("open")]
        public IActionResult GetText(){

            return Ok("all good");
        }

        [Authorize]
        [HttpGet("secure")]
        public IActionResult GetSecureText(){

            return Ok("You have an account");
        }
    }
}