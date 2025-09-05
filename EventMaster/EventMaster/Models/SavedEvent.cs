namespace EventMaster.Models
{
    public class SavedEvent
    {
        public int SavedEventId { get; set; }
        public int EventId { get; set; }
        public int ParticipantId { get; set; }
        public string Message { get; set; }
        public DateTime SavedAt { get; set; }

        public Event Event { get; set; }
        public User Participant { get; set; }

    }
}
