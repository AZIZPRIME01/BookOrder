using Microsoft.EntityFrameworkCore;
using BookOrder.Models;

namespace BookOrder.Data
{
    public class BookOrderDbContext : DbContext
    {
        // Constructor for dependency injection
        public BookOrderDbContext(DbContextOptions<BookOrderDbContext> options)
            : base(options)
        {
        }

        // DbSet represents a table in PostgreSQL
        public DbSet<Book> Books { get; set; }

        // Configure entity relationships / rules
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Example: Make Title and Author required
            modelBuilder.Entity<Book>()
                .Property(b => b.Title)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .Property(b => b.Author)
                .IsRequired();
        }
    }
}
