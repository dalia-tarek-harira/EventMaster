using EventMaster.Models;

namespace EventMaster.Services
{
    public interface IAdminService
    {
        Task<IEnumerable<User>> GetPendingOrganizersAsync();
        Task<bool> ApproveOrganizerAsync(int userId, bool approve);
        Task<IEnumerable<Event>> GetPendingEventsAsync();
        Task<bool> ApproveEventAsync(int eventId, bool approve);
    }
}
