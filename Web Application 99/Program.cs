using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;
using Web_Application_99;
using Web_Application_99.Interfaces;
using Web_Application_99.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // it is used for swagger openai support


builder.Services.AddDbContext<MyDbContext>(options =>
{
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
}, ServiceLifetime.Scoped);

builder.Services.AddScoped<IUser, UserRepository>();

builder.Services.AddCors(options =>
{
  options.AddPolicy("MyPolicyToAllowAnyOne", builder =>
  {
    builder.AllowAnyMethod();
    builder.AllowAnyHeader();
    builder.AllowAnyOrigin();
  });
});

// Generate a strong random secret key
string secretKey = GenerateRandomKey(32); // 256 bits (32 bytes)
// Configure JWT authentication with the generated secret key
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//      options.TokenValidationParameters = new TokenValidationParameters
//      {
//        ValidateIssuer = false,
//        ValidateAudience = false,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
//      };
//    });


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
  options.TokenValidationParameters = new TokenValidationParameters
  {
    ValidateIssuer = false,
    ValidateAudience = false,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey))
  };
});

var app = builder.Build();
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//  app.UseSwagger();
//  app.UseSwaggerUI();
//}

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors("MyPolicyToAllowAnyOne");

app.MapControllers();

app.Run();


// Method to generate a random secret key
string GenerateRandomKey(int lengthInBytes)
{
  using (var rng = new RNGCryptoServiceProvider())
  {
    var keyBytes = new byte[lengthInBytes];
    rng.GetBytes(keyBytes);
    return Convert.ToBase64String(keyBytes);
  }
}
