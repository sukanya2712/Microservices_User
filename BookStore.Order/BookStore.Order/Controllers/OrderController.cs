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
        public OrderController( IBookServic bookServices, IOrderService orderServices)
        {
            this.bookServices = bookServices;
            this.orderServices = orderServices;
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
    }
}
