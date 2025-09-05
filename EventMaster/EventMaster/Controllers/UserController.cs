using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EventMaster.Models;
using EventMaster.Services;
using EventMaster.DTOs;
namespace EventMaster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAllUsersAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserDTO userDto)
        {
            var user = await _userService.AddUserAsync(userDto);
            return CreatedAtAction(nameof(GetById), new { id = user.UserId }, user);
        }
       /* [HttpPost]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDTO>> Create([FromBody] UserDTO dto)
        {
            var user = await _userService.AddUserAsync(dto);
            if (user == null)
                return BadRequest("Could not create user");

            return CreatedAtAction(nameof(GetById), new { id = user.UserId }, user);
        }*/


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserDTO userDto)
        {
            await _userService.UpdateUserAsync(id, userDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}


