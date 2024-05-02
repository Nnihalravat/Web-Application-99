using System.ComponentModel.DataAnnotations;

namespace Web_Application_99.Models
{
  public class User
  {
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }


  }
}
