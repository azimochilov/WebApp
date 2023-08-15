using WebApp.Domain.Entities;

namespace WebApp.Service.DTOs.Books;
public class BookResultDto
{
    public long Id { get; set; }
    public long AuthorId { get; set; }
    public Author Author { get; set; }
    public long PublisherId { get; set; }
    public Publisher Publisher { get; set; }
    public long GenreId { get; set; }
    public Genre Genre { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
