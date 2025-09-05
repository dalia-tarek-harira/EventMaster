using EventMaster.DTOs;
using EventMaster.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EventMaster.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDTO dto);
        Task<string ?> LoginAsync(string email, string password);
        string GenerateJwtToken(User user);
    }
}
