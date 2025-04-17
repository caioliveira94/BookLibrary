using Microsoft.EntityFrameworkCore;
using BookLibrary.Data.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace BookLibrary.Data.Contexts
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> opts)
            : base(opts) { }
        public DbSet<Book> Books { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Book>().ToTable("books");
            mb.Entity<Book>().HasKey(b => b.Id);

            mb.Entity<Book>().Property(b => b.FirstName)
                              .HasColumnName("first_name");
            mb.Entity<Book>().Property(b => b.LastName)
                              .HasColumnName("last_name");
            mb.Entity<Book>().Property(b => b.TotalCopies)
                              .HasColumnName("total_copies");
            mb.Entity<Book>().Property(b => b.CopiesInUse)
                              .HasColumnName("copies_in_use");
        }
    }
}
