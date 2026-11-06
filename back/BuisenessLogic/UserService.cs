using System.Runtime.InteropServices;
using BCrypt;
using BuisenessLogic.Entities;
using BuisenessLogic.Interfaces;

namespace BuisenessLogic
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repos;
        public UserService(IUserRepository repos)
        {
            _repos = repos;
        }
        public async Task<bool> AddUserAsync(string userName, string password, string firstname, string lastname, string email)
        {
            User user = new User
            {
                UserName = userName,
                Password = BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12),
                FirstName = firstname,
                LastName = lastname,
                Email = email
            };
            var response = await _repos.CreateUserAsync(user);
            return (response);
        }

        public async Task<User> GetUserByEmailAsync(string Email)
        {
            var response = await _repos.GetUserByEmailAsync(Email);
            return response;
        }

        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            var response = await _repos.GetUserByIdAsync(userId);
            return response;
        }

        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            var response = await _repos.GetUserByUserNameAsync(userName);
            return response;
        }
        public async Task<List<User>> GetAllUsersAsync()
        {
            var response = await _repos.GetAllUsersAsync();
            return response;
        }

        public async Task<bool> RemoveUserAsync(Guid id)
        {
            var response = await _repos.DeleteUserAsync(id);
            return response;
        }

        public async Task<bool> UpdateUserAsync(Guid userId, string? password, string? username, string? firstname, string? lastname, string? email)
        {
            var user = await GetUserByIdAsync(userId);
            User newUser = new User
            {
                Id = userId,
                UserName = username == null ? user.UserName : username,
                Password = password == null ? user.Password : BCrypt.Net.BCrypt.HashPassword(password, workFactor:12),
                FirstName = firstname == null ? user.FirstName : firstname,
                LastName = lastname == null ? user.LastName : lastname,
                Email = email == null ? user.Email : email
            };
            var response = await _repos.UpdateUserAsync(newUser);
            return response;
        }

        public async Task<bool> Login(string input, string password)
        {
            User user;
            if (input.Contains("@gmail.com")) 
            {
                user = await GetUserByEmailAsync(input);
            }
            else
            {
                user = await GetUserByUserNameAsync(input);
            }

            if (user == null) { throw new InvalidDataException("User not found."); }

            if (BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return true;
            }
            else { return false; }
        }
    }
}
