using Books.Models;
using Microsoft.EntityFrameworkCore;

namespace Books.Data
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(e => 
            {
                e.HasKey("id")
                    .HasName("BookId");

                e.Property("Author")
                    .HasColumnName("author")
                        .HasMaxLength(100)
                            .HasColumnType("varchar(100)")
                                .IsRequired(true);

                e.Property("Title")
                    .HasColumnName("title")
                        .HasMaxLength(200)
                            .HasColumnType("varchar(200)")
                                .IsRequired(true);

                e.Property("Description")
                    .HasColumnName("description")
                        .HasMaxLength(250)
                            .HasColumnType("varchar(250)")
                                .IsRequired(false);
            });
        }
    }
}