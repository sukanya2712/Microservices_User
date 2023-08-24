using BookStore.User.Entity;
using BookStore.User.Interface;
using BookStore.User.Model;
using BookStore.User.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;

        public UserController(IUserRepo userRepo)
        {
            this._userRepo = userRepo;
        }

        [Route("AddUsers")]
        [HttpPost]

        public IActionResult AddUsers(UserEntity user)
        {
            UserEntity  Users= _userRepo.addUser(user);

            if (Users != null)
            {
                return Ok(new ResponseModel<UserEntity> { Status = true, Message = "succesfully to added user", Data = Users });
            }
            return BadRequest(new ResponseModel<UserEntity> { Status = false, Message = "unsuccesfull to add user", Data = null });
        }


        [HttpPost("UserLogin")]
        public IActionResult UserLogin(string email, string password)
        {
            string token = _userRepo.loginUser(email, password);

            if (token != null)
            {
                return Ok(new ResponseModel<string> { Status = true, Message = "succesfully login", Data = token });
            }

            return NotFound(new ResponseModel<string> { Status = false, Message = "unsuccesfull login" });
        }


    }
}
