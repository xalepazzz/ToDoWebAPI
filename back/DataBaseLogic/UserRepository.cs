using BuisenessLogic;
using BuisenessLogic.Entities;
using BuisenessLogic.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DataBaseLogic
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connString;
       public UserRepository(IConfiguration conf)
        {
            _connString = conf.GetConnectionString("AuthDB");
            if (string.IsNullOrWhiteSpace(_connString))
            {
                throw new InvalidOperationException("Connection string is null");
            }
        }
        public async Task<bool> CreateUserAsync(User user)
        {
            using (IDbConnection db = new SqlConnection(_connString))
            {
                int response = await db.ExecuteAsync("INSERT INTO Users (Id, Password, UserName, FirstName, LastName, Email)" +
                    " VALUES (@id, @password, @userName, @firstName, @lastName, @email )",
                    new
                    {
                        @id = user.Id,
                        @password = user.Password,
                        @userName = user.UserName,
                        @firstName = user.FirstName,
                        @lastName = user.LastName,
                        @email = user.Email
                    });
                return response > 0;
            }
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            using (IDbConnection db = new SqlConnection(_connString))
            {
                int response = await db.ExecuteAsync("DELETE FROM Users WHERE Id = @id", new { @id = id});
                return response > 0;
            }
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            using (IDbConnection db = new SqlConnection(_connString))
            {
                var response = await db.QueryAsync<User>("SELECT * FROM Users", new { });
                return response.ToList();
            }

            throw new NotImplementedException();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            using (IDbConnection db = new SqlConnection(_connString))
            {
                User response = (await db.QueryAsync<User>("SELECT * FROM Users WHERE Email = @email", new { @email = email })).First();
                return response;
            }
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            using (IDbConnection db = new SqlConnection(_connString))
            {
                User response = (await db.QueryAsync<User>("SELECT * FROM Users WHERE Id = @id", new { @id = id })).First(); 
                return response;
            }
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            using (IDbConnection db = new SqlConnection(_connString))
            {
                User response = (await db.QueryAsync<User>("SELECT * FROM Users WHERE UserName = @userName", new { @userName = userName })).First(); 
                return response;
            }
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateUserAsync(User newUser)
        {
            using (IDbConnection db = new SqlConnection(_connString))
            {
                int response = await db.ExecuteAsync("UPDATE Users SET Password = @password, UserName = @userName, " +
                    "FirstName = @firstName, LastName = @lastName, Email = @email WHERE Id = @id",
                    new {
                        @id = newUser.Id,
                        @password = newUser.Password,
                        @userName = newUser.UserName,
                        @firstName = newUser.FirstName,
                        @lastName = newUser.LastName,
                        @email = newUser.Email
                    });
                return response > 0;
            }
        }
    }
}
