using Auth.DTOs;
using BuisenessLogic.Entities;

namespace Auth.Mapping
{
    public static class UserMapper
    {
        public static UserDto MapUserToDto (this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }

        public static List<UserDto> ToDtoList(this List<User> users)
        {
            return users.Select(u => u.MapUserToDto()).ToList();
        }
    }
}
