using BookManagementCQRS.Model.Query;

namespace BookManagementCQRS.Interface
{
    public interface IQueryService
    {
        public List<GetProductModel> GetAllProduct();
    }
}