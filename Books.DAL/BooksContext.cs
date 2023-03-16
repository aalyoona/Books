using Books.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Books.DAL
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options) : base(options) { }

        public DbSet<BookEntity> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookEntity>()
            .Property(x => x.IsBuy)
            .HasDefaultValue(0);
        }
    }
}