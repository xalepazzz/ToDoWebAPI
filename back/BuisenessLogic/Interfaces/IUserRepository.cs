using BuisenessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace BuisenessLogic.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> CreateUserAsync(User user );
        Task<bool> DeleteUser(User user);
        Task<User> GetUserById(Guid Id);
        Task<List<User>> GetAllUsers();
        Task<bool> UpdateUser();
        
    }
}
