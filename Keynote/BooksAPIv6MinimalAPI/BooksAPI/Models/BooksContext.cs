// 1 - file-scoped namespace - C# 10
namespace BooksAPI.Models;

public class BooksContext : DbContext
{
    public BooksContext(DbContextOptions<BooksContext> options)
        : base(options) { }

    public DbSet<Book> Books => Set<Book>();
}

public record Book(int BookId, string Title, string Publisher);
