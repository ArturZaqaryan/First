using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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

            return CreatedAtAction(nameof(Get), new { id = user.Id}, new UserCreatedResponse()
            {
                Id = user.Id.ToString(),
                CreatedAt = DateTime.UtcNow,
                Meta = new Meta()
                {
                    PoweredBy = "ReqRes",
                    DocsUrl = "https://app.reqres.in/documentation",
                    UpgradeUrl = "https://app.reqres.in/upgrade",
                    ExampleUrl = "https://app.reqres.in/examples/notes-app",
                    Variant = "v1_a",
                    Message = "Classic ReqRes still works. Projects add persistence, auth, and logs.",
                    Cta = new Cta()
                    {
                        Label = "See example app",
                        Url = "https://app.reqres.in/examples/notes-app"
                    },
                    Context = "legacy_success"
                }
            });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user, [FromServices] UsersService usersService)
        {
            var errorResponse = usersService.CheckAutorization(this.Request.Headers);

            if (errorResponse != null)
            {
                return Unauthorized(errorResponse);
            }

            return Ok(new UserUpdatedResponse()
            {
                UpdatedAt = DateTime.UtcNow,
                Meta = new Meta()
                {
                    PoweredBy = "ReqRes",
                    DocsUrl = "https://app.reqres.in/documentation",
                    UpgradeUrl = "https://app.reqres.in/upgrade",
                    ExampleUrl = "https://app.reqres.in/examples/notes-app",
                    Variant = "v1_a",
                    Message = "Classic ReqRes still works. Projects add persistence, auth, and logs.",
                    Cta = new Cta()
                    {
                        Label = "See example app",
                        Url = "https://app.reqres.in/examples/notes-app"
                    },
                    Context = "legacy_success"
                }
            });
        }
    }
}
