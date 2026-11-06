using Auth.DTOs;
using Auth.Mapping;
using BuisenessLogic.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace Auth
{
    [Controller]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _serv;

        public UserController(IUserService serv)
        {
            _serv = serv;
        }

        [HttpGet("{userId}")]

        public async Task<ActionResult> GetUserById(Guid userId)
        {
            try
            {
                var user = await _serv.GetUserByIdAsync(userId);
                return Ok(user.MapUserToDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        public async Task<ActionResult> GetAllUsersById()
        {
            try
            {
                var users = await _serv.GetAllUsersAsync();
                return Ok(users.ToDtoList());
            }
            catch (Exception ex)
            {
                return BadRequest(505);
            }

        }

        [HttpPost]
        public async Task<ActionResult> AddNewUser(string userName, string password, string firstName, string lastname, string email)
        {
            try
            {
                var response = await _serv.AddUserAsync(userName, password, firstName, lastname, email);
                if (response) return Ok();
                else return BadRequest(400);
            }
            catch (Exception ex)
            {
                return BadRequest(505);
            }

        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(Guid userId, string? userName, string? password, string? firstName, string? lastname, string? email)
        {
            try
            {
                var response = await _serv.UpdateUserAsync(userId, password, userName, firstName, lastname, email);
                if (response) return Ok();
                else return BadRequest(400);
            }
            catch (Exception ex)
            {
                return BadRequest(505);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteUser(Guid userId)
        {
            try
            {
                var response = await _serv.RemoveUserAsync(userId);
                if (response) return Ok();
                else return BadRequest(400);
            }
            catch (Exception ex)
            {
                return BadRequest(505);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(string input, string password)
        {
            try
            {
                var response = await _serv.Login(input, password);
                if (response) return Ok("Успешно");
                else return BadRequest(400);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
    }
}
