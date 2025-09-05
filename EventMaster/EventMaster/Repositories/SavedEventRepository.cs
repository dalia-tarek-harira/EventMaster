using Microsoft.EntityFrameworkCore;
using EventMaster.Data;
using EventMaster.Models;
using EventMaster.Repositories.Interfaces;

namespace EventMaster.Repositories
{
    public class SavedEventRepository : GenericRepository<SavedEvent>, ISavedEventRepository
    {
        public SavedEventRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<SavedEvent>> GetSavedEventsByUserIdAsync(int userId)
        {
            return await _context.SavedEvents
                .Where(s => s.ParticipantId == userId)
                .Include(s => s.Event)
                .ToListAsync();
        }
    }
}
