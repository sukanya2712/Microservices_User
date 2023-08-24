using BookStore.User.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.User.Context
{
    public class UserDBContext: DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> dbContextOptions):base(dbContextOptions) { }  

        public DbSet<UserEntity> Users { get; set; }
    }
}
