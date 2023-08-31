using BookStore.Order.Entity;

namespace BookStore.Order.Interface
{
    public interface IWishService
    {
        Task<WishEntity> addToWishList(int userID, int bookID, string token);
        Task<List<WishEntity>> GetWishListByUserID(int userID);
        bool RemoveWishList(int bookID, int userID);
    }
}