using BuisenessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace BuisenessLogic.Interfaces
{
    public interface IUserRepository
    {
        public Task<bool> CreateUserAsync(User user);
        public Task<bool> DeleteUserAsync(Guid id);
        public Task<bool> UpdateUserAsync(User newUser);
        public Task<User> GetUserByIdAsync(Guid id);
        public Task<User> GetUserByUserNameAsync(string userName);
        public Task<User> GetUserByEmailAsync(string email);
        public Task<List<User>> GetAllUsersAsync();
       
        
    }
}
