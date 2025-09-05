namespace EventMaster.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public int OrganizerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Venue { get; set; } // Location Or Place
        public DateTime EventDate { get; set; }
        public decimal TicketPrice { get; set; }
        public int TotalTickets { get; set; }
        public int AvailableTicket { get; set; }
        public bool IsApproved { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public User Organizer { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<SavedEvent> SavedEvents { get; set; }
        public ICollection<Attachment> Attachments { get; set; }
    }
}
