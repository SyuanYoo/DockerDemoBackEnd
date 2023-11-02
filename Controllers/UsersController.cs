using DockerDemoBackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DockerDemoBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DOCKERDEMODBContext _context;

        public UsersController(DOCKERDEMODBContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] User login)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == login.Username && u.Password == login.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(new { message = $"Hi! {user.Username} 登入成功" });
        }
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
