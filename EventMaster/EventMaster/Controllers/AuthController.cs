using EventMaster.DTOs;
using EventMaster.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventMaster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        // POST: api/auth/register
        [HttpPost("register")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDTO>> Register([FromBody] UserDTO dto)
        {
            var user = await _authService.RegisterAsync(dto);
            if (user == null) return BadRequest("User already exists.");

            return CreatedAtAction(nameof(Register), new { id = user.UserId }, user); 
        }


        // Login
        [HttpPost("login")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)

        {
            var token = await _authService.LoginAsync(dto.Email, dto.Password);
            if (token == null) return Unauthorized("Invalid credentials.");

            return Ok(new { Token = token });
        }


    }
}
