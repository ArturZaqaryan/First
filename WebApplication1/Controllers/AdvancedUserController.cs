using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvancedUserController(UserRepository userRepository) : ControllerBase
    {
        private readonly UserRepository userRepository = userRepository;
        [HttpPost]
        public void Post([FromBody] UserRegister user, [FromServices] UserRepository userRepository)
        {
            userRepository.Add(user);
        }
    }
}
