using EventMaster.DTOs;
using EventMaster.Models;
using EventMaster.Repositories;
using EventMaster.Repositories.Interfaces;
using EventMaster.Services;

namespace EventMaster.Services
{
    public class SavedEventService : ISavedEventService
    {
        private readonly ISavedEventRepository _savedEventRepository;

        public SavedEventService(ISavedEventRepository savedEventRepository)
        {
            _savedEventRepository = savedEventRepository;
        }

        public async Task<SavedEvent> SaveEventAsync(SavedEventDTO dto)
        {
            var savedEvent = new SavedEvent
            {
                EventId = dto.EventId,
                ParticipantId = dto.ParticipantId,
                Message = dto.Message,
                SavedAt = DateTime.UtcNow
            };

            await _savedEventRepository.AddAsync(savedEvent);
            await _savedEventRepository.SaveChangesAsync();
            return savedEvent;
        }

        public async Task<IEnumerable<SavedEvent>> GetSavedEventsByUserIdAsync(int userId)
        {
            return await _savedEventRepository.GetSavedEventsByUserIdAsync(userId);
        }

        public async Task<SavedEvent?> GetSavedEventByIdAsync(int id)
        {
            return await _savedEventRepository.GetByIdAsync(id);
        }

        public async Task<bool> DeleteSavedEventAsync(int id)
        {
            var savedEvent = await _savedEventRepository.GetByIdAsync(id);
            if (savedEvent == null) return false;

            _savedEventRepository.Remove(savedEvent);
            await _savedEventRepository.SaveChangesAsync();
            return true;
        }
    }
}
