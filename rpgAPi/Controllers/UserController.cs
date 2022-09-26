using Microsoft.AspNetCore.Mvc;

namespace rpgAPi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<List<User>>> Register(UserDto request)
        {

            User user = new User
            {
                Username = request.Username.ToLower(),
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

    }
}