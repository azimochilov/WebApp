using System.ComponentModel.DataAnnotations;

namespace WebApp.Service.DTOs.Authors;
public class AuthorResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
}
