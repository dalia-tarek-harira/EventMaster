namespace EventMaster.Models
{
    public class Category
    {
        public int Id { get; set; } 
        public string Name { get; set; } // e.g., "Music", "Sports"
        public ICollection<Event> Events { get; set; }
    }
}
