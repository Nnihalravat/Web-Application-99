using System.ComponentModel.DataAnnotations;

namespace Web_Application_99.Models
{
  public class HomeModel 
  {

    [Key]
    public int id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public int Phone { get; set; }

    public string? Designation { get; set; }
  }
}
