using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();
builder.Services.AddSqlServer<BooksContext>(builder.Configuration.GetConnectionString("BooksConnection"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthentication();

app.MapInstantAPIs<BooksContext>();

app.Run();

public class BooksContext : DbContext
{
    public BooksContext(DbContextOptions<BooksContext> options)
        : base(options) { }

    public DbSet<Book> Books => Set<Book>();
}

public record Book(int BookId, string Title, string Publisher);