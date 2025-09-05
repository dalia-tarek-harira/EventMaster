using EventMaster.Data;
using EventMaster.Models;
using EventMaster.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventMaster.Repositories
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Notification>> GetUserNotificationsAsync(int userId)
        {
            return await _context.Notifications
                .Where(n => n.UserId == userId)
                .ToListAsync();
        }
    }

}
