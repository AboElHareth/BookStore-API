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
    public class PublishersController : ControllerBase
    {
        private PublishersService _service;
        public PublishersController(PublishersService service)
        {
            _service = service;
        }
        [HttpGet("/get-all-publishers")]
        public IActionResult GetAllPublishers(int pageindex = 1)
        {
            var publishers = _service.GetAllPublishers(pageindex);
            return Ok(publishers);
        }
        [HttpPost("/add-new-publisher")]
        public IActionResult AddNewPublisher([FromForm] PublisherVM publisher)
        {
            try
            {
                var newpublisher = _service.AddNewPublisher(publisher);
                return Ok(newpublisher);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("/get-publisher-byid")]
        public IActionResult GetPublisherById(int id)
        {
            try
            {
                var publisher = _service.GetPublisherById(id);
                return Ok(publisher);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("/get-publisher-byid-with-books")]
        public IActionResult GetPublisherByIdWithBooks(int id)
        {
            try
            {
                var publisher = _service.GetPublisherByIdWithBooks(id);
                return Ok(publisher);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("/get-publisher-byname")]
        public IActionResult GetPublisherByName(string title)
        {
            var publishers = _service.GetPublisherByName(title);
            return Ok(publishers);
        }
        [HttpDelete("/delete-publisher")]
        public IActionResult DeletePublisher(int id)
        {
            try
            {
                _service.DeletePublisher(id);
                return Ok("The Publisher is Deleted");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut("/Update-publisher")]
        public IActionResult UpdatePublisher([FromForm] PublisherVM publisher, int id)
        {
            try
            {
                _service.UpdatePublisher(publisher, id);
                return Ok(publisher);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
