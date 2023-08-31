using BookStore.Order.Entity;

namespace BookStore.Order.HttpClientsDemo
{
    public interface IOrderHttpClient
    {
        Task<List<OrderEntity>> Lists();
    }
}