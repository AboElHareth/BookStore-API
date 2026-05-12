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
    public class AuthorsController : ControllerBase
    {
        private AuthorsService _service;
        public AuthorsController(AuthorsService service)
        {
            _service = service;
        }
        [HttpGet("/get-all-authors")]
        public IActionResult GetAllAuthors()
        {
            var authors = _service.GetAllAuthors();
            return Ok(authors);
        }
        [HttpPost("/add-new-author")]
        public IActionResult AddNewAuthor([FromForm] AuthorVM author)
        {
            var newauthor = _service.AddNewAuthor(author);
            return Ok(newauthor);
        }
        [HttpGet("/get-author-byid")]
        public IActionResult GetAuthorById(int id)
        {
            var author = _service.GetAuthorById(id);
            return Ok(author);
        }
        [HttpGet("/get-author-byid-with-books")]
        public IActionResult GetAuthorByIdWithBooks(int id)
        {
            var author = _service.GetAuthorByIdWithBooks(id);
            return Ok(author);
        }
        [HttpGet("/get-author-byname")]
        public IActionResult GetAuthorByName(string title)
        {
            var authors = _service.GetAuthorByName(title);
            return Ok(authors);
        }
        [HttpDelete("/delete-author")]
        public IActionResult DeleteAuthor(int id)
        {
            _service.DeleteAuthor(id);
            return Ok("The Author is Deleted");
        }
        [HttpPut("/Update-author")]
        public IActionResult UpdateAuthor([FromForm] AuthorVM author, int id)
        {
            _service.UpdateAuthor(author, id);
            return Ok(author);
        }
    }
}
