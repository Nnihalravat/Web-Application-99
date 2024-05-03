using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Web_Application_99.Models;

namespace Web_Application_99.Controllers
{

  [ApiController]
  [Route("[controller]")]
  public class RegistrationFormController : ControllerBase
  {

    private readonly MyDbContext _context;
    string successMessage = "Record Inserted Successfully";
    string deleteMessage = "All Data successfully deleted";
    public RegistrationFormController(MyDbContext context)
    {
      _context = context;
    }


    [HttpPost("RegisterForm")]
    public async Task<IActionResult> RegisterFrom([FromBody] RegistrationForm registers)
    {
      try
      {
        if (registers == null)
        {
          return BadRequest();
        }
        else
        {
          var usersPost = new RegistrationForm()
          {
            FullName = registers.FullName,
            Gender = registers.Gender,
            Address = registers.Address,
            City = registers.City,
            Pin = registers.Pin,
            state = registers.state,
            Country = registers.Country,
            Email = registers.Email,
            Contact = registers.Contact,
            Education = registers.Education,
            Designation = registers.Designation,

          };
          _context.regs.Add(usersPost);
          await _context.SaveChangesAsync();
          return Ok(successMessage);



        }
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, ex);
      }
    }

    [HttpDelete("Delete-Registers")]
    public async Task<IActionResult> ViewsAllRegisters()
    {
      var delreg = await _context.regs.ToListAsync();
      _context.regs.RemoveRange(delreg);
      await _context.SaveChangesAsync();
      return Ok(deleteMessage);
    }

    [HttpGet("View-Registers-ById")]
    public async Task<IActionResult> ViewRegistersById(int Id)
    {
      var findreg = await _context.regs.FirstOrDefaultAsync();
      return Ok(findreg);
    }

    [HttpGet("View-All-Registersss")]
    public async Task<IActionResult> ViewAllRegisters()
    {
      var allRegs = await _context.regs.ToListAsync();
      return Ok(allRegs);
    }

    [HttpGet("View-All-Registers")]
    public async Task<IActionResult> ViewAllRegisters(int pageNumber = 1, int pageSize = 8)
    {
      var totalRecords = await _context.regs.CountAsync();
      var totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

      var registers = await _context.regs
          .Skip((pageNumber - 1) * pageSize)
          .Take(pageSize)
          .ToListAsync();

      return Ok(new { totalPages, registers });
    }


    [HttpGet("View-All-Registerss")]
    public async Task<IActionResult> ViewAllRegisters(int pageNumber = 1)
    {
      int pageSize = 8; // Default page size
      var totalRecords = await _context.regs.CountAsync();
      var totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

      var registers = await _context.regs
          .Skip((pageNumber - 1) * pageSize)
          .Take(pageSize)
          .ToListAsync();

      return Ok(new { totalPages, registers });
    }



    [HttpPut("Edit-Regs")]
    public async Task<IActionResult> EditRegs(int id, [FromBody] RegistrationForm model)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var editReg = await _context.regs.FindAsync(id);

      if (editReg == null)
      {
        return NotFound();
      }

      // Update properties of editReg using values from model
      editReg.FullName = model.FullName;
      editReg.Address = model.Address;
      editReg.Gender = model.Gender;
      editReg.Education = model.Education;
      editReg.City = model.City;
      editReg.Contact = model.Contact;
      editReg.Country = model.Country;
      editReg.Designation = model.Designation;
      editReg.Pin = model.Pin;

      // Update other properties as needed...

      try
      {
        _context.regs.Update(editReg);
        await _context.SaveChangesAsync();
        return Ok(editReg); // Successfully updated
      }
      catch (DbUpdateConcurrencyException)
      {
        // Handle concurrency exception
        return StatusCode(500);
      }
    }


  }
}


