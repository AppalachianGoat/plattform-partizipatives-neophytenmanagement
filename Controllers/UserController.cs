using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using plattform_partizipatives_neophytenmanagement.Data;
using plattform_partizipatives_neophytenmanagement.Models;
using plattform_partizipatives_neophytenmanagement.Services;

namespace plattform_partizipatives_neophytenmanagement.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly FarmerHelperMatchContext _context;
        private readonly IMapper _mapper;

        public UserController(FarmerHelperMatchContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public ActionResult<User> CreateUser([FromBody] CreateUserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("User data is null");
            }

            // Use AutoMapper to map CreateUserDto to User model
            var user = _mapper.Map<User>(userDto);

            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] CreateUserDto userDto)
        {
            if (userDto == null || id <= 0)
            {
                return BadRequest();
            }

            var existingUser = _context.Users.Find(id);

            if (existingUser == null)
            {
                return NotFound();
            }

            _mapper.Map(userDto, existingUser); // AutoMapper is used here to update the existingUser

            _context.Users.Update(existingUser);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            // TODO: Implement user deletion logic
            return Ok();
        }
    }
}
