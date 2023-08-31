using BookManagementCQRS.Interface;
using BookManagementCQRS.Model;
using BookManagementCQRS.Model.Command;
using BookManagementCQRS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementCQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ICommandService commandService;

        public ProductController(ICommandService commandService)
        {
            this.commandService = commandService;
        }


        [HttpPost("addProduct")]
        public IActionResult AddProduct(InserUpdateModel addProduct)
        {
            InserUpdateModel product = commandService.AddProduct(addProduct);
            if (product != null)
            {
                return Ok(new ResponseModel<InserUpdateModel> { Status = true, Message = "ADDED PRODUCT", Data = product });
            }
            return BadRequest(new ResponseModel<string> { Status = false, Message = "UNABLE TO ADD PRODUCT" , Data = null });
        }


    }
}
