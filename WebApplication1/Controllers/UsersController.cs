using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly List<User> users =
            [
                new User()
                {
                    Id = 1,
                    Name = "Test",
                    Username = "Test",
                    Email = "Test"
                },
                new User()
                {
                    Id = 2,
                    Name = "Test 2",
                    Username = "Test 2",
                    Email = "Test 2"
                },
                new User()
                {
                    Id = 3,
                    Name = "Test 3",
                    Username = "Test 3",
                    Email = "Test 3"
                },
            ];

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var result = users.FirstOrDefault(u => u.Id == id);
            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user, [FromServices] UsersService usersService)
        {
            var errorResponse = usersService.CheckAutorization(this.Request.Headers);

            if (errorResponse != null)
            {
                return Unauthorized(errorResponse);
            }

            user.Id = Random.Shared.Next(1, 1000);
            users.Add(user);

            var result = new { id = user.Id };
            return CreatedAtAction(nameof(Get), result, result);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User user, [FromServices] UsersService usersService)
        {
            var errorResponse = usersService.CheckAutorization(this.Request.Headers);

            if (errorResponse != null)
            {
                return Unauthorized(errorResponse);
            }

            var findUser = users.FirstOrDefault(u => u.Id == id); 

            if (findUser == null)
            {
                var result = new { id = user.Id };
                return CreatedAtAction(nameof(Get), result, result);
            }

            users.Add(user);
            return NoContent();
        }
    }
}
