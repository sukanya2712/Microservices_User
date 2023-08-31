using BookStore.Order.Context;
using BookStore.Order.Entity;
using BookStore.Order.Interface;
using Newtonsoft.Json.Linq;
using System.Net;

namespace BookStore.Order.Service
{
    public class WishService : IWishService
    {
        private readonly OrderDBContext orderDBContext;
        private readonly IUserService userService;
        private readonly IBookServic bookServic;
        public WishService(OrderDBContext orderDBContext, IUserService userService, IBookServic bookServic)
        {
            this.orderDBContext = orderDBContext;
            this.userService = userService;
            this.bookServic = bookServic;
        }


        public async Task<WishEntity> addToWishList(int userID, int bookID, string token)
        {
            BookEntity book= await bookServic.GetBookDetails(bookID);
            UserEntity user = await userService.GetUserDetails(token);

            //if (!orderDBContext.Wish.Any(x => x.UserID == userID && x.BookID == bookID))
            
                WishEntity wishList = new WishEntity();
                wishList.BookID = bookID;
                wishList.UserID = userID;
                wishList.Book = book;
                wishList.User = user;
                
                orderDBContext.Wish.Add(wishList);
                orderDBContext.SaveChanges();
                return wishList;
            
            
        }

        public bool RemoveWishList(int bookID, int userID)
        {
            var result = orderDBContext.Wish.FirstOrDefault(x => x.BookID == bookID && x.UserID == userID);
            if (result != null)
            {
                orderDBContext.Wish.Remove(result);
                orderDBContext.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<List<WishEntity>> GetWishListByUserID(int userID)
        {
            List<WishEntity> wishList = orderDBContext.Wish.Where(x => x.UserID == userID).ToList();
            if (wishList != null)
            {
                foreach (WishEntity wish in wishList)
                {
                    wish.Book = await bookServic.GetBookDetails(wish.BookID);

                }
                return wishList;
            }
            return null;
        }

    }
}
