using Microsoft.AspNetCore.Mvc;
using plattform_partizipatives_neophytenmanagement.Models;

namespace plattform_partizipatives_neophytenmanagement.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            // TODO: Implement user creation logic
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
            // TODO: Implement user update logic
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            // TODO: Implement user deletion logic
            return Ok();
        }
    }
}
