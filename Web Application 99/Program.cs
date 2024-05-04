using Microsoft.EntityFrameworkCore;
using Web_Application_99;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add Swagger/OpenAPI services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS policy
builder.Services.AddCors(options =>
{
  options.AddPolicy("MyPolicyToAllowAnyOne", builder =>
  {
    builder.AllowAnyMethod();
    builder.AllowAnyHeader();
    builder.AllowAnyOrigin();
  });
});

// Add DbContext
builder.Services.AddDbContext<MyDbContext>(options =>
{
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
}, ServiceLifetime.Scoped);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

// Apply CORS policy
app.UseCors("MyPolicyToAllowAnyOne");

app.UseEndpoints(endpoints =>
{
  endpoints.MapControllers();
});

app.Run();
