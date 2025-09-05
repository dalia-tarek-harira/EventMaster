using EventMaster.DTOs;
using EventMaster.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventMaster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        // POST: api/notifications/user/3
        /*[HttpPost("user/{userId}")]
        public async Task<IActionResult> CreateNotification(int userId, [FromBody] NotificationDTO dto)
        {
            var notification = await _notificationService.CreateNotificationAsync(dto, userId);
            return CreatedAtAction(nameof(GetNotificationById), new { id = notification.NotificationId }, notification);
        }*/
        [HttpPost("user/{userId}")]
        [ProducesResponseType(typeof(NotificationDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<NotificationDTO>> Create(int userId, [FromBody] NotificationDTO dto)
        {
            var notification = await _notificationService.CreateNotificationAsync(dto,userId);
            if (notification == null)
                return BadRequest("Could not create notification");

            return CreatedAtAction(nameof(GetNotificationById), new { id = notification.NotificationId }, notification);
        }


        // GET: api/notifications/user/3
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserNotifications(int userId)
        {
            var notifications = await _notificationService.GetUserNotificationsAsync(userId);
            return Ok(notifications);
        }

        // GET: api/notifications/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificationById(int id)
        {
            var notification = await _notificationService.GetNotificationByIdAsync(id);
            if (notification == null) return NotFound();

            return Ok(notification);
        }

        // DELETE: api/notifications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotification(int id)
        {
            var result = await _notificationService.DeleteNotificationAsync(id);
            if (!result) return NotFound();

            return NoContent();
        }
    }
}
