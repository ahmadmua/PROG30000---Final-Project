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

                 var user = new AppUser { UserName = "testuser" };
                await _userManager.CreateAsync(user, "password");

    // Act
    var result = await _signInManager.PasswordSignInAsync(user.UserName, "password", false, false);

    // Assert
    Assert.True(result.Succeeded);

    }
}