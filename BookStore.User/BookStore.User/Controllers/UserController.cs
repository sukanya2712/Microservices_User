using BookStore.User.Entity;
using BookStore.User.Interface;
using BookStore.User.Model;
using Microsoft.AspNetCore.Authorization;
//using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookStore.User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
       // private readonly IBus _bus;

        public UserController(IUserRepo userRepo)
        {
            this._userRepo = userRepo;
            //_bus = bus;
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


        [HttpPost("forgot-password")]

        public async Task<IActionResult> UserForgotPassword(string email)
        {
            try
            {
                if (_userRepo.CheckEmail(email))
                {
                    Send send = new Send();
                    ForgetPassword forgotPasswordModel = _userRepo.UserForgotPassword(email);
                    send.SendingMail(forgotPasswordModel.Email, forgotPasswordModel.Token);
                    Uri uri = new Uri("rabbitmq://localhost/FundoNotesEmail_Queue");
                   // var endPoint = await _bus.GetSendEndpoint(uri);
                    //await endPoint.Send(forgotPasswordModel);
                    return Ok(new ResponseModel<string> { Status = true, Message = "email send succesfull", Data = email });
                }
                return BadRequest(new ResponseModel<string> { Status = true, Message = "email send succesfull", Data = email });
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

        }


        [Authorize]
        [HttpPost("ResetUserPassword")]
        public ActionResult ResetUserPassword(ResetPassword resetPassword)
        {

           // string Emai = this.User.FindFirst(x => x.Type == "Email").Value;
                string Email = User.FindFirst(x => x.Type == "Email").Value;
                var result = _userRepo.ResetPassword(Email, resetPassword);
                if (result != null)
                {
                    return Ok(new ResponseModel<ResetPassword> { Status = true, Message = "sucessful resetpassword", Data = result });
                }
                else
                {
                    return BadRequest(new ResponseModel<ResetPassword> { Status = false, Message = "unsucessful resetpassword", Data = null });
                }
            
            //catch (Exception ex)
            //{
            //    throw ex;
            //}


        }

    }
}
