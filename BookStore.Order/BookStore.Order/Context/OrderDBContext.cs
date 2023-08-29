using BookStore.Order.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Order.Context
{
    public class OrderDBContext:DbContext
    {
        public OrderDBContext(DbContextOptions<OrderDBContext>dbContextOptions) :base(dbContextOptions) { }

        public DbSet<OrderEntity> Orders { get; set; }
    }
}
