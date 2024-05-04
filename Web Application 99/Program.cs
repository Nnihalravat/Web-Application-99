using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;
using Web_Application_99;


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

builder.Services.AddCors(options =>
{
  options.AddPolicy("MyPolicyToAllowAnyOne", builder =>
  {
    builder.AllowAnyMethod();
    builder.AllowAnyHeader();
    builder.AllowAnyOrigin();
  });

  var app = builder.Build();
  //Configure the HTTP request pipeline.
  if (app.Environment.IsDevelopment())
  {
    app.UseSwagger();
    app.UseSwaggerUI();
  }

  app.UseSwagger();

  app.UseSwaggerUI();

  app.UseHttpsRedirection();

  app.UseAuthentication();

  app.UseAuthorization();

  app.UseCors("MyPolicyToAllowAnyOne");

  app.MapControllers();

  app.Run();


});
 



