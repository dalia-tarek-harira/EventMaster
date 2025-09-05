using EventMaster.DTOs;
using EventMaster.Models;

namespace EventMaster.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> AddUserAsync(UserDTO userDto);
        Task UpdateUserAsync(int id, UserDTO userDto);
        Task DeleteUserAsync(int id);
    }
}
