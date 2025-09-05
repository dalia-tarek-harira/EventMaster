using EventMaster.DTOs;
using EventMaster.Models;
using EventMaster.Repositories.Interfaces;
using EventMaster.Services;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace EventMaster.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }

        public async Task<User> AddUserAsync(UserDTO userDto)
        {
            var user = new User
            {
                FullName = userDto.FullName,
                Email = userDto.Email,
                PasswordHash = HashPassword(userDto.Password),
                Role = Enum.Parse<UserRole>(userDto.Role, true) // case-insensitive
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
            return user;
        }

        public async Task UpdateUserAsync(int id, UserDTO userDto)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null) throw new KeyNotFoundException("User not found");

            existingUser.FullName = userDto.FullName;
            existingUser.Email = userDto.Email;
            if (!string.IsNullOrEmpty(userDto.Password))
            {
                existingUser.PasswordHash = HashPassword(userDto.Password);
            }
            existingUser.Role = Enum.Parse<UserRole>(userDto.Role, true);

            _userRepository.Update(existingUser);
            await _userRepository.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                throw new KeyNotFoundException("User not found");

            _userRepository.Remove(user);
            await _userRepository.SaveChangesAsync();

        }

        private string HashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }

    }
}

