using System.ComponentModel.DataAnnotations;

namespace WebApp.Service.DTOs.Genres;
public class GenreCreationDto
{
    [Required]
    public string Name { get; set; }
}
