using BuisenessLogic.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BuisenessLogic.Interfaces
{
    public interface IUserService
    {
        public Task<bool> AddUserAsync(string userName, string password, string firstname, string lastname, string email);
        public Task<bool> RemoveUserAsync(Guid id);
        public Task<bool> UpdateUserAsync(Guid userId,string? password, string? userName, string? firstname, string? lastname, string? email);
        public Task<User> GetUserByIdAsync(Guid userId);
        public Task<User> GetUserByUserNameAsync(string userName);
        public Task<User> GetUserByEmailAsync(string Email);
        public Task<List<User>> GetAllUsersAsync();
        public Task<bool> Login(string input, string password);
    }
}
