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

        public InserUpdateModel UpdateProductTable(InserUpdateModel updateProduct, int productID)
        {
            InserUpdateModel product = _dbContext.Product.FirstOrDefault(x => x.ProductId == productID);
            if (product != null)
            {
                product.ProductName = updateProduct.ProductName;
                product.Description = updateProduct.Description;
                product.Quantity = updateProduct.Quantity;
                product.Price = updateProduct.Price;
                product.Addedon = DateTime.Now; //updated 
                product.AddedBy = updateProduct.AddedBy;


                _dbContext.SaveChanges();
                return product;
            }
            return null;
        }


        public bool DeleteProductfromTable(int id)
        {
            InserUpdateModel product = _dbContext.Product.FirstOrDefault(x => x.ProductId == id);
            if (product != null)
            {
                _dbContext.Product.Remove(product);
                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
