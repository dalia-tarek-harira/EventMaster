using EventMaster.DTOs;
using EventMaster.Models;

namespace EventMaster.Services
{
    public interface ISavedEventService
    {
        Task<SavedEvent> SaveEventAsync(SavedEventDTO dto);
        Task<IEnumerable<SavedEvent>> GetSavedEventsByUserIdAsync(int userId);
        Task<SavedEvent?> GetSavedEventByIdAsync(int id);
        Task<bool> DeleteSavedEventAsync(int id);
    }
}
