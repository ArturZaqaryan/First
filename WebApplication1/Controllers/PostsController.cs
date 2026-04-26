using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services.Abstract;
using WebApplication1.Services.Simple;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostsController(IPostsService postsService, CounterService CounterService) : ControllerBase
    {
        private readonly IPostsService postsService = postsService;
        private readonly CounterService durationCounterService = CounterService;

        [HttpGet]
        public IEnumerable<Post> Get(int userId = 1, string title = "")
        {
            return this.postsService.GetByUserAndTitle(userId, title);
        }

        [HttpGet("{id}")]
        public ActionResult<Post> Get(int id)
        {
            var result = this.postsService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this.postsService.Delete(id);
            return NoContent();
        }
    }
}
