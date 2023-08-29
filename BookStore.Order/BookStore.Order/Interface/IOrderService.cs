using BookStore.Order.Entity;

namespace BookStore.Order.Interface
{
    public interface IOrderService
    {
        Task<OrderEntity> PlaceOrder(int bookId, int UserId, int qty);
    }
}