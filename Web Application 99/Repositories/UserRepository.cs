using Microsoft.AspNetCore.Mvc;
using Web_Application_99.Interfaces;
using Web_Application_99.Models;

namespace Web_Application_99.Repositories
{
  public class UserRepository : IUser
  {

    private readonly MyDbContext _context;


    public UserRepository(MyDbContext context)
    {
        _context = context;
    }

    public async Task CreateUserAsync(User user)
    {
      _context.users.Add(user);
      await _context.SaveChangesAsync();

    }

    private void Ok(User user)
    {
      string message = "Success";
    }

    public Task DeleteUserAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<User> GetUserByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<IActionResult> PostUserAsync([FromBody] User user)
    {
      throw new NotImplementedException();
    }

    public Task UpdateUserAsync(User user)
    {
      throw new NotImplementedException();
    }
  }
}
