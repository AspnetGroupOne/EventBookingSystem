namespace EventBookingSystem.DTOs;

public class BookingDTO
{
    public Guid Id { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public int EventId { get; set; }
}
