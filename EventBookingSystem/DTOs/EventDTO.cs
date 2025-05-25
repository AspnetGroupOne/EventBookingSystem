namespace EventBookingSystem.DTOs
{
    public class EventDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<int> Tickets { get; set; } = new List<int>();
    }
}
