using BookManagementCQRS.Model.Command;

namespace BookManagementCQRS.Interface
{
    public interface ICommandService
    {
        InserUpdateModel AddProduct(InserUpdateModel product);
      
    }
}