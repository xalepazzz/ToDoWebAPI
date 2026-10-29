using System.Runtime.InteropServices;
using BCrypt;
using BuisenessLogic.Interfaces;

namespace BuisenessLogic
{
    public class UserService : IUserService
    {
        public Task<bool> AddUserAsync(string userName, string firstname, string lastname, string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetUserByEmailAsync(string Email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetUserByIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetUserByUserNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUserAsync(Guid userId, string? userName, string? firstname, string? lastname, string? email)
        {
            throw new NotImplementedException();
        }
    }
}
