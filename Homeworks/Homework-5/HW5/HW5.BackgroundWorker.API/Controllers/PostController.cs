using HW5.Business.Abstracts;
using HW5.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HW5.BackgroundWorker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        [HttpPost]
        [Route("AddPosts")]
        public IActionResult AddPosts(Post post)
        {
            postService.AddPosts(post);
            return Ok("Posts added to the database successfully.");

        }
    }
}