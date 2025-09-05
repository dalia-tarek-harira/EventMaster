namespace EventMaster.DTOs
{

    public class EventDTO
    {
        public int OrganizerId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Venue { get; set; }
        public DateTime EventDate { get; set; }
        public decimal TicketPrice { get; set; }
        public int TotalTickets { get; set; }
    }
}
