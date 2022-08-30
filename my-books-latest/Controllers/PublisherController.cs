using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using my_books_latest.Data.Models;
using my_books_latest.Data.Services;
using my_books_latest.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books_latest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private PublishersService _publishersService;

        private readonly ILogger<PublisherController> _logger;


        public PublisherController(PublishersService publishersService, ILogger<PublisherController> logger)
        {
            _logger = logger;
            _publishersService = publishersService;
        }


        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            var Publisher = _publishersService.AddPublisher(publisher);
            return Created(nameof(AddPublisher), Publisher);
        }


        [HttpGet("get-publisher-by-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            var publisher = _publishersService.GetPublisherWithBooksIncludingAuthors(id);

            if (publisher != null)
            {
                return Ok(publisher);

            }
            else
            {

                return NotFound();
            }
        }

        [HttpGet("get-all-publishers")]
        public IActionResult GetAllPublishers(string ordername, string filterBy)
        {
            _logger.LogInformation("getting all the publishers");
            var publishers = _publishersService.GetAllPublishers(ordername, filterBy);
            return Ok(publishers);
        }
    }
}
