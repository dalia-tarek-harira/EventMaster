namespace EventMaster.Models
{
    public class User
    {

        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<Event> OrganizedEvents { get; set; }
        public ICollection<SavedEvent> SavedEvents { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
}
