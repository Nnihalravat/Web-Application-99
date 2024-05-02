using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Principal;
using Web_Application_99.Interfaces;
using Web_Application_99.Models;
using Web_Application_99.Repositories;

namespace Web_Application_99.Controller;

[ApiController]
[Route("[controller]")]
//it is attribute routing - directly applicable on the controller - where is fixed the prefix which is the name of controller
public class HomeController : ControllerBase
{

  string message = "Success";
  string ErrorMessage = "Something went wrong";


  private readonly MyDbContext _dbContext;
  private readonly IUser _userRepository; 

  public HomeController(MyDbContext dbContext, IUser userRepository)
  {
    _dbContext = dbContext;
    _userRepository = userRepository;
  }

  [HttpPost("User-Posts")]
  public async Task<IActionResult> UserPosting(HomeModel model)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }
    else
    {
      Stopwatch sw = Stopwatch.StartNew();
      var user = new HomeModel
      {
        Name = model.Name,
        Email = model.Email,
        Designation = model.Designation,
        Phone = model.Phone,
      };

      //_dbContext.Add(user);
      _dbContext.homes.Add(user);
      await _dbContext.SaveChangesAsync();
      sw.Stop();
      Console.WriteLine($"Elapsed time: {sw.Elapsed}");
      return Ok(new { message });
    }
  }

  [HttpPost]
  public async Task<IActionResult> PostAccount(account ac)
  {
    if (ac == null)
    {
      return BadRequest("Invalid account object");
    }

    // Generate a new GUID for the primary key
    //ac.AccountId = Guid.NewGuid();
    ac.accountId = Guid.NewGuid();

    _dbContext.accounts.Add(ac);
    await _dbContext.SaveChangesAsync();

    return Ok(ac);
  }

  [HttpGet("get-guid")]
  public async Task<IActionResult> GetGuid(Guid accountid)
  {
    if(accountid == null)
    {
      return BadRequest();
    }
    else
    {
      Stopwatch sw = Stopwatch.StartNew();
      //var findGuid = await _dbContext.accounts.Where(a => a.accountId == accountid).ToListAsync();
      var accounts = await _dbContext.accounts.FromSqlRaw("EXEC GetAccountByGuid @AccountId", new SqlParameter("@AccountId", accountid)).ToListAsync();
      sw.Stop();
      // Log the execution time (optional)
      Console.WriteLine($"Execution time: {sw.ElapsedMilliseconds} ms");
      return Ok(accounts);
    }
  }


  [HttpDelete("hithere-delete")]
  public async Task<IActionResult> AccountPostDelete(account acc)
  {
    if (acc == null)
    {
      return BadRequest(new { ErrorMessage });
    }
    else
    {
      _dbContext.accounts.Remove(acc);
      await _dbContext.SaveChangesAsync();
      return Ok(new { message });
    }
  }



  [HttpGet("GetAllUserPosts")]
  public async Task<IActionResult> GetAllUserPosts()
  {
    var userAll = await _dbContext.homes.ToListAsync();
    return Ok(userAll);
  }

  [HttpDelete("DeleteAllUsers")]
  public async Task<IActionResult> GetDeleteAllUsers()
  {
    var deleteAll = await _dbContext.homes.ToListAsync();
    _dbContext.homes.RemoveRange(deleteAll);
    await _dbContext.SaveChangesAsync();
    return Ok(message);

  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteById(int id)
  {
    var user = await _dbContext.homes.FindAsync(id);
    if (user == null)
    {
      return NotFound();
    }
    _dbContext.homes.Remove(user);
    await _dbContext.SaveChangesAsync();
    return Ok(message);
  }



[HttpGet("GetUser/{id}")]
  public async Task<IActionResult> GetUserById(int id)
  {
    var idUser = await _dbContext.homes.FindAsync(id);
    if(idUser == null)
    {
      return BadRequest();
    }
    else
    {
      return Ok(idUser);
    }
  }




  [HttpPut("{id}")]
  public async Task<IActionResult> NihalEdit(int id, [FromBody] HomeModel model)
  {
    var home = await _dbContext.homes.FirstOrDefaultAsync(u => u.id == id);

    if (home == null)
    {
      return NotFound(ErrorMessage);
    }
    else
    {
      // Update the properties if they are provided in the model
      if (!string.IsNullOrEmpty(model.Name))
      {
        home.Name = model.Name;
      }
      if (!string.IsNullOrEmpty(model.Designation))
      {
        home.Designation = model.Designation;
      }

      _dbContext.homes.Update(home);
      await _dbContext.SaveChangesAsync();
      return Ok(home);
    }
  }



  [HttpPost("here it is")]
  public async Task<IActionResult> GetUser([FromBody]User user)
  {
    if(user == null)
    {
      return BadRequest();
    }
    await _userRepository.CreateUserAsync(user);
    return Ok(new {user,  messages = "There you are" });
  }
}
