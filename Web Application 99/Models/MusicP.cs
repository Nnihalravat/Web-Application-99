using Microsoft.AspNetCore.Http;
using System;

namespace Web_Application_99.Models
{
  public class MusicP
  {
    public int Id { get; set; }
    public string? FileName { get; set; }
    public string? FilePath { get; set; }
    public DateTime UploadDate { get; set; }
  }
}