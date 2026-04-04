using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly List<Post> posts = 
            [
                new Post()
                {
                    UserId = 1,
                    Id = 2,
                    Title = "qui est esse",
                    Body  = "est rerum tempore vitae\nsequi sint nihil reprehenderit dolor beatae ea dolores neque\nfugiat blanditiis voluptate porro vel nihil molestiae ut reiciendis\nqui aperiam non debitis possimus qui neque nisi nulla"
                },
                new Post()
                {
                    UserId = 1,
                    Id = 1,
                    Title = "qui est esse",
                    Body  = "est rerum tempore vitae\nsequi sint nihil reprehenderit dolor beatae ea dolores neque\nfugiat blanditiis voluptate porro vel nihil molestiae ut reiciendis\nqui aperiam non debitis possimus qui neque nisi nulla"
                },
                new Post()
                {
                    UserId = 1,
                    Id = 4,
                    Title = "Title 1",
                    Body  = "est rerum tempore vitae\nsequi sint nihil reprehenderit dolor beatae ea dolores neque\nfugiat blanditiis voluptate porro vel nihil molestiae ut reiciendis\nqui aperiam non debitis possimus qui neque nisi nulla"
                },
                new Post()
                {
                    UserId = 2,
                    Id = 3,
                    Title = "Title 3",
                    Body  = "estiae ut reiciendis\nqui aperiam non debitis possimus qui neque"
                }
            ];

        [HttpGet]
        public IEnumerable<Post> Get(int userId = 1, string title = "")
        {
            return posts.Where(u => u.UserId == userId && (string.IsNullOrWhiteSpace(title) || u.Title == title));
        }

        [HttpGet("{id}")]
        public ActionResult<Post> Get(int id)
        {
            var result = posts.FirstOrDefault(u => u.Id == id);
            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            posts.Remove(posts.FirstOrDefault(u => u.Id == id));
            return NoContent();
        }
    }
}
