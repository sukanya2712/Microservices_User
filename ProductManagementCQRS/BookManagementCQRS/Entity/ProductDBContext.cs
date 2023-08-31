using BookManagementCQRS.Model.Command;
using Microsoft.EntityFrameworkCore;

namespace BookManagementCQRS.Entity
{
    public class ProductDBContext:DbContext
    {
        public ProductDBContext(DbContextOptions<ProductDBContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<InserUpdateModel> Product { get; set; }

    }
}
