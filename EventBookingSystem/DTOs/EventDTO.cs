﻿namespace EventBookingSystem.DTOs
{
    public class EventDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int TicketsAvailable { get; set; }
    }
}
