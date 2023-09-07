using GlobalQueryFilters.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlobalQueryFilters;

public class GlobalQueryFiltersDbContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; } = null!;
    public DbSet<Post> Posts { get; set; } = null!;
    
    public string DbPath { get; }

    public GlobalQueryFiltersDbContext(DbContextOptions<GlobalQueryFiltersDbContext> options) : base(options)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "GlobalQueryFilters.db");   
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Blog>().HasData(new Blog
        {
            Id = Guid.Parse("a51aa976-6c5c-4aa1-939d-4c7b02f0aa2d"),
            Title = "Gabriel Heming - GitHub IO"
        });

        modelBuilder.Entity<Post>().HasData(new Post
        {
            Id = Guid.Parse("c4b96ac4-37b0-4054-84ec-d94bd42a49fa"), 
            Title = "Entity Framework Core: Global Query Filters - part 1",
            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            PublishOn = DateTime.Parse("2023-09-06"),
        });
        
        modelBuilder.Entity<Post>().HasData(new Post
        {
            Id = Guid.Parse("cb2d1db2-000c-41d9-ab25-f28fe1cd1133"), 
            Title = "Happy New Year - 2024",
            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            PublishOn = DateTime.Parse("2024-01-01"),
        });
        
        modelBuilder.Entity<Post>().HasData(new Post
        {
            Id = Guid.Parse("cfdf9d8a-2a73-4c4a-8aa1-0dd3b9d43420"), 
            Title = "Deleted post",
            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            PublishOn = DateTime.Parse("2023-09-01"),
            IsDeleted = true,
        });

        modelBuilder.Entity<Post>().HasQueryFilter(_ => !_.IsDeleted);
    }
}