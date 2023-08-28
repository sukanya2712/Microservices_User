using BookStore.Book.Entity;
using BookStore.Book.Interface;
using BookStore.Book.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepo _bookRepo;

        public BookController(IBookRepo _bookRepo)
        {
            this._bookRepo = _bookRepo;
        }

        [Route("AddUsers")]
        [HttpPost]

        public IActionResult AddUsers(BookEntity book)
        {
            BookEntity books = _bookRepo.addBook(book);

            if (books != null)
            {
                return Ok(new ResponseModel<BookEntity> { Status = true, Message = "succesfully to added ", Data = books });
            }
            return BadRequest(new ResponseModel<BookEntity> { Status = false, Message = "unsuccesfull  ", Data = null });
        }


        [Route("DeleteBookbyID")]
        [HttpPost]

        public IActionResult DeleteBookbyID(int id)
        {
            var result = _bookRepo.deleteBook(id);

            if (result != null)
            {
                return Ok(new ResponseModel<bool> { Status = true, Message = "succesfully to remove ", Data = result });
            }
            return BadRequest(new ResponseModel<bool> { Status = false, Message = "unsuccesfull  ", });
        }



        [Route("GetBookbyId")]
        [HttpPost]

        public IActionResult GetBookbyId(int id)
        {
            var result = _bookRepo.getBookbyId(id);

            if (result != null)
            {
                return Ok(new ResponseModel<BookEntity> { Status = true, Message = "succesfully  ", Data = result });
            }
            return BadRequest(new ResponseModel<BookEntity> { Status = false, Message = "unsuccesfull  ", Data = null });
        }


        [Route("getAllBooks")]
        [HttpPost]

        public IActionResult getAllBooks()
        {
            var result = _bookRepo.getAllBooks();

            if (result != null)
            {
                return Ok(new ResponseModel<List<BookEntity>> { Status = true, Message = "succesfully  ", Data = result });
            }
            return BadRequest(new ResponseModel<List<BookEntity>> { Status = false, Message = "unsuccesfull  ", Data = null });
        }




    }
}
