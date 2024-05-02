using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Application_99.Models;

namespace Web_Application_99.Controllers
{
  public class MusicPost : ControllerBase
  {
    private readonly MyDbContext _db;
    private readonly string _title;
    public MusicPost(MyDbContext db)
    {
      _title = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "music");
      _db = db;
    }



    [HttpPost("Upload")]
    public async Task<IActionResult> UploadMusic([FromForm] IFormFile musicFile)
    {
      try
      {
        if (musicFile == null || musicFile.Length == 0)
        {
          return BadRequest("Music file is null or empty.");
        }
        else
        {
          var fileName = Guid.NewGuid().ToString() + Path.GetExtension(musicFile.FileName);
          var filePath = Path.Combine(_title, fileName);

          using (var stream = new FileStream(filePath, FileMode.Create))
          {
            await musicFile.CopyToAsync(stream);
          }

          var music = new MusicP
          {
            FileName = fileName,
            FilePath = filePath,
            UploadDate = DateTime.Now
          };

          // Save music information to the database
          _db.musics.Add(music);
          await _db.SaveChangesAsync();

          return Ok(new { message = "Music file uploaded successfully", filePath });
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine($"An error occurred while uploading the music file: {ex.Message}");
        return StatusCode(500, "An error occurred while uploading the music file.");
      }
    }
  }
}

