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

    public DbSet<HomeModel> homes { get; set; }

    public DbSet<MusicP> musics { get; set; }

    public DbSet<User> users { get; set; }

    public DbSet<account> accounts { get; set; }

    // Define a method to execute the stored procedure
    public async Task<List<account>> GetAccountsByGuidAsync(Guid accountId)
    {
      // Execute the stored procedure using FromSqlRaw
      return await accounts.FromSqlRaw("EXEC GetAccountByGuid @AccountId", new SqlParameter("@AccountId", accountId)).ToListAsync();
    }
  }
}
