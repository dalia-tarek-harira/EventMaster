using Microsoft.EntityFrameworkCore;
using EventMaster.Data;
using EventMaster.Models;
using EventMaster.Repositories.Interfaces;

namespace EventMaster.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
    }
}
