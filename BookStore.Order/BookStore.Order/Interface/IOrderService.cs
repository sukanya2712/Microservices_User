using BookStore.Order.Entity;

namespace BookStore.Order.Interface
{
    public interface IOrderService
    {
        Task<OrderEntity> PlaceOrder(int bookId, int qty,string token);

        Task<List<OrderEntity>> GetOrders(int userID, string token);

        Task<OrderEntity> GetOrdersByOrderID(int orderID, int userID, string token);

        public bool RemoveOrder(int orderID, int userID);
    }
}