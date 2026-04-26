using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.Repositories.Abstract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvancedUserController(IUserRepository userRepository) : ControllerBase
    {
        private readonly IUserRepository userRepository = userRepository;
        [HttpPost]
        public void Post([FromBody] AdvancedUser user)
        {
            user.Id = Random.Shared.Next(0, 1000);
            userRepository.Add(user);
        }

        [HttpPatch("{id}", Name = "UpdateUser")]
        public IActionResult Update(int id, [FromBody] JsonPatchDocument<AdvancedUser> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest();
            }

            var user = userRepository.GetById(id);

            // Return 404 Not Found if customer doesn't exist
            if (user == null || user is not AdvancedUser advancedUser)
            {
                return NotFound();
            }

            patchDoc.ApplyTo(advancedUser, jsonPatchError =>
            {
                var key = jsonPatchError.AffectedObject.GetType().Name;
                ModelState.AddModelError(key, jsonPatchError.ErrorMessage);
            }
            );

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return new ObjectResult(user);
        }
    }
}
