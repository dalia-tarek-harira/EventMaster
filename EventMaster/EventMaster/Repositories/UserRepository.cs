using EventMaster.Data;
using EventMaster.Models;
using EventMaster.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventMaster.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {

        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();  // 🔥 this saves to DB
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }



    /* public UserRepository(AppDbContext context) : base(context) { }

     public async Task<User> GetByEmailAsync(string email)
     {
         return await _context.Users
             .FirstOrDefaultAsync(u => u.Email == email);
     }*/
}

