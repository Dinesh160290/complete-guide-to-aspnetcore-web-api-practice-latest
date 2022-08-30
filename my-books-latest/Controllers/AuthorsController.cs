using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class AuthorsController : ControllerBase
    {
        private AuthorsService _authorsService;

        public AuthorsController(AuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            _authorsService.AddAuthor(author);
            return Ok();
        }


        [HttpGet("get-author-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var author = _authorsService.GetAuthorWithBooksById(id);
            return Ok(author);
        }

    }
}
