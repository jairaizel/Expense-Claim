// Controllers/AuthController.cs
using Microsoft.AspNetCore.Mvc;
using ExpenseClaimAPI.Models;
using ExpenseClaimAPI.Services;

namespace ExpenseClaimAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;

        public AuthController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(new { Id = user.Id, Username = user.Username, Role = user.Role });
        }
    }
}