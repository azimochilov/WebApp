using System.ComponentModel.DataAnnotations;

namespace WebApp.Service.DTOs.Authors;
public class AuthorCreationDto
{
    [Required]
    public string Name { get; set; }
}
