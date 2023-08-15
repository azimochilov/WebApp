using System.ComponentModel.DataAnnotations;

namespace WebApp.Service.DTOs.Authors;
public class AuthorUpdateDto
{
    [Required]
    public long Id { get; set; }
    [Required]
    public string Name { get; set; }
}
