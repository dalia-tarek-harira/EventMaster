using EventMaster.Data;
using EventMaster.Models;
using EventMaster.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventMaster.Repositories
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Ticket>> GetTicketsByEventIdAsync(int eventId)
        {
            return await _context.Tickets
                .Where(t => t.EventId == eventId)
                .ToListAsync();
        }
    }
}
