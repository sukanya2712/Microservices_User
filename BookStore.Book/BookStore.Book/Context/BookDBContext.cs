using BookStore.Book.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Book.Context
{
    public class BookDBContext : DbContext
    {

        public BookDBContext(DbContextOptions<BookDBContext> DbContextOptions): base(DbContextOptions){}

        public DbSet<BookEntity> Books { get; set; }
    }
}
