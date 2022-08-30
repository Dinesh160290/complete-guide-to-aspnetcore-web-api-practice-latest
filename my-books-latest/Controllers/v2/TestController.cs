using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books_latest.Controllers.v2
{
    [ApiVersion("2.0")]
    [ApiVersion("2.1")]
    [ApiVersion("2.2")]
    [ApiVersion("2.3")]
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("get-test-data"), MapToApiVersion("2.0")]
        public IActionResult Get()
        {
            return Ok("This is test controller v2.0");
        }

        [HttpGet("get-test-data"), MapToApiVersion("2.1")]
        public IActionResult GetV21()
        {
            return Ok("This is test controller v2.1");
        }

        [HttpGet("get-test-data"), MapToApiVersion("2.2")]
        public IActionResult GetV22()
        {
            return Ok("This is test controller v2.2");
        }


        [HttpGet("get-test-data"), MapToApiVersion("2.3")]
        public IActionResult GetV23()
        {
            return Ok("This is test controller v2.3");
        }

        [HttpGet("get-test-data"), MapToApiVersion("2.4")]
        public IActionResult Get24()
        {
            return Ok("This is test controller v2.4");
        }
    }
}
