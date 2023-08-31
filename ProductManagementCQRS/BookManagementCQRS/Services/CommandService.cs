using BookManagementCQRS.Entity;
using BookManagementCQRS.Interface;
using BookManagementCQRS.Model.Command;

namespace BookManagementCQRS.Services
{
    public class CommandService : ICommandService
    {
        private readonly ProductDBContext _dbContext;
        public CommandService(ProductDBContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public InserUpdateModel AddProduct(InserUpdateModel product)
        {
            bool Product = _dbContext.Product.Any(x => x.ProductName == product.ProductName);
            if (!Product)
            {
                _dbContext.Product.Add(product);
                _dbContext.SaveChanges();

                return product;
            }
            return null;
        }

       
    }
}
