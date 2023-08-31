using BookManagementCQRS.Interface;
using BookManagementCQRS.Model;
using BookManagementCQRS.Model.Query;
using BookManagementCQRS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagementCQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryController : ControllerBase
    {
        private readonly IQueryService queryService;

        public QueryController(IQueryService queryService)
        {
            this.queryService = queryService;
        }


        [HttpGet("getAllProduct")]
        public IActionResult GetAllProducts()
        {
            List<GetProductModel> products = queryService.GetAllProduct();
            if (products != null)
            {
                return Ok(new ResponseModel<List<GetProductModel>> { Status = true, Message = "SUCESSFULLY GOT ALL PRODUCTS", Data = products });
            }
            return BadRequest(new ResponseModel<string> { Status = false, Message = "UNABLE TO GET ALL PRODUCTS" });
        }
    }
}
