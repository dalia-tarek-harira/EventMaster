namespace EventMaster.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public DateTime SentAt { get; set; }

        public Event Event { get; set; }
        public User User { get; set; }

    }
}
