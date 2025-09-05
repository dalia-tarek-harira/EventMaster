using Microsoft.EntityFrameworkCore;
using EventMaster.Data;
using EventMaster.Models;
using EventMaster.Repositories.Interfaces;

namespace EventMaster.Repositories.Interfaces
{
    public interface IAttachmentRepository : IRepository<Attachment>
    {
        Task<IEnumerable<Attachment>> GetAttachmentsByEventIdAsync(int eventId);
    }
}
