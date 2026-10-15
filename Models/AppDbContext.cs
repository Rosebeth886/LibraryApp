using Microsoft.EntityFrameworkCore;
using LibraryApp.Models; 

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Book> Books => Set<Book>();

    // <-- PUT IT HERE inside the AppDbContext class
    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<Author>().HasData(
            new Author { Id = 1, Name = "Jókai Mór" },
            new Author { Id = 2, Name = "Szabó Magda" }
        );

        mb.Entity<Book>().HasData(
            new Book { Id = 1, Title = "Az arany ember", Year = 1872, AuthorId = 1 },
            new Book { Id = 2, Title = "Az ajtó", Year = 1987, AuthorId = 2 }
        );
    }
}