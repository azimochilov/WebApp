using System.ComponentModel.DataAnnotations;

namespace WebApp.Service.DTOs.Genres;
public class GenreUpdateDto
{
    [Required]
    public long Id { get; set; }
    [Required]
    public string Name { get; set; }
}
