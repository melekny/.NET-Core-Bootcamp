using Microsoft.AspNetCore.Mvc;
namespace Homework_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        // Swagger Endpoints for API testing.
        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return Ok("This is a GET Request.");
        }
        [HttpPost]
        [Route("Register")]
        public IActionResult RegisterRequest()
        {
            return Ok("Registration successful.");
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult LoginRequest()
        {
            return Ok("Login successful.");
        }

        [HttpDelete]
        [Route("Deleted")]
        public IActionResult GetError()
        {
            return BadRequest("Something went wrong...");
        }

        // Hiding an endpoint from Swagger.
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpPut]
        [Route("Hidden")]
        public IActionResult Put()
        {
            return NotFound("This endpoint is hidden.");
        }
    }
}


