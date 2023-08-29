using BookStore.Order.Context;
using BookStore.Order.Entity;
using BookStore.Order.Interface;
using System.Reflection.Metadata.Ecma335;

namespace BookStore.Order.Service
{
    public class OrderService : IOrderService
    {
        private readonly OrderDBContext orderDBContext;
        private readonly IBookServic bookServic;
        public OrderService(IBookServic bookServic,OrderDBContext orderDBContext) 
        { 
            this.orderDBContext = orderDBContext;
            this.bookServic = bookServic; 
        }

        public async Task<OrderEntity> PlaceOrder(int bookId, int UserId, int qty)
        {
            OrderEntity newOrder = new()
            {
                BookID = bookId,
                UserID = UserId,
                OrderQty = qty,
                Book = await bookServic.GetBookDetails(bookId),
                User = new UserEntity()
            };

            newOrder.OrderAmt = newOrder.Book.DiscountedPri * qty;
            orderDBContext.Add(newOrder);
            orderDBContext.SaveChanges();
            return newOrder;
        }

    }
}
