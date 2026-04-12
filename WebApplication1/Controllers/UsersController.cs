using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services.Abstract;
using WebApplication1.Services.Simple;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUsersService usersService, CounterService counterService) : ControllerBase
    {
        private readonly IUsersService usersService = usersService;
        private readonly CounterService counterService = counterService;

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var result = usersService.Get(id);
            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            var result = new { id = this.usersService.Add(user)};
            return CreatedAtAction(nameof(Get), result, result);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User user)
        {
            this.usersService.EditOrAdd(id, user);
            return NoContent();
        }
    }
}
