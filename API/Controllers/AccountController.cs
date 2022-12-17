using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.models;
using API.models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {

        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;

        private TokenService _tokenService;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, 
        TokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("signUp")]
        public async Task<IActionResult> SignUpAsync(RegisterDto registerDto){

            var user = new AppUser{
            
                Email = registerDto.Email,
                UserName = registerDto.UserName,
                Review = ""
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if(result.Succeeded){
                return Ok();
            }

            return BadRequest(result.Errors);
            
        }

        [HttpGet("username")]
        public async Task<IActionResult> GetUserName(){

           // var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));
           string? userId = User.FindFirst(ClaimTypes.Name)?.Value;
            return Ok(userId);

        }


        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginDto loginDto){

            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if(user == null){
                return NotFound();
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if(result.Succeeded){
                
                return Ok(_tokenService.CreateToken(user));
            }

            return Unauthorized();
        }
    }
}