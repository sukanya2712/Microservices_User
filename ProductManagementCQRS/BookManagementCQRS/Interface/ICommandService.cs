using BookManagementCQRS.Model.Command;

namespace BookManagementCQRS.Interface
{
    public interface ICommandService
    {
        public InserUpdateModel AddProduct(InserUpdateModel product);

        public InserUpdateModel UpdateProductTable(InserUpdateModel updateProduct, int productID);

        public bool DeleteProductfromTable(int id);
    }
}