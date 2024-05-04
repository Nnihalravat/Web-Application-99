using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using Web_Application_99.Models;

namespace Web_Application_99
{
  public class MyDbContext : DbContext
  {
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      // No need to map the stored procedure here
    }


    public DbSet<RegistrationForm> regs { get; set; }

    // Define a method to execute the stored procedure
   
  }
}
