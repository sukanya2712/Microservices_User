using BookStore.Order.Context;
using BookStore.Order.Entity;
using BookStore.Order.Interface;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace BookStore.Order.Service
{
    public class OrderService : IOrderService
    {
        private readonly OrderDBContext orderDBContext;
        private readonly IBookServic bookServic;
        private readonly IUserService userService;
        public OrderService(IBookServic bookServic,OrderDBContext orderDBContext,IUserService userService) 
        { 
            this.orderDBContext = orderDBContext;
            this.bookServic = bookServic;
            this.userService = userService;
        }

        public async Task<OrderEntity> PlaceOrder(int bookId, int qty,string token)
        {
            BookEntity book = await bookServic.GetBookDetails(bookId);
            UserEntity user = await userService.GetUserDetails(token);

            //OrderEntity newOrder = new()
            //{
            //    BookID = bookId,
            //    UserID = user.UserID,
            //    OrderQty = qty,
            //    Book = await bookServic.GetBookDetails(bookId),
            //    User = user,
            //};


            OrderEntity orderEntity = new OrderEntity();
            orderEntity.UserID = user.UserID;
            orderEntity.OrderQty = qty;
            orderEntity.BookID = bookId;

            orderEntity.Book = book;
            orderEntity.User = user;


            orderEntity.OrderAmt = orderEntity.Book.DiscountedPri * qty;
            orderDBContext.Add(orderEntity);
            orderDBContext.SaveChanges();
            return orderEntity;
        }

        public async Task<List<OrderEntity>> GetOrders(int userID, string token)
        {
            List<OrderEntity> result = orderDBContext.Orders.Where(x => x.UserID == userID).ToList();

            if (result != null)
            {
                foreach (OrderEntity order in result)
                {
                    order.Book = await bookServic.GetBookDetails(order.BookID);
                    order.User = await userService.GetUserDetails(token);
                }
                return result;
            }
            return null;
        }

        public bool RemoveOrder(int orderID, int userID)
        {
            OrderEntity orderEntity = orderDBContext.Orders.Where(x => x.OrderID == orderID && x.UserID == userID).FirstOrDefault();
            if (orderEntity != null)
            {
                orderDBContext.Orders.Remove(orderEntity);
                orderDBContext.SaveChanges();

                return true;
            }
            return false;
        }

        public async Task<OrderEntity> GetOrdersByOrderID(int orderID, int userID, string token)
        {
            OrderEntity orderEntity = orderDBContext.Orders.Where(x => x.OrderID == orderID && x.UserID == userID).FirstOrDefault();
            if (orderEntity != null)
            {
                orderEntity.Book = await bookServic.GetBookDetails(orderEntity.BookID);
                orderEntity.User = await userService.GetUserDetails(token);

                return orderEntity;
            }
            return null;
        }
    }
}
