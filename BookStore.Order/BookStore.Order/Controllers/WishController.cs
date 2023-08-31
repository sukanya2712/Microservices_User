using BookStore.Order.Entity;
using BookStore.Order.Interface;
using BookStore.Order.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookStore.Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishController : ControllerBase
    {

        private readonly IWishService _wishService;
        public WishController(IWishService _wishService) { this._wishService = _wishService; }

        [Authorize]
        [HttpPost("addWishList")]
        public async Task<IActionResult> AddWishList(int bookID)
        {
            int userID = Convert.ToInt32(User.FindFirstValue("UserID"));

            string token = Request.Headers.Authorization.ToString(); // token will have "Bearer " which we need to remove
            token = token.Substring("Bearer ".Length); // now we will only have the actual jwt token - without Bearer and a space

            WishEntity wishList = await _wishService.addToWishList( userID, bookID, token);
            if (wishList != null)
            {
                return Ok(new ResponseModel { IsSucess = true, Message = "succesfully added to wish list", Data = wishList });
            }

            return BadRequest(new ResponseModel { IsSucess = false, Message = "unsuccesfull to add wish list" });
        }

        [Authorize]
        [HttpDelete("removeWishList")]
        public IActionResult RemoveWishList(int bookID)
        {
            int userID = Convert.ToInt32(User.FindFirstValue("UserID"));
            bool isRemove = _wishService.RemoveWishList(bookID, userID);
            if (isRemove)
            {
                return Ok(new ResponseModel { IsSucess = true, Message = "succesfull to removed wish list", Data = null }) ;
            }
            return BadRequest(new ResponseModel { IsSucess = false, Message = "unsuccesfull to removed wish list" });
        }

        [HttpGet("getWishList")]
        public async Task<IActionResult> GetWishListByUserID()
        {
            int userID = Convert.ToInt32(User.FindFirstValue("UserID"));
            IEnumerable<WishEntity> wishLists = await _wishService.GetWishListByUserID(userID);
            if (wishLists != null)
            {
                return Ok(new ResponseModel { IsSucess = true, Message = "succesfull to get all wish list", Data = wishLists });
            }
            return BadRequest(new ResponseModel { IsSucess = false, Message = "unsuccesfull to get all wish list" });

        }
    }
}
