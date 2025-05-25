using EventBookingSystem.DTOs;
using EventBookingSystem.Repository;

public class EventIntegrationService
{
    private readonly BookingApiService _bookingApiService;
    private readonly EventRepository _eventRepository;

    public EventIntegrationService(BookingApiService bookingApiService, EventRepository eventRepository)
    {
        _bookingApiService = bookingApiService;
        _eventRepository = eventRepository;
    }

    public async Task<bool> BookTicketAndUpdateEventAsync(CreateBookingDto dto)
    {
        var eventEntity = await _eventRepository.GetAsync(e => e.Id == dto.EventId);
        if (eventEntity == null || eventEntity.TicketsAvailable <= 0)
            return false;

        var bookingDTO = new CreateBookingDto
        {
            Name = dto.Name,
            Event = eventEntity.Name,
            TicketCategory = dto.TicketCategory,
            Price = dto.Price,
            Quantity = dto.Quantity,
            Status = "Pending",
            Date = DateTime.Now
        };

        var booking = await _bookingApiService.CreateBookingAsync(bookingDTO);
        if (booking == null)
            return false;

        eventEntity.TicketsAvailable--;
        await _eventRepository.UpdateAsync(eventEntity);

        return true;
    }



    public async Task<IEnumerable<BookingDTO>> GetAllBookingsAsync()
    {
        return await _bookingApiService.GetAllBookingsAsync();
    }
}