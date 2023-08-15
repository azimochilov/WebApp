using System.ComponentModel.DataAnnotations;

namespace WebApp.Service.DTOs.Books;
public class BookForUpdateDto
{
    [Required]
    public long Id { get; set; }    
    [Required]
    public long AuthorId { get; set; }
    [Required]
    public long PublisherId { get; set; }
    [Required]
    public long GenreId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public decimal Price { get; set; }
}
