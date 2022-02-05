﻿using Books.Models;
using Books.Services;

using Microsoft.EntityFrameworkCore;

namespace Books.Data;

public class BooksContext : DbContext, IBookChapterService
{
    public BooksContext(DbContextOptions<BooksContext> options)
        : base(options)
    {
    }

    public DbSet<BookChapter> Chapters => Set<BookChapter>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookChapter>().Property(b => b.Title).HasMaxLength(80);
    }

    public async Task<BookChapter> AddAsync(BookChapter chapter)
    {
        await Chapters.AddAsync(chapter);
        await SaveChangesAsync();
        return chapter;
    }

    public async Task AddRangeAsync(IEnumerable<BookChapter> chapters)
    {
        try
        {
            await this.Chapters.AddRangeAsync(chapters);
            await SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<BookChapter>> GetAllAsync()
    {
        var chapters = await Chapters.ToListAsync();
        return chapters;
    }

    public async Task<BookChapter?> FindAsync(Guid id)
    {
        var chapter = await Chapters.FindAsync(id);
        return chapter;
    }

    public async Task<BookChapter?> RemoveAsync(Guid id)
    {
        var chapter = await Chapters.FindAsync(id);
        if (chapter is null) return chapter;
        Chapters.Remove(chapter);
        await SaveChangesAsync();
        return chapter;
    }

    public async Task<BookChapter?> UpdateAsync(BookChapter chapter)
    {
        Chapters.Update(chapter);
        await SaveChangesAsync();
        return chapter;
    }
}
