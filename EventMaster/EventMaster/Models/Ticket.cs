namespace EventMaster.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public int EventId { get; set; }
        public int ParticipantId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PricePaid { get; set; }

        public Event Event { get; set; }
        public User Participant { get; set; }

    }
}
