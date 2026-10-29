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
        public Task<bool> DeleteUser(User user);
        public Task<bool> UpdateUser(User newUser);
        public Task<User?> GetUserById(Guid id);
        public Task<User?> GetUserByNickName(string userId);
        public Task<User?> GetUserByEmail(string email);
        public Task<List<User>> GetAllUsers();
       
        
    }
}
