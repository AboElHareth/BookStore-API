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
        public IActionResult GetAllAuthors(int pageindex = 1)
        {
            var authors = _service.GetAllAuthors(pageindex);
            return Ok(authors);
        }
        [HttpPost("/add-new-author")]
        public IActionResult AddNewAuthor([FromForm] AuthorVM author)
        {
            try
            {
                var newauthor = _service.AddNewAuthor(author);
                return Ok(newauthor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("/get-author-byid")]
        public IActionResult GetAuthorById(int id)
        {
            try
            {
                var author = _service.GetAuthorById(id);
                return Ok(author);
            }
            catch (Exception ex) 
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("/get-author-byid-with-books")]
        public IActionResult GetAuthorByIdWithBooks(int id)
        {
            try
            {
                var author = _service.GetAuthorByIdWithBooks(id);
                return Ok(author);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
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
            try
            {
                _service.DeleteAuthor(id);
                return Ok("The Author is Deleted");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut("/Update-author")]
        public IActionResult UpdateAuthor([FromForm] AuthorVM author, int id)
        {
            try
            {
                _service.UpdateAuthor(author, id);
                return Ok(author);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
