using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Post> Get(int userId, string title)
        {
            return
            [
                new Post()
                {
                    UserId = userId,
                    Id = 2,
                    Title = title,
                    Body  = "est rerum tempore vitae\nsequi sint nihil reprehenderit dolor beatae ea dolores neque\nfugiat blanditiis voluptate porro vel nihil molestiae ut reiciendis\nqui aperiam non debitis possimus qui neque nisi nulla"
                }
            ];
        }

        [HttpGet("{id}")]
        public Post Get(int id)
        { 
            return new Post()
            {
                UserId = 1,
                Id = id,
                Title = "ea molestias quasi exercitationem repellat qui ipsa sit aut",
                Body = "et iusto sed quo iure\nvoluptatem occaecati omnis eligendi aut ad\nvoluptatem doloribus vel accusantium quis pariatur\nmolestiae porro eius odio et labore et velit aut"
            };
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
