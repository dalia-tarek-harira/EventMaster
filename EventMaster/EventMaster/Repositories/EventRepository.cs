using EventMaster.Data;
using EventMaster.Models;
using Microsoft.EntityFrameworkCore;
using EventMaster.Repositories.Interfaces;
namespace EventMaster.Repositories
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
           public EventRepository(AppDbContext context) : base(context) { }

            public async Task<IEnumerable<Event>> GetUpcomingEventsAsync()
            {
                return await _context.Events
                    .Where(e => e.EventDate > DateTime.Now)
                    .ToListAsync();
            }

            public async Task<IEnumerable<Event>> GetEventsByOrganizerAsync(int organizerId)
            {
                return await _context.Events
                    .Where(e => e.OrganizerId == organizerId)
                    .ToListAsync();
            }
        
    }
}
