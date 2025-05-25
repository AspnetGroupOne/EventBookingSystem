public class CreateBookingDto
{
    public Guid EventId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string TicketCategory { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public object? Event { get; internal set; }
    public string? Status { get; internal set; }
    public DateTime Date { get; internal set; }
}
