using EventMaster.DTOs;
using EventMaster.Models;
using EventMaster.Repositories;
using EventMaster.Repositories.Interfaces;
using EventMaster.Services;

namespace EventMaster.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<Notification> CreateNotificationAsync(NotificationDTO dto, int userId)
        {
            var notification = new Notification
            {
                EventId = dto.EventId,
                UserId = userId,
                Message = dto.Message,
                SentAt = DateTime.UtcNow
            };

            await _notificationRepository.AddAsync(notification);
            await _notificationRepository.SaveChangesAsync();
            return notification;
        }

        public async Task<IEnumerable<Notification>> GetUserNotificationsAsync(int userId)
        {
            return await _notificationRepository.GetUserNotificationsAsync(userId);
        }

        public async Task<Notification?> GetNotificationByIdAsync(int id)
        {
            return await _notificationRepository.GetByIdAsync(id);
        }

        public async Task<bool> DeleteNotificationAsync(int id)
        {
            var notification = await _notificationRepository.GetByIdAsync(id);
            if (notification == null) return false;

            _notificationRepository.Remove(notification);
            await _notificationRepository.SaveChangesAsync();

            return true;
        }
    }
}
