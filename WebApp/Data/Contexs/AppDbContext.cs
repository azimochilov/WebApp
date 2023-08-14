using Microsoft.EntityFrameworkCore;
using WebApp.Domain.Entities;

namespace WebApp.Data.Contexs;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Discount> Discounts { get; set; }
}
