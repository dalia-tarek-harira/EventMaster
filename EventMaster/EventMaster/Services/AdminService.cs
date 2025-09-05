using EventMaster.Models;
using EventMaster.Repositories.Interfaces;

namespace EventMaster.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEventRepository _eventRepository;

        public AdminService(IUserRepository userRepository, IEventRepository eventRepository)
        {
            _userRepository = userRepository;
            _eventRepository = eventRepository;
        }

        public async Task<IEnumerable<User>> GetPendingOrganizersAsync()
        {
            return (await _userRepository.GetAllAsync())
                .Where(u => u.Role == UserRole.Organizer && (u.OrganizedEvents == null || !u.OrganizedEvents.Any()));
        }


        /* public async Task<IEnumerable<User>> GetPendingOrganizersAsync()
         {
             return (await _userRepository.GetAllAsync())
                 .Where(u => u.Role == UserRole.Organizer && !u.OrganizedEvents.Any());
         }*/

        public async Task<bool> ApproveOrganizerAsync(int userId, bool approve)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null || user.Role != UserRole.Organizer) return false;

            if (!approve)
            {
                _userRepository.Remove(user);
            }

            await _userRepository.SaveChangesAsync();
            return true;
        }
       /* public async Task<bool> ApproveOrganizerAsync(int userId, bool approve)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null || user.Role != UserRole.Organizer)
                return false;

            // ✅ Here you can add a property like "IsApproved"
            user.IsApproved = approve;

            _userRepository.Update(user);
            return true;
        }*/


        public async Task<IEnumerable<Event>> GetPendingEventsAsync()
        {
            return (await _eventRepository.GetAllAsync())
                .Where(e => !e.IsApproved);
        }

        public async Task<bool> ApproveEventAsync(int eventId, bool approve)
        {
            var evnt = await _eventRepository.GetByIdAsync(eventId);
            if (evnt == null) return false;

            evnt.IsApproved = approve;
            _eventRepository.Update(evnt);
            await _eventRepository.SaveChangesAsync();
            return true;
        }
    }
}
