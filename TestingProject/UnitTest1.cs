using Microsoft.AspNetCore.Identity;
using API.models;
using API.models.DTOs;
using API.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

namespace TestingProject;

public class UnitTest1
{

        private SignInManager<AppUser> _signInManager;
        private UserManager<AppUser> _userManager;
        
    
    [Fact]
    public async Task LoginTestAsync()
    {

                var user = new AppUser() { 
                
                    Email = "JohnDoe@gmail.com",
                    UserName = "JohnDoe",
                    Review = ""
                
                };

             var result = await _userManager.CreateAsync(user, "Abc123me@");

            Assert.True(result.Succeeded);

    }
}