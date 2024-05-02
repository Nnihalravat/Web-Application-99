using Microsoft.EntityFrameworkCore;
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

app.UseAuthorization();

app.UseCors("MyPolicyToAllowAnyOne");

app.MapControllers();

app.Run();


1
