using Microsoft.AspNetCore.Mvc;
using Web_Application_99.Models;

namespace Web_Application_99.Interfaces
{
  public interface IUser
  {
    Task <User> GetUserByIdAsync (int id);

    public Task <IActionResult> PostUserAsync([FromBody] User user);

    Task CreateUserAsync (User user);

    Task UpdateUserAsync (User user);

    Task DeleteUserAsync (int id);

  }
}
