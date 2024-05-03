using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Numerics;

namespace Web_Application_99.Models
{
  public class RegistrationForm
  {
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage ="Enter Full Name")]
    public string? FullName { get; set; }

    [Required(ErrorMessage ="Enter Gender")]
    public string? Gender { get; set; }

    [Required(ErrorMessage ="Please enter your address")]
    public string? Address { get; set; }


    [Required(ErrorMessage = "Please enter your city")]
  
    public string? City { get; set; }

    [Required(ErrorMessage = "Please enter your pin code")]
    [RegularExpression(@"^\d{6}$", ErrorMessage = "PIN code must be 6 digits.")]
    public string? Pin { get; set; }

    [Required(ErrorMessage = "Please enter your state")]
    public string? state { get; set; }


    [Required(ErrorMessage = "Please enter your Country")]
    public string? Country { get; set; }


    [Required(ErrorMessage = "Please enter your email.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Please enter your contact number.")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Contact number must be 10 digits.")]
    public string? Contact { get; set;}

    [Required(ErrorMessage = "Please enter your education.")]
    public string? Education { get; set;}

    [Required(ErrorMessage = "Please enter your designation.")]
    public string? Designation { get; set;}

  }
}
