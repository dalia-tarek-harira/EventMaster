using Microsoft.EntityFrameworkCore;
using EventMaster.Data;
using EventMaster.Models;
using EventMaster.Repositories.Interfaces;

namespace EventMaster.Repositories.Interfaces
{
    public interface ISavedEventRepository : IRepository<SavedEvent>
    {
        Task<IEnumerable<SavedEvent>> GetSavedEventsByUserIdAsync(int userId);
    }
}
