using WebApp.Domain.Commons;

namespace WebApp.Domain.Entities;
public class Book : Auditable
{
    public long AuthorId { get; set; }
    public long PublisherId { get; set; }
    public long GenreId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
