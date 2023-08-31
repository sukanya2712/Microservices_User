using BookManagementCQRS.Entity;
using BookManagementCQRS.Interface;
using BookManagementCQRS.Model.Query;

namespace BookManagementCQRS.Services
{
    public class QueryService : IQueryService
    {

        private readonly ProductDBContext _dbContext;
        public QueryService(ProductDBContext dbContext)
        {
            this._dbContext = dbContext;
        }



        public List<GetProductModel> GetAllProduct()
        {
            List<GetProductModel> products = _dbContext.Product.Select(x => new GetProductModel { ProductId = x.ProductId, ProductName = x.ProductName, price = x.Price, qty = x.Quantity }).ToList();

            if (products != null)
            {
                return products;
            }

            return null;
        }
    }
}
