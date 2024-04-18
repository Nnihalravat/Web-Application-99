using Microsoft.AspNetCore.Mvc;

namespace Web_Application_99.Controllers
{

  [ApiController]
  [Route("[controller]")]
  public class HomeController : ControllerBase
  {
    [HttpPost]
    public async Task<IActionResult> First(string name)
    {
      if (name == null)
      {
        return BadRequest();
      }
      else
      {
        return Ok();
        Console.WriteLine(name);
        Console.WriteLine("The name is");
        Console.WriteLine("The name is s");
   

      }
    }
  }
}
