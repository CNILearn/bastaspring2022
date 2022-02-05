namespace EFCoreAsyncStreams;

public class SomeDataContext : DbContext
{
    public SomeDataContext(DbContextOptions<SomeDataContext> options)
        : base(options) { }

    public DbSet<SomeData> SomeData => Set<SomeData>();
}

public record SomeData(string Text, int SomeDataId = default);
