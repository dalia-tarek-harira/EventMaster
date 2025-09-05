using Microsoft.EntityFrameworkCore;
using EventMaster.Data;
using EventMaster.Models;
using EventMaster.Repositories.Interfaces;
namespace EventMaster.Repositories
{
    public class AttachmentRepository : GenericRepository<Attachment>, IAttachmentRepository
    {
        public AttachmentRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Attachment>> GetAttachmentsByEventIdAsync(int eventId)
        {
            return await _context.Attachments
                .Where(a => a.EventId == eventId)
                .ToListAsync();
        }
    }

}
