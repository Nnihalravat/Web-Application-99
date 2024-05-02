using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Application_99.Models
{

  public class account
  {

    public Guid accountId { get; set; }
    public string? key2 { get; set; }

    internal static object FromSqlRaw(string v, SqlParameter sqlParameter)
    {
      throw new NotImplementedException();
    }
  }
}
