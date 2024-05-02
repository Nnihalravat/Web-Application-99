using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Application_99.Models
{
  [Table("Owner")]
  public class owner
  {
    public int Ownersid { get; set; }

    public string Ownersname { get; set; } = string.Empty;

  }
}
