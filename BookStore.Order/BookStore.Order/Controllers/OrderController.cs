using BookStore.Order.Entity;
using BookStore.Order.Interface;
using BookStore.Order.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IBookServic bookServices;
        private readonly IOrderService orderServices;
        private readonly IUserService userService;
        public OrderController( IBookServic bookServices, IOrderService orderServices, IUserService userService)
        {
            this.bookServices = bookServices;
            this.orderServices = orderServices;
            this.userService = userService;
        }


        [HttpGet("getBookDetails")]
        public async Task<IActionResult> GetBookDetails(int bookID)
        {
            BookEntity book = await bookServices.GetBookDetails(bookID);
            if (book != null)
            {
                return Ok(book);
            }
            return BadRequest("unable to get book details");
        }

        [HttpGet("getUserDetails")]
        public async Task<IActionResult> GetUserDetails()
        {
            string token = Request.Headers.Authorization.ToString();
            token = token.Substring("Bearer".Length);
            UserEntity user = await userService.GetUserDetails(token);
           
            if (user != null)
            {
                return Ok(user);
            }
            return BadRequest("unable to get user details");
        }
    }
}
