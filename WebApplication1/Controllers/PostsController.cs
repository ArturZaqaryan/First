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
        public async Task<IEnumerable<Post>> GetAsync(int userId = 1, string title = "")
        {
            return await postsService.GetByUserAndTitleAsync(userId, title);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetAsync(int id)
        {
            var result = this.postsService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }

            return await result;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this.postsService.Delete(id);
            return NoContent();
        }
    }
}
