using BookStore.Order.Entity;

namespace BookStore.Order.Interface
{
    public interface IBookServic
    {
        Task<BookEntity> GetBookDetails(int id);
    }
}