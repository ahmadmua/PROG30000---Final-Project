using System.Text;
using API.models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



 builder.Services.AddEntityFrameworkSqlite().AddDbContext<DataContext>();

 builder.Services.AddIdentityCore<AppUser>(options =>
 {
     options.Password.RequireNonAlphanumeric = false;
     
 })
 .AddEntityFrameworkStores<DataContext>()
 .AddSignInManager<SignInManager<AppUser>>();

builder.Services.AddScoped<TokenService>();


 var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is my super duper key"));
 builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
 .AddJwtBearer(opt =>
 {
     opt.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuerSigningKey = true,
         IssuerSigningKey = key,
         ValidateIssuer = false,
         ValidateAudience = false,
     };
 });


builder.Services.AddCors(options =>
{
    options.AddPolicy("AcceptAllPolicy", policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AcceptAllPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
