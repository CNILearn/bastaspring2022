﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using var host = Host.CreateDefaultBuilder()
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<SomeDataContext>(options =>
        {
            var connectionString = context.Configuration.GetConnectionString("BastaConnection");
            options.UseSqlServer(connectionString);
        })
        .AddTransient<Runner>();
    })
    .Build();

var runner = host.Services.GetRequiredService<Runner>();
await runner.CreateDatabaseAsync();
runner.SyncQuery();
await runner.AsyncQuery();

class Runner
{
    private readonly SomeDataContext _context;

    public Runner(SomeDataContext context) => _context = context;

    public async Task CreateDatabaseAsync()
    {
        bool created = await _context.Database.EnsureCreatedAsync();
        if (created)
        {
            var data = Enumerable.Range(1, 100000)
                .Select(i => new SomeData($"text {i}"))
                .ToArray();
            _context.SomeData.AddRange(data);
            await _context.SaveChangesAsync();
        }
    }

    public void SyncQuery()
    {
        var data = _context.SomeData
            .TagWith("SyncQuery");

        foreach (var item in data)
        {
            Console.Write(item.Text);
        }
    }

    public async Task AsyncQuery()
    {
        var e = _context.SomeData
            .TagWith("AsyncQuery")
            .AsAsyncEnumerable<SomeData>();
        
        await foreach (var item in e)
        {
            Console.WriteLine(item.Text);
        }
    }
}

public class SomeDataContext : DbContext
{
    public SomeDataContext(DbContextOptions<SomeDataContext> options)
        : base(options) { }

    public DbSet<SomeData> SomeData => Set<SomeData>();
}

public record SomeData(string Text, int SomeDataId = default);
