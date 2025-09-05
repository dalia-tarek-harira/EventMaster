using EventMaster.DTOs;
using EventMaster.Models;

namespace EventMaster.Services
{
    public interface INotificationService
    {
        Task<Notification> CreateNotificationAsync(NotificationDTO dto, int userId);
        Task<IEnumerable<Notification>> GetUserNotificationsAsync(int userId);
        Task<Notification?> GetNotificationByIdAsync(int id);
        Task<bool> DeleteNotificationAsync(int id);

    }
}
