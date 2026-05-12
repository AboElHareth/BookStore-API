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
        public IActionResult GetAllPublishers()
        {
            var publishers = _service.GetAllPublishers();
            return Ok(publishers);
        }
        [HttpPost("/add-new-publisher")]
        public IActionResult AddNewPublisher([FromForm] PublisherVM publisher)
        {
            var newpublisher = _service.AddNewPublisher(publisher);
            return Ok(newpublisher);
        }
        [HttpGet("/get-publisher-byid")]
        public IActionResult GetPublisherById(int id)
        {
            var publisher = _service.GetPublisherById(id);
            return Ok(publisher);
        }
        [HttpGet("/get-publisher-byid-with-books")]
        public IActionResult GetPublisherByIdWithBooks(int id)
        {
            var publisher = _service.GetPublisherByIdWithBooks(id);
            return Ok(publisher);
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
            _service.DeletePublisher(id);
            return Ok("The Publisher is Deleted");
        }
        [HttpPut("/Update-publisher")]
        public IActionResult UpdatePublisher([FromForm] PublisherVM publisher, int id)
        {
            _service.UpdatePublisher(publisher, id);
            return Ok(publisher);
        }
    }
}
