using BookStore.Order.Context;
using BookStore.Order.Entity;
using BookStore.Order.Interface;
using BookStore.Order.Model;
using BookStore.Order.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [Authorize]
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
        [Authorize]
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
        [Authorize]
        [HttpPost("addOrder")]
        public async Task<IActionResult> AddOrder(int bookID, int quantity)
        {
            string token = Request.Headers.Authorization.ToString();
            token = token.Substring("Bearer".Length);

            OrderEntity orderEntity = await orderServices.PlaceOrder(bookID, quantity, token);
            if (orderEntity != null)
            {
                return Ok(orderEntity);
            }
            return BadRequest("not added");
        }


        [Authorize]
        [HttpGet("getOrders")]
        public async Task<IActionResult> GetOrders()
        {
            string token = Request.Headers.Authorization.ToString(); // token will have "Bearer " which we need to remove
            token = token.Substring("Bearer ".Length);

            int userID = Convert.ToInt32(User.FindFirstValue("UserID"));

            List<OrderEntity> orderEntity = await orderServices.GetOrders(userID, token);
            if (orderEntity != null)
            {
                return Ok(new ResponseModel { IsSucess = true, Message = "Orders displayed", Data = orderEntity });
            }
            return BadRequest(new ResponseModel { IsSucess = false, Message = "Orders not displayed", Data = null });
        }



        [HttpDelete("removeOrder")]
        public IActionResult RemoveOrder(int orderID)
        {
            int userID = Convert.ToInt32(User.FindFirstValue("UserID"));
            bool isRemove = orderServices.RemoveOrder(orderID, userID);
            if (isRemove)
            {
                return Ok(isRemove);
            }
            return BadRequest("unable to remove order");
        }



        [HttpGet("getOrderByOrderID")]
        public async Task<IActionResult> GetOrdersByOrderID(int orderID)
        {
            string token = Request.Headers.Authorization.ToString();
            token = token.Substring("Bearer ".Length);

            int userID = Convert.ToInt32(User.FindFirstValue("UserID"));

            OrderEntity order = await orderServices.GetOrdersByOrderID(orderID, userID, token);
            if (order != null)
            {
                return Ok(order);
            }

            return BadRequest( "order not found");
        }

    }
}
