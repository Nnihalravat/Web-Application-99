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
    public DbSet<RegistrationForm> regs { get; set; }
  
   
  }
}
