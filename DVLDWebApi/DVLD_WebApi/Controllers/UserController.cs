using DTOs;
using DVLD_WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
            private readonly UserService _userService;

            public UserController(UserService userService)
            {
                _userService = userService;
            }

        [HttpPost]
        public async Task<IActionResult> AddUser(CreateUpdateUserDTO dto)
        {
            var user = await _userService.AddUserAsync(dto);

            return CreatedAtAction(
                nameof(FindUser),
                new { id = user.UserId },
                user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindUser(int id)
        {
            var user = await _userService.FindUserAsync(id);

            return Ok(user);
        }

        [HttpGet("Person/{personID}")]
        public async Task<IActionResult> FindUserByPersonID(int personID)
        {
            var result =
                await _userService.FindUserByPersonIDAsync(personID);

            return Ok(result);
        }

        [HttpGet("Login")]
        public async Task<IActionResult> FindUser(
            string username,
            string password)
        {
            var user =
                await _userService.FindUserAsync(username, password);

            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(
            CreateUpdateUserDTO dto)
        {
  
                await _userService.UpdateUserAsync(dto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);

            return NoContent();
        }
    }
}

