using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BuisenessLogic.Interfaces
{
    public interface IUserService
    {
        public Task<bool> AddUserAsync(string userName, string firstname, string lastname, string email);
        public Task<bool> RemoveUserAsync(Guid id);
        public Task<bool> UpdateUserAsync(Guid userId, string? userName, string? firstname, string? lastname, string? email);
        public Task<bool> GetUserByIdAsync(Guid userId);
        public Task<bool> GetUserByUserNameAsync(string userName);
        public Task<bool> GetUserByEmailAsync(string Email);
    }
}
