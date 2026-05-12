using BookStore.Data;
using BookStore.Model;
using BookStore.Service;
using BookStore.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private BooksService _service;
        public  BooksController(BooksService service)
        {
            _service = service;
        }
        [HttpGet("/get-all-books")]
        public IActionResult GetAllBooks()
        {
            var books = _service.GetAllBooks();
            return Ok(books);
        }
        [HttpGet("/get-all-books-with-publisher")]
        public IActionResult GetAllBooksWithPublisher()
        {
            var books = _service.GetAllBooksWithPublisher();
            return Ok(books);
        }
        [HttpPost("/add-new-book")]
        public IActionResult AddNewBook([FromBody]BookVM book)
        {
            _service.AddNewBook(book);
            return Ok(book);
        }
        [HttpGet("/get-book-byid")]
        public IActionResult GetBookById(int id)
        {
            var book = _service.GetBookById(id);
            return Ok(book);
        }
        [HttpGet("/get-book-byid-with-publisher")]
        public IActionResult GetBookByIdWithPublisher(int id)
        {
            var book = _service.GetBookByIdWithPublisher(id);
            return Ok(book);
        }
        [HttpGet("/get-book-byname")]
        public IActionResult GetBooksByName(string title)
        {
            var books = _service.GetBooksByName(title);
            return Ok(books);
        }
        [HttpGet("/get-book-byname-with-publisher")]
        public IActionResult GetBooksByNameWithPublisher(string title)
        {
            var books = _service.GetBooksByNameWithPublisher(title);
            return Ok(books);
        }
        [HttpDelete("/delete-book")]
        public IActionResult DeleteBook(int id)
        {
            _service.DeleteBook(id);
            return Ok("The Book is Deleted");
        }
        [HttpPut("/Update-book")]
        public IActionResult UpdateBook([FromForm]BookVM book, int id)
        {
            _service.UpdateBook(book, id);
            return Ok(book);
        }
    }
}
