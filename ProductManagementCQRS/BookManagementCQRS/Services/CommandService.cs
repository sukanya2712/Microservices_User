using BookManagementCQRS.Entity;

namespace BookManagementCQRS.Services
{
    public class CommandService
    {
        private readonly ProductDBContext _dbContext;
        public CommandService(ProductDBContext dbContext)
        {
            this._dbContext = dbContext;
        }
    }
}
